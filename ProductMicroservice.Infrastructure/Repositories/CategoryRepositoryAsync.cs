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
    public class CategoryRepositoryAsync : BaseRepositoryAsync<Product_Category>, ICategoryRepositoryAsync
    {
        private readonly ProductDbContext context;
        public CategoryRepositoryAsync(ProductDbContext context) : base(context)
        {
            this.context = context;
        }

        public async Task<IEnumerable<Product_Category>> GetCategoryByParentCategoryId(int parentCategoryId)
        {
            return await context.Product_Category
                .Where(c => c.Parent_Category_Id == parentCategoryId)
                .ToListAsync();
        }
    }
}
