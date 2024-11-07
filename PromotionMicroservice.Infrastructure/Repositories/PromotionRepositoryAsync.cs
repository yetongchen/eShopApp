using Microsoft.EntityFrameworkCore;
using PromotionMicroservice.ApplicationCore.Contracts.IRepositoreis;
using PromotionMicroservice.ApplicationCore.Entities;
using PromotionMicroservice.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PromotionMicroservice.Infrastructure.Repositories
{
    public class PromotionRepositoryAsync : BaseRepositoryAsync<Promotion>, IPromotionRepositoryAsync
    {
        private readonly PromotionDbContext context;
        public PromotionRepositoryAsync(PromotionDbContext context) : base(context)
        {
            this.context = context;
        }

        public async Task<IEnumerable<Promotion>> GetActivePromotionsAsync()
        {
            var now = DateTime.Now;
            return await context.Promotion
                .Where(p => p.Start_Date <= now && p.End_Date >= now)
                .ToListAsync();
        }

        public async Task<IEnumerable<Promotion>> GetPromotionsByProductCategoryNameAsync(string productCategoryName)
        {
            return await context.Promotion
                .Include(p => p.Promotion_Details)
                .Where(p => p.Promotion_Details.Any(d => d.Product_Category_Name == productCategoryName))
                .ToListAsync();
        }
    }
}
