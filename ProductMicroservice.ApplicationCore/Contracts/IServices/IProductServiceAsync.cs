using ProductMicroservice.ApplicationCore.Models.Request;
using ProductMicroservice.ApplicationCore.Models.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductMicroservice.ApplicationCore.Contracts.IServices
{
    public interface IProductServiceAsync
    {
        Task<int> SaveProductAsync(ProductRequestModel model);
        Task<int> UpdateProductAsync(ProductRequestModel model);
        Task<int> InactivateProductAsync(int id);
        Task<ProductResponseModel?> GetProductByIdAsync(int id);
        Task<IEnumerable<ProductResponseModel>> GetProductByNameAsync(string name);
        Task<IEnumerable<ProductResponseModel>> GetAllProductsAsync();
        Task<IEnumerable<ProductResponseModel>> GetProductsByCategoryIdAsync(int categoryId);
        Task<int> DeleteProductAsync(int id);
        Task<PaginatedResponseModel<ProductResponseModel>> GetPaginatedProductsAsync(int pageNumber, int pageSize, int? categoryId = null);
    }
}
