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
        Task<int> AddShipperAsync(ShipperRequestModel model);
        Task<int> UpdateShipperAsync(ShipperRequestModel model);
        Task<int> DeleteShipperAsync(int id);
    }
}
