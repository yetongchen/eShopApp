using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ProductMicroservice.ApplicationCore.Contracts.IRepositoreis;
using ProductMicroservice.ApplicationCore.Entities;
using ProductMicroservice.ApplicationCore.Models.Response;
using ProductMicroservice.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductMicroservice.Infrastructure.Repositories
{
    public class ProductRepositoryAsync : BaseRepositoryAsync<Product>, IProductRepositoryAsync
    {
        private readonly ProductDbContext context;
        private readonly IMapper mapper;
        public ProductRepositoryAsync(ProductDbContext context, IMapper mapper) : base(context)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public async Task<IEnumerable<Product>> GetByCategoryIdAsync(int categoryId)
        {
            return await context.Product
                .Where(p => p.CategoryId == categoryId)
                .ToListAsync();
        }

        public async Task<IEnumerable<Product>> GetByNameAsync(string name)
        {
            return await context.Product
                .Where (p => p.Name == name)
                .ToListAsync();
        }

        public async Task<PaginatedResponseModel<ProductResponseModel>> GetPaginatedProductsAsync(int pageNumber, int pageSize, int? categoryId = null)
        {
            IQueryable<Product> query = context.Product;

            if (categoryId != null)
            {
                query = query.Where(p => p.CategoryId == categoryId);
            }

            int totalRecords = await query.CountAsync();
            var products = await query.Skip(pageSize).Take(pageSize).ToListAsync();
            var productResponses = mapper.Map<IEnumerable<ProductResponseModel>>(products);

            return new PaginatedResponseModel<ProductResponseModel>
            {
                Data = productResponses,
                PageNumber = pageNumber,
                PageSize = pageSize,
                TotalRecords = totalRecords
            };
        }

        public async Task<int> SetInactiveAsync(int productId)
        {
            var product = await context.Product.FindAsync(productId);
            if (product != null)
            {
                product.IsActive = true;
                return await context.SaveChangesAsync();
            }
            return 0;
        }
    }
}
