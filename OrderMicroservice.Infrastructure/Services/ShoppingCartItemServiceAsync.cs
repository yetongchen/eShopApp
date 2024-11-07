using OrderMicroservice.ApplicationCore.Contracts.IRepositories;
using OrderMicroservice.ApplicationCore.Contracts.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderMicroservice.Infrastructure.Services
{
    public class ShoppingCartItemServiceAsync : IShoppingCartItemServiceAsync
    {
        private readonly IShoppingCartItemRepositoryAsync shoppingCartItemRepository;
        public ShoppingCartItemServiceAsync(IShoppingCartItemRepositoryAsync shoppingCartItemRepository)
        {
            this.shoppingCartItemRepository = shoppingCartItemRepository;
        }
        public async Task<int> DeleteShoppingCartItemById(int id)
        {
            return await shoppingCartItemRepository.DeleteAsync(id);
        }
    }
}
