using PromotionMicroservice.ApplicationCore.Entities;
using PromotionMicroservice.ApplicationCore.Models.Request;
using PromotionMicroservice.ApplicationCore.Models.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PromotionMicroservice.ApplicationCore.Contracts.IServices
{
    public interface IPromotionServiceAsync
    {
        Task<IEnumerable<PromotionResponseModel>> GetAllPromotionsAsync();
        Task<PromotionResponseModel?> GetPromotionByIdAsync(int id);
        Task<int> CreatePromotionAsync(PromotionRequestModel requestModel);
        Task<int> UpdatePromotionAsync(PromotionRequestModel requestModel);
        Task<int> DeletePromotionAsync(int id);
        Task<IEnumerable<PromotionResponseModel>> GetActivePromotionsAsync();
        Task<IEnumerable<PromotionResponseModel>> GetPromotionsByProductCategoryNameAsync(string productCategoryName);
    }
}
