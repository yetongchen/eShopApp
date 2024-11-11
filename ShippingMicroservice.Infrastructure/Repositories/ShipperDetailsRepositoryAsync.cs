using ShippingMicroservice.ApplicationCore.Contracts.IRepositoreis;
using ShippingMicroservice.ApplicationCore.Entities;
using ShippingMicroservice.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShippingMicroservice.Infrastructure.Repositories
{
    public class ShipperDetailsRepositoryAsync : BaseRepositoryAsync<Shipper_Details>, IShipperDetailsRepositoryAsync
    {
        public ShipperDetailsRepositoryAsync(ShipperDbContext context) : base(context)
        {
        }
    }
}
