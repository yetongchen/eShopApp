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
    public class ShoppingCartRepositoryAsync : BaseRepositoryAsync<ShoppingCart>, IShoppingCartRepositoryAsync
    {
        private readonly OrderDbContext context;
        public ShoppingCartRepositoryAsync(OrderDbContext context) : base(context)
        {
            this.context = context;
        }

        public async Task<IEnumerable<ShoppingCart>> GetShoppingCartsByCustomerIdAsync(int customerId)
        {
            return await context.ShoppingCarts
                .Where(sc => sc.CustomerId == customerId)
                .Include(sc => sc.ShoppingCartItems)
                .ToListAsync();
        }
    }
}
