using AutoMapper;
using ProductMicroservice.ApplicationCore.Entities;
using ProductMicroservice.ApplicationCore.Models.Request;
using ProductMicroservice.ApplicationCore.Models.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductMicroservice.ApplicationCore.Helper.Mapper
{
    public class ApplicaitonMapper : Profile
    {
        public ApplicaitonMapper()
        {
            // Category mappings
            CreateMap<CategoryRequestModel, Product_Category>();
            CreateMap<Product_Category, CategoryResponseModel>();

            // Category Variation mappings
            CreateMap<CategoryVariationRequestModel, Category_Variation>();
            CreateMap<Category_Variation, CategoryVariationResponseModel>();

            // Product mappings
            CreateMap<ProductRequestModel, Product>();
            CreateMap<Product, ProductResponseModel>();
            
            // Product Variation mappings
            CreateMap<ProductVariationRequestModel, Product_Variation_Values>();
            CreateMap<Product_Variation_Values, ProductVariationResponseModel>();

            // Variation Value mappings
            CreateMap<VariationValueRequestModel, Variation_Value>();
            CreateMap<Variation_Value, VariationValueResponseModel>();
        }
    }
}
