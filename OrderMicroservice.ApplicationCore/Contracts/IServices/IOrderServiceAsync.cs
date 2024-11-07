using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OrderMicroservice.ApplicationCore.Entities;
using OrderMicroservice.ApplicationCore.Models.Request;
using OrderMicroservice.ApplicationCore.Models.Response;

namespace OrderMicroservice.ApplicationCore.Contracts.IServices
{
    public interface IOrderServiceAsync
    {
        Task<int> InsertOrder(OrderRequestModel model);
        Task<int> DeleteOrder(int id);
        Task<int> UpdateOrder(OrderRequestModel model, int id);
        Task<OrderResponseModel?> GetOrderById(int id);
        Task<IEnumerable<OrderResponseModel>> GetAllOrders();
        Task<IEnumerable<OrderResponseModel>> GetOrdersByCustomerId(int customerId);
        Task<string> GetOrderStatus(int id);
        Task<int> CancelOrder(int id);
        Task<int> CompleteOrder(int id);
    }
}
