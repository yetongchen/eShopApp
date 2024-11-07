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
    public class CategoryServiceAsync : ICategoryServiceAsync
    {
        private readonly ICategoryRepositoryAsync categoryRepository;
        private readonly IMapper mapper;

        public CategoryServiceAsync(ICategoryRepositoryAsync categoryRepository, IMapper mapper)
        {
            this.categoryRepository = categoryRepository;
            this.mapper = mapper;
        }

        public async Task<int> DeleteCategoryAsync(int id)
        {
            return await categoryRepository.DeleteAsync(id);
        }

        public async Task<IEnumerable<CategoryResponseModel>> GetAllCategoriesAsync()
        {
            var categories = await categoryRepository.GetAllAsync();
            return mapper.Map<IEnumerable<CategoryResponseModel>>(categories);
        }

        public async Task<CategoryResponseModel?> GetCategoryByIdAsync(int id)
        {
            var category = await categoryRepository.GetByIdAsync(id);
            if (category == null)
            {
                return null;
            }
            return mapper.Map<CategoryResponseModel>(category);
        }

        public async Task<IEnumerable<CategoryResponseModel>> GetCategoryByParentCategoryIdAsync(int parentCategoryId)
        {
            var categories = await categoryRepository.GetCategoryByParentCategoryId(parentCategoryId);
            return mapper.Map<IEnumerable<CategoryResponseModel>>(categories);
        }

        public async Task<int> SaveCategoryAsync(CategoryRequestModel model)
        {
            var category = mapper.Map<Product_Category>(model);
            return await categoryRepository.InsertAsync(category);
        }
    }
}
