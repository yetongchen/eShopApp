using AutoMapper;
using OrderMicroservice.ApplicationCore.Contracts.IRepositories;
using OrderMicroservice.ApplicationCore.Contracts.IServices;
using OrderMicroservice.ApplicationCore.Models.Request;
using OrderMicroservice.ApplicationCore.Models.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Order.Infrastructure.Services
{
    public class OrderServiceAsync : IOrderServiceAsync
    {
        private readonly IOrderRepositoryAsync orderRepository;
        private readonly IMapper mapper;
        public OrderServiceAsync(IOrderRepositoryAsync orderRepository, IMapper mapper)
        {
            this.orderRepository = orderRepository;
            this.mapper = mapper;
        }
        public async Task<int> DeleteOrder(int id)
        {
            return await orderRepository.DeleteAsync(id);
        }

        public async Task<IEnumerable<OrderResponseModel>> GetAllOrders()
        {
            return mapper.Map<IEnumerable<OrderResponseModel>>(await orderRepository.GetAllAsync());
        }

        public async Task<IEnumerable<OrderResponseModel>> GetOrdersByCustomerId(int customerId)
        {
            return mapper.Map<IEnumerable<OrderResponseModel>>(await orderRepository.GetOrdersByCustomerIdAsync(customerId));
        }

        public async Task<OrderResponseModel?> GetOrderById(int id)
        {
            return mapper.Map<OrderResponseModel>(await orderRepository.GetByIdAsync(id));
        }

        public async Task<int> InsertOrder(OrderRequestModel model)
        {
            var order = mapper.Map<OrderMicroservice.ApplicationCore.Entities.Order>(model);
            return await orderRepository.InsertAsync(order);
        }

        public async Task<int> UpdateOrder(OrderRequestModel model, int id)
        {
            if (id == model.Id)
            {
                var order = mapper.Map<OrderMicroservice.ApplicationCore.Entities.Order>(model);
                return await orderRepository.UpdateAsync(order);
            }
            return 0;
        }

        public async Task<string> GetOrderStatus(int id)
        {
            var order = await orderRepository.GetByIdAsync(id);
            if (order == null)
            {
                return "";
            }
            return order.OrderStatus;
        }

        public async Task<int> CancelOrder(int id)
        {
            var order = await orderRepository.GetByIdAsync(id);
            if (order == null || order.OrderStatus == "Completed" || order.OrderStatus == "Cancelled")
            {
                return 0;
            }
            order.OrderStatus = "Cancelled";
            return await orderRepository.UpdateAsync(order); ;
        }

        public async Task<int> CompleteOrder(int id)
        {
            var order = await orderRepository.GetByIdAsync(id);
            if (order == null)
            {
                return 0;
            }
            order.OrderStatus = "Completed";
            return await orderRepository.UpdateAsync(order);
        }
    }
}
