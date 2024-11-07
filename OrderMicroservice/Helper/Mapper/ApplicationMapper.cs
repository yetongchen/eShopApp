using AutoMapper;
using OrderMicroservice.ApplicationCore.Entities;
using OrderMicroservice.ApplicationCore.Models.Request;
using OrderMicroservice.ApplicationCore.Models.Response;

namespace OrderMicroservice.Helper.Mapper
{
    public class ApplicationMapper : Profile
    {
        public ApplicationMapper()
        {
            CreateMap<OrderMicroservice.ApplicationCore.Entities.Order, OrderRequestModel>().ReverseMap();
            CreateMap<OrderMicroservice.ApplicationCore.Entities.Order, OrderResponseModel>().ReverseMap();

            CreateMap<CustomerAddressRequestModel, Address>();
            CreateMap<CustomerAddressRequestModel, UserAddress>()
                .ForMember(dest => dest.Address, opt => opt.MapFrom(src => src))
                .ForMember(dest => dest.CustomerId, opt => opt.MapFrom(src => src.CustomerId))
                .ForMember(dest => dest.IsDefaultAddress, opt => opt.MapFrom(src => src.IsDefaultAddress));
            CreateMap<Address, CustomerAddressResponseModel>()
                .ForMember(dest => dest.AddressId, opt => opt.MapFrom(src => src.Id));

            CreateMap<PaymentMethod, PaymentRequestModel>().ReverseMap();
            CreateMap<PaymentMethod, PaymentResponseModel>().ReverseMap();

            CreateMap<ShoppingCart, ShoppingCartRequestModel>().ReverseMap();
            CreateMap<ShoppingCart, ShoppingCartResponseModel>().ReverseMap();

            CreateMap<ShoppingCartItem, ShoppingCartItemRequestModel>().ReverseMap();
            CreateMap<ShoppingCartItem, ShoppingCartItemResponseModel>().ReverseMap();
        }
    }
}
