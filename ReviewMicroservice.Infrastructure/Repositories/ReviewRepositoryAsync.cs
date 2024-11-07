using Microsoft.EntityFrameworkCore;
using ReviewMicroservice.ApplicaitonCore.Contracts.IRepositoreis;
using ReviewMicroservice.ApplicaitonCore.Entities;
using ReviewMicroservice.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReviewMicroservice.Infrastructure.Repositories
{
    public class ReviewRepositoryAsync : BaseRepositoryAsync<Customer_Review>, IReviewRepositoryAsync
    {
        private readonly ReviewDbContext context;
        public ReviewRepositoryAsync(ReviewDbContext context) : base(context)
        {
            this.context = context;
        }

        public async Task<IEnumerable<Customer_Review>> GetByProductIdAsync(int productId)
        {
            return await context.Customer_Review
                .Where(r => r.Product_Id == productId)
                .ToListAsync();
        }

        public async Task<IEnumerable<Customer_Review>> GetByUserIdAsync(int userId)
        {
            return await context.Customer_Review
                .Where(r => r.Customer_Id == userId)
                .ToListAsync();
        }

        public async Task<IEnumerable<Customer_Review>> GetByYearAsync(int year)
        {
            return await context.Customer_Review
                .Where(r => r.Review_Date.Year == year)
                .ToListAsync();
        }
        public async Task<int> ApproveReviewAsync(int id)
        {
            var review = await context.Customer_Review.FindAsync(id);
            if (review != null)
            {
                review.IsApproved = true;
                return await context.SaveChangesAsync();
            }
            return 0;
        }

        public async Task<int> RejectReviewAsync(int id)
        {
            var review = await context.Customer_Review.FindAsync(id);
            if (review != null)
            {
                review.IsApproved = false;
                return await context.SaveChangesAsync();
            }
            return 0;
        }
    }
}
