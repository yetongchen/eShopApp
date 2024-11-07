using AutoMapper;
using PromotionMicroservice.ApplicationCore.Contracts.IRepositoreis;
using PromotionMicroservice.ApplicationCore.Contracts.IServices;
using PromotionMicroservice.ApplicationCore.Entities;
using PromotionMicroservice.ApplicationCore.Models.Request;
using PromotionMicroservice.ApplicationCore.Models.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PromotionMicroservice.Infrastructure.Services
{
    public class PromotionServiceAsync : IPromotionServiceAsync
    {
        private readonly IPromotionRepositoryAsync promotionRepositoryAsync;
        private readonly IMapper mapper;

        public PromotionServiceAsync(IPromotionRepositoryAsync promotionRepositoryAsync, IMapper mapper)
        {
            this.promotionRepositoryAsync = promotionRepositoryAsync;
            this.mapper = mapper;
        }
        public async Task<int> CreatePromotionAsync(PromotionRequestModel requestModel)
        {
            var promotion = mapper.Map<Promotion>(requestModel);
            return await promotionRepositoryAsync.InsertAsync(promotion);
        }

        public async Task<int> DeletePromotionAsync(int id)
        {
            return await promotionRepositoryAsync.DeleteAsync(id);
        }

        public async Task<IEnumerable<PromotionResponseModel>> GetActivePromotionsAsync()
        {
            var promotions = await promotionRepositoryAsync.GetActivePromotionsAsync();
            return mapper.Map<IEnumerable<PromotionResponseModel>>(promotions);
        }

        public async Task<IEnumerable<PromotionResponseModel>> GetAllPromotionsAsync()
        {
            var promotions = await promotionRepositoryAsync.GetAllAsync();
            return mapper.Map<IEnumerable<PromotionResponseModel>>(promotions);
        }

        public async Task<PromotionResponseModel?> GetPromotionByIdAsync(int id)
        {
            var promotion = await promotionRepositoryAsync.GetByIdAsync(id);
            return mapper.Map<PromotionResponseModel?>(promotion);
        }

        public async Task<IEnumerable<PromotionResponseModel>> GetPromotionsByProductCategoryNameAsync(string productCategoryName)
        {
            var promotions = await promotionRepositoryAsync.GetPromotionsByProductCategoryNameAsync(productCategoryName);
            return mapper.Map<IEnumerable<PromotionResponseModel>>(promotions);
        }

        public async Task<int> UpdatePromotionAsync(PromotionRequestModel requestModel)
        {
            var promotion = mapper.Map<Promotion>(requestModel);
            return await promotionRepositoryAsync.UpdateAsync(promotion);
        }
    }
}
