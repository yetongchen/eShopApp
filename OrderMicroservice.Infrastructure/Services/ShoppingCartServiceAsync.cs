using AutoMapper;
using OrderMicroservice.ApplicationCore.Contracts.IRepositories;
using OrderMicroservice.ApplicationCore.Contracts.IServices;
using OrderMicroservice.ApplicationCore.Entities;
using OrderMicroservice.ApplicationCore.Models.Request;
using OrderMicroservice.ApplicationCore.Models.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderMicroservice.Infrastructure.Services
{
    public class ShoppingCartServiceAsync : IShoppingCartServiceAsync
    {
        private readonly IShoppingCartRepositoryAsync shoppingCartRepository;
        private readonly IMapper mapper;
        public ShoppingCartServiceAsync (IShoppingCartRepositoryAsync shoppingCartRepository, IMapper mapper)
        {
            this.shoppingCartRepository = shoppingCartRepository;
            this.mapper = mapper;
        }
        public async Task<int> DeleteShoppingCart(int id)
        {
            return await shoppingCartRepository.DeleteAsync(id);
        }

        public async Task<IEnumerable<ShoppingCartResponseModel>> GetShoppingCartsByCustomerId(int customerId)
        {
            var shoppingCarts = await shoppingCartRepository.GetShoppingCartsByCustomerIdAsync(customerId);
            return mapper.Map<IEnumerable<ShoppingCartResponseModel>>(shoppingCarts);
        }

        public async Task<int> SaveShoppingCart(ShoppingCartRequestModel model)
        {
            var shoppingCart = mapper.Map<ShoppingCart>(model);
            return await shoppingCartRepository.InsertAsync(shoppingCart);
        }
    }
}
