using Microsoft.EntityFrameworkCore;
using ProductMicroservice.ApplicationCore.Contracts.IRepositoreis;
using ProductMicroservice.ApplicationCore.Entities;
using ProductMicroservice.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductMicroservice.Infrastructure.Repositories
{
    public class ProductVariationRepositoryAsync : BaseRepositoryAsync<Product_Variation_Values>, IProductVariationRepositoryAsync
    {
        private readonly ProductDbContext context;
        public ProductVariationRepositoryAsync(ProductDbContext context) : base(context)
        {
            this.context = context;
        }

        public async Task<IEnumerable<Product_Variation_Values>> GetByProductIdAsync(int productId)
        {
            return await context.Product_Variation_Values
                .Where(pvv => pvv.Product_Id == productId)
                .ToListAsync();
        }
    }
}
