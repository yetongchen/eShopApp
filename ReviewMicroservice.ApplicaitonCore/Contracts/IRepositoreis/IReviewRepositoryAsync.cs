using ReviewMicroservice.ApplicaitonCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReviewMicroservice.ApplicaitonCore.Contracts.IRepositoreis
{
    public interface IReviewRepositoryAsync : IRepositoryAsync<Customer_Review>
    {
        Task<IEnumerable<Customer_Review>> GetByUserIdAsync(int userId);
        Task<IEnumerable<Customer_Review>> GetByProductIdAsync(int productId);
        Task<IEnumerable<Customer_Review>> GetByYearAsync(int year);
        Task<int> ApproveReviewAsync(int id);
        Task<int> RejectReviewAsync(int id);
    }
}
