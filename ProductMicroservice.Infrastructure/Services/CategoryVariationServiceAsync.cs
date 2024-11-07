using AutoMapper;
using ProductMicroservice.ApplicationCore.Contracts.IRepositoreis;
using ProductMicroservice.ApplicationCore.Contracts.IServices;
using ProductMicroservice.ApplicationCore.Entities;
using ProductMicroservice.ApplicationCore.Models.Request;
using ProductMicroservice.ApplicationCore.Models.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductMicroservice.Infrastructure.Services
{
    public class CategoryVariationServiceAsync : ICategoryVariationServiceAsync
    {
        private readonly ICategoryVariationRepositoryAsync categoryVariationRepository;
        private readonly IMapper mapper;

        public CategoryVariationServiceAsync(ICategoryVariationRepositoryAsync categoryVariationRepository, IMapper mapper)
        {
            this.categoryVariationRepository = categoryVariationRepository;
            this.mapper = mapper;
        }

        public async Task<int> DeleteCategoryVariationAsync(int id)
        {
            return await categoryVariationRepository.DeleteAsync(id);
        }

        public async Task<IEnumerable<CategoryVariationResponseModel>> GetAllCategoryVariationsAsync()
        {
            var categoryVariations = await categoryVariationRepository.GetAllAsync();
            return mapper.Map<IEnumerable<CategoryVariationResponseModel>>(categoryVariations);
        }

        public async Task<IEnumerable<CategoryVariationResponseModel>> GetCategoryVariationByCategoryIdAsync(int categoryId)
        {
            var categoryVariations = await categoryVariationRepository.GetCategoryVariationByCategoryId(categoryId);
            return mapper.Map<IEnumerable<CategoryVariationResponseModel>>(categoryVariations);
        }

        public async Task<CategoryVariationResponseModel?> GetCategoryVariationByIdAsync(int id)
        {
            var categoryVariation = await categoryVariationRepository.GetByIdAsync(id);
            return mapper.Map<CategoryVariationResponseModel?>(categoryVariation);
        }

        public async Task<int> SaveCategoryVariationAsync(CategoryVariationRequestModel model)
        {
            var categoryVariation = mapper.Map<Category_Variation>(model);
            return await categoryVariationRepository.InsertAsync(categoryVariation);
        }
    }
}
