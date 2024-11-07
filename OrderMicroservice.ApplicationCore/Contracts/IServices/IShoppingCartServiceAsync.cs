using OrderMicroservice.ApplicationCore.Models.Request;
using OrderMicroservice.ApplicationCore.Models.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderMicroservice.ApplicationCore.Contracts.IServices
{
    public interface IShoppingCartServiceAsync
    {
        Task<IEnumerable<ShoppingCartResponseModel>> GetShoppingCartsByCustomerId(int customerId);
        Task<int> SaveShoppingCart(ShoppingCartRequestModel model);
        Task<int> DeleteShoppingCart(int id);
    }
}
