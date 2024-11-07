using AutoMapper;
using ReviewMicroservice.ApplicaitonCore.Entities;
using ReviewMicroservice.ApplicaitonCore.Models.Request;
using ReviewMicroservice.ApplicaitonCore.Models.Response;

namespace ReviewMicroservice.Helper.Mapper
{
    public class ApplicatonMapper : Profile
    {
        public ApplicatonMapper()
        {
            CreateMap<Customer_Review, CustomerReviewRequestModel>().ReverseMap();
            CreateMap<Customer_Review, CustomerReviewResponseModel>().ReverseMap();
        }
    }
}
