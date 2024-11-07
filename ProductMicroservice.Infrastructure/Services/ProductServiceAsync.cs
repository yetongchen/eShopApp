using AutoMapper;
using Microsoft.EntityFrameworkCore;
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
    public class ProductServiceAsync : IProductServiceAsync
    {
        private readonly IProductRepositoryAsync productRepositoryAsync;
        private readonly IMapper mapper;

        public ProductServiceAsync(IProductRepositoryAsync productRepositoryAsync, IMapper mapper)
        {
            this.productRepositoryAsync = productRepositoryAsync;
            this.mapper = mapper;
        }

        public async Task<int> DeleteProductAsync(int id)
        {
            return await productRepositoryAsync.DeleteAsync(id);
        }

        public async Task<IEnumerable<ProductResponseModel>> GetAllProductsAsync()
        {
            var products = await productRepositoryAsync.GetAllAsync();
            return mapper.Map<IEnumerable<ProductResponseModel>>(products);
        }

        public async Task<ProductResponseModel?> GetProductByIdAsync(int id)
        {
            var product = await productRepositoryAsync.GetByIdAsync(id);
            return mapper.Map<ProductResponseModel?>(product);
        }

        public async Task<IEnumerable<ProductResponseModel>> GetProductByNameAsync(string name)
        {
            var products = await productRepositoryAsync.GetByNameAsync(name);
            return mapper.Map<IEnumerable<ProductResponseModel>>(products);
        }

        public async Task<PaginatedResponseModel<ProductResponseModel>> GetPaginatedProductsAsync(int pageNumber, int pageSize, int? categoryId = null)
        {
            return await productRepositoryAsync.GetPaginatedProductsAsync(pageNumber, pageSize, categoryId);
        }

        public async Task<IEnumerable<ProductResponseModel>> GetProductsByCategoryIdAsync(int categoryId)
        {
            var products = await productRepositoryAsync.GetByCategoryIdAsync(categoryId);
            return mapper.Map<IEnumerable<ProductResponseModel>>(products);
        }

        public async Task<int> InactivateProductAsync(int id)
        {
            return await productRepositoryAsync.SetInactiveAsync(id);
        }

        public async Task<int> SaveProductAsync(ProductRequestModel model)
        {
            var product = mapper.Map<Product>(model);
            return await productRepositoryAsync.InsertAsync(product);
        }

        public async Task<int> UpdateProductAsync(ProductRequestModel model)
        {
            var product = mapper.Map<Product>(model);
            return await productRepositoryAsync.UpdateAsync(product);
        }
    }
}
