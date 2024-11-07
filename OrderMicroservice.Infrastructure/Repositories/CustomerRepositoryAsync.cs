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
    public class CustomerRepositoryAsync : BaseRepositoryAsync<Customer>, ICustomerRepositoryAsync
    {
        private readonly OrderDbContext context;
        public CustomerRepositoryAsync(OrderDbContext context) : base(context)
        {
            this.context = context;
        }

        public async Task<IEnumerable<Address>> GetAddressesByUserIdAsync(int userId)
        {
            return await context.UserAddresses
                .Where(ua => ua.CustomerId == userId)
                .Select(ua => ua.Address)
                .ToListAsync();
        }
    }
}
