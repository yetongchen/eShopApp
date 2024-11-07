using Microsoft.EntityFrameworkCore;
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
    public class ShipperRepositoryAsync : BaseRepositoryAsync<Shipper>, IShipperRepositoryAsync
    {
        private readonly ShipperDbContext context;
        public ShipperRepositoryAsync(ShipperDbContext context) : base(context)
        {
            this.context = context;
        }

        public async Task<IEnumerable<Shipper>> GetShippersByRegionAsync(string region)
        {
            return await context.Shipper
                .Where(s => s.Shipper_Regions.Any(sr => sr.Region.Name == region))
                .ToListAsync();
        }
    }
}
