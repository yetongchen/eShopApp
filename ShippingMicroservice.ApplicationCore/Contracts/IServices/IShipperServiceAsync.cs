using ShippingMicroservice.ApplicationCore.Models.Request;
using ShippingMicroservice.ApplicationCore.Models.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShippingMicroservice.ApplicationCore.Contracts.IServices
{
    public interface IShipperServiceAsync
    {
        Task<IEnumerable<ShipperResponseModel>> GetAllShippersAsync();
        Task<ShipperResponseModel?> GetShipperByIdAsync(int id);
        Task<IEnumerable<ShipperResponseModel>> GetShipperByRegionAsync(string region);
        Task AddShipperAsync(ShipperRequestModel model);
        Task UpdateShipperAsync(int id, ShipperRequestModel model);
        Task DeleteShipperAsync(int id);
    }
}
