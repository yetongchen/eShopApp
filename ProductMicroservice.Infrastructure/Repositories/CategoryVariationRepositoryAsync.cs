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
    public class CategoryVariationRepositoryAsync : BaseRepositoryAsync<Category_Variation>, ICategoryVariationRepositoryAsync
    {
        private readonly ProductDbContext context;
        public CategoryVariationRepositoryAsync(ProductDbContext context) : base(context)
        {
            this.context = context;
        }

        public async Task<IEnumerable<Category_Variation>> GetCategoryVariationByCategoryId(int categoryId)
        {
            return await context.Category_Variation
                .Where(cv => cv.Category_Id == categoryId)
                .ToListAsync();
        }
    }
}
