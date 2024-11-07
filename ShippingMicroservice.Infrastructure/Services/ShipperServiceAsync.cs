using AutoMapper;
using ShippingMicroservice.ApplicationCore.Contracts.IRepositoreis;
using ShippingMicroservice.ApplicationCore.Contracts.IServices;
using ShippingMicroservice.ApplicationCore.Entities;
using ShippingMicroservice.ApplicationCore.Models.Request;
using ShippingMicroservice.ApplicationCore.Models.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShippingMicroservice.Infrastructure.Services
{
    public class ShipperServiceAsync : IShipperServiceAsync
    {
        private readonly IShipperRepositoryAsync shipperRepositoryAsync;
        private readonly IMapper mapper;

        public ShipperServiceAsync(IShipperRepositoryAsync shipperRepositoryAsync, IMapper mapper)
        {
            this.shipperRepositoryAsync = shipperRepositoryAsync;
            this.mapper = mapper;
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
    }
}
