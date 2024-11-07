using ProductMicroservice.ApplicationCore.Models.Request;
using ProductMicroservice.ApplicationCore.Models.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductMicroservice.ApplicationCore.Contracts.IServices
{
    public interface ICategoryServiceAsync
    {
        Task<int> SaveCategoryAsync(CategoryRequestModel model);
        Task<IEnumerable<CategoryResponseModel>> GetAllCategoriesAsync();
        Task<CategoryResponseModel?> GetCategoryByIdAsync(int id);
        Task<int> DeleteCategoryAsync(int id);
        Task<IEnumerable<CategoryResponseModel>> GetCategoryByParentCategoryIdAsync(int parentCategoryId);
    }
}
