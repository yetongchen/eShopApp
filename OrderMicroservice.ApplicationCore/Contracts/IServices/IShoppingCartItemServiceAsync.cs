using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderMicroservice.ApplicationCore.Contracts.IServices
{
    public interface IShoppingCartItemServiceAsync
    {
        Task<int> DeleteShoppingCartItemById(int id);
    }
}
