using ShippingMicroservice.ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShippingMicroservice.ApplicationCore.Contracts.IRepositoreis
{
    public interface IShipperRepositoryAsync : IRepositoryAsync<Shipper>
    {
        Task<IEnumerable<Shipper>> GetShippersByRegionAsync(string region);
    }
}
