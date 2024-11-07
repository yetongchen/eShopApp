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
    public class VariationValueRepositoryAsync : BaseRepositoryAsync<Variation_Value>, IVariationValueRepositoryAsync
    {
        private readonly ProductDbContext context;
        public VariationValueRepositoryAsync(ProductDbContext context) : base(context)
        {
            this.context = context;
        }

        public async Task<IEnumerable<Variation_Value>> GetByVariationIdAsync(int variationId)
        {
            return await context.Variation_Value
                .Where(vv => vv.Variation_Id == variationId)
                .ToListAsync();
        }
    }
}
