using AutoMapper;
using PromotionMicroservice.ApplicationCore.Entities;
using PromotionMicroservice.ApplicationCore.Models.Request;
using PromotionMicroservice.ApplicationCore.Models.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PromotionMicroservice.ApplicationCore.Helper.Mapper
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
