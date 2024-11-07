using AutoMapper;
using ReviewMicroservice.ApplicaitonCore.Entities;
using ReviewMicroservice.ApplicaitonCore.Models.Request;
using ReviewMicroservice.ApplicaitonCore.Models.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReviewMicroservice.ApplicaitonCore.Helper.Mapper
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
