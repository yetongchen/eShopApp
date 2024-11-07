using Microsoft.EntityFrameworkCore;
using OrderMicroservice.ApplicationCore.Contracts.IRepositories;
using OrderMicroservice.ApplicationCore.Entities;
using OrderMicroservice.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderMicroservice.Infrastructure.Repositories
{
    public class OrderRepositoryAsync : BaseRepositoryAsync<OrderMicroservice.ApplicationCore.Entities.Order>, IOrderRepositoryAsync
    {
        private readonly OrderDbContext context;
        public OrderRepositoryAsync(OrderDbContext context) : base(context)
        {
            this.context = context;
        }

        public async Task<IEnumerable<OrderMicroservice.ApplicationCore.Entities.Order>> GetOrdersByCustomerIdAsync(int customerId)
        {
            return await context.Orders.Where(o => o.CustomerId == customerId)
                .Include(o => o.OrderDetails)
                .ToListAsync();
        }
    }
}
