using AutoMapper;
using PromotionMicroservice.ApplicationCore.Entities;
using PromotionMicroservice.ApplicationCore.Models.Request;
using PromotionMicroservice.ApplicationCore.Models.Response;

namespace PromotionMicroservice.Helper.Mapper
{
    public class ApplicationMapper : Profile
    {
        public ApplicationMapper()
        {
            CreateMap<Promotion, PromotionRequestModel>().ReverseMap();
            CreateMap<Promotion, PromotionResponseModel>().ReverseMap();
        }
    }
}
