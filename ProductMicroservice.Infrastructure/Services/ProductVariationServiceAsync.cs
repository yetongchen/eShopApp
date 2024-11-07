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
    public class ProductVariationServiceAsync : IProductVariationServiceAsync
    {
        private readonly IProductVariationRepositoryAsync productVariationRepository;
        private readonly IMapper mapper;

        public ProductVariationServiceAsync(IProductVariationRepositoryAsync productVariationRepository, IMapper mapper)
        {
            this.productVariationRepository = productVariationRepository;
            this.mapper = mapper;
        }

        public async Task<IEnumerable<ProductVariationResponseModel>> GetProductVariationsAsync(int productId)
        {
            var productVariations = await productVariationRepository.GetByProductIdAsync(productId);
            return mapper.Map<IEnumerable<ProductVariationResponseModel>>(productVariations);
        }

        public async Task<int> SaveProductVariationAsync(ProductVariationRequestModel model)
        {
            var productVariation = mapper.Map<Product_Variation_Values>(model);
            return await productVariationRepository.InsertAsync(productVariation);
        }
    }
}
