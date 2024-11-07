using AutoMapper;
using ReviewMicroservice.ApplicaitonCore.Contracts.IRepositoreis;
using ReviewMicroservice.ApplicaitonCore.Contracts.IServices;
using ReviewMicroservice.ApplicaitonCore.Entities;
using ReviewMicroservice.ApplicaitonCore.Models.Request;
using ReviewMicroservice.ApplicaitonCore.Models.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReviewMicroservice.Infrastructure.Services
{
    public class ReviewServiceAsync : IReviewServiceAsync
    {
        private readonly IReviewRepositoryAsync reviewRepository;
        private readonly IMapper mapper;

        public ReviewServiceAsync(IReviewRepositoryAsync reviewRepository, IMapper mapper)
        {
            this.reviewRepository = reviewRepository;
            this.mapper = mapper;
        }

        public async Task<int> ApproveReviewAsync(int id)
        {
            return await reviewRepository.ApproveReviewAsync(id);
        }

        public Task<int> CreateReviewAsync(CustomerReviewRequestModel request)
        {
            var review = mapper.Map<Customer_Review>(request);
            return reviewRepository.InsertAsync(review);
        }

        public async Task<int> DeleteReviewAsync(int id)
        {
            return await reviewRepository.DeleteAsync(id);
        }

        public async Task<IEnumerable<CustomerReviewResponseModel>> GetAllReviewsAsync()
        {
            var reviews = await reviewRepository.GetAllAsync();
            return mapper.Map<IEnumerable<CustomerReviewResponseModel>>(reviews);
        }

        public async Task<CustomerReviewResponseModel?> GetReviewByIdAsync(int id)
        {
            var review = await reviewRepository.GetByIdAsync(id);
            return mapper.Map<CustomerReviewResponseModel?>(review);
        }

        public async Task<IEnumerable<CustomerReviewResponseModel>> GetReviewsByProductIdAsync(int productId)
        {
            var reviews = await reviewRepository.GetByProductIdAsync(productId);
            return mapper.Map<IEnumerable<CustomerReviewResponseModel>>(reviews);
        }

        public async Task<IEnumerable<CustomerReviewResponseModel>> GetReviewsByUserIdAsync(int userId)
        {
            var reviews = await reviewRepository.GetByUserIdAsync(userId);
            return mapper.Map<IEnumerable<CustomerReviewResponseModel>>(reviews);
        }

        public async Task<IEnumerable<CustomerReviewResponseModel>> GetReviewsByYearAsync(int year)
        {
            var reviews = await reviewRepository.GetByYearAsync(year);
            return mapper.Map<IEnumerable<CustomerReviewResponseModel>>(reviews);
        }

        public async Task<int> RejectReviewAsync(int id)
        {
            return await reviewRepository.RejectReviewAsync(id);
        }

        public async Task<int> UpdateReviewAsync(CustomerReviewRequestModel request)
        {
            var review = mapper.Map<Customer_Review>(request);
            return await reviewRepository.UpdateAsync(review);
        }
    }
}
