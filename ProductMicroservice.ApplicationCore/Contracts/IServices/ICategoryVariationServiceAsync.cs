using ProductMicroservice.ApplicationCore.Models.Request;
using ProductMicroservice.ApplicationCore.Models.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductMicroservice.ApplicationCore.Contracts.IServices
{
    public interface ICategoryVariationServiceAsync
    {
        Task<int> SaveCategoryVariationAsync(CategoryVariationRequestModel model);
        Task<IEnumerable<CategoryVariationResponseModel>> GetAllCategoryVariationsAsync();
        Task<CategoryVariationResponseModel?> GetCategoryVariationByIdAsync(int id);
        Task<int> DeleteCategoryVariationAsync(int id);
        Task<IEnumerable<CategoryVariationResponseModel>> GetCategoryVariationByCategoryIdAsync(int categoryId);
    }
}
