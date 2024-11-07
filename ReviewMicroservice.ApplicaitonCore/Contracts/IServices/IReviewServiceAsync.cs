using ReviewMicroservice.ApplicaitonCore.Entities;
using ReviewMicroservice.ApplicaitonCore.Models.Request;
using ReviewMicroservice.ApplicaitonCore.Models.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReviewMicroservice.ApplicaitonCore.Contracts.IServices
{
    public interface IReviewServiceAsync
    {
        Task<IEnumerable<CustomerReviewResponseModel>> GetAllReviewsAsync();
        Task<CustomerReviewResponseModel?> GetReviewByIdAsync(int id);
        Task<IEnumerable<CustomerReviewResponseModel>> GetReviewsByUserIdAsync(int userId);
        Task<IEnumerable<CustomerReviewResponseModel>> GetReviewsByProductIdAsync(int productId);
        Task<IEnumerable<CustomerReviewResponseModel>> GetReviewsByYearAsync(int year);
        Task<int> CreateReviewAsync(CustomerReviewRequestModel request);
        Task<int> UpdateReviewAsync(CustomerReviewRequestModel request);
        Task<int> DeleteReviewAsync(int id);
        Task<int> ApproveReviewAsync(int id);
        Task<int> RejectReviewAsync(int id);
    }
}
