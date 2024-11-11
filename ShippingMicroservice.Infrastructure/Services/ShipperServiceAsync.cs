using AutoMapper;
using ShippingMicroservice.ApplicationCore.Contracts.IRepositoreis;
using ShippingMicroservice.ApplicationCore.Contracts.IServices;
using ShippingMicroservice.ApplicationCore.Entities;
using ShippingMicroservice.ApplicationCore.Models.Request;
using ShippingMicroservice.ApplicationCore.Models.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace ShippingMicroservice.Infrastructure.Services
{
    public class ShipperServiceAsync : IShipperServiceAsync
    {
        private readonly IShipperRepositoryAsync shipperRepositoryAsync;
        private readonly IShipperDetailsRepositoryAsync shipperDetailsRepositoryAsync;
        private readonly IMapper mapper;
        private readonly IHttpClientFactory httpClientFactory;

        public ShipperServiceAsync(IShipperRepositoryAsync shipperRepositoryAsync, IShipperDetailsRepositoryAsync shipperDetailsRepositoryAsync, IMapper mapper, IHttpClientFactory httpClientFactory)
        {
            this.shipperRepositoryAsync = shipperRepositoryAsync;
            this.shipperDetailsRepositoryAsync = shipperDetailsRepositoryAsync;
            this.mapper = mapper;
            this.httpClientFactory = httpClientFactory;
        }
        public async Task<int> AddShipperAsync(ShipperRequestModel model)
        {
            var shipper = mapper.Map<Shipper>(model);
            return await shipperRepositoryAsync.InsertAsync(shipper);
        }

        public async Task<int> DeleteShipperAsync(int id)
        {
            return await shipperRepositoryAsync.DeleteAsync(id);
        }

        public async Task<IEnumerable<ShipperResponseModel>> GetAllShippersAsync()
        {
            var shippers = await shipperRepositoryAsync.GetAllAsync();
            return mapper.Map<IEnumerable<ShipperResponseModel>>(shippers);
        }

        public async Task<ShipperResponseModel?> GetShipperByIdAsync(int id)
        {
            var shipper = await shipperRepositoryAsync.GetByIdAsync(id);
            return mapper.Map<ShipperResponseModel?>(shipper);
        }

        public async Task<IEnumerable<ShipperResponseModel>> GetShipperByRegionAsync(string region)
        {
            var shippers = await shipperRepositoryAsync.GetShippersByRegionAsync(region);
            return mapper.Map<IEnumerable<ShipperResponseModel>>(shippers);
        }

        public async Task<int> UpdateShipperAsync(ShipperRequestModel model)
        {
            var shipper = mapper.Map<Shipper>(model);
            return await shipperRepositoryAsync.UpdateAsync(shipper);
        }

        public async Task<int> UpdateShipperDetailsAsync(ShipperDetailsRequestModel model)
        {
            var shipperDetails = mapper.Map<Shipper_Details>(model);
            var result = await shipperDetailsRepositoryAsync.UpdateAsync(shipperDetails);

            if (result > 0 && model.Shipping_Status != null)
            {
                if (model.Shipping_Status.ToLower() == "shipped" || model.Shipping_Status.ToLower() == "delivered")
                {
                    await NotifyOrderServiceAsync(model.Order_Id, model.Shipping_Status);
                }
            }
            return result;
        }

        private async Task NotifyOrderServiceAsync(int orderId, string shippingStatus)
        {
            var client = httpClientFactory.CreateClient("OrderMicroservice");
            var payload = new { OrderId = orderId, ShippingStatus = shippingStatus };


            var response = await client.PutAsJsonAsync($"/order/{orderId}/shipping-status", payload);

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception($"Failed to update order service. Status code: {response.StatusCode}");
            }
        }
    }
}
