using AutoMapper;
using ShippingMicroservice.ApplicationCore.Entities;
using ShippingMicroservice.ApplicationCore.Models.Request;
using ShippingMicroservice.ApplicationCore.Models.Response;

namespace ShippingMicroservice.Helper.Mapper
{
    public class ApplicationMapper : Profile
    {
        public ApplicationMapper()
        {
            CreateMap<Shipper, ShipperResponseModel>();
            CreateMap<ShipperRequestModel, Shipper>();
        }
    }
}
