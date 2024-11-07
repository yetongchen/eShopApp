using ProductMicroservice.ApplicationCore.Entities;
using ProductMicroservice.ApplicationCore.Models.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductMicroservice.ApplicationCore.Contracts.IRepositoreis
{
    public interface IProductRepositoryAsync : IRepositoryAsync<Product>
    {
        Task<IEnumerable<Product>> GetByCategoryIdAsync(int categoryId);
        Task<IEnumerable<Product>> GetByNameAsync(string name);
        Task<int> SetInactiveAsync(int productId);
        Task<PaginatedResponseModel<ProductResponseModel>> GetPaginatedProductsAsync(int pageNumber, int pageSize, int? categoryId = null);
    }
}
