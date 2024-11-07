using Microsoft.EntityFrameworkCore;
using OrderMicroservice.ApplicationCore.Contracts.IRepositories;
using OrderMicroservice.ApplicationCore.Entities;
using OrderMicroservice.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace OrderMicroservice.Infrastructure.Repositories
{
    public class PaymentMethodRepositoryAsync : BaseRepositoryAsync<PaymentMethod>, IPaymentMethodRepositoryAsync
    {
        private readonly OrderDbContext context;
        public PaymentMethodRepositoryAsync(OrderDbContext context) : base(context)
        {
            this.context = context;
        }

        public async Task<IEnumerable<PaymentMethod>> GetPaymentsByCustomerIdAsync(int customerId)
        {
            return await context.PaymentMethods
                .Where(pm => pm.CustomerId == customerId)
                .Include(pm => pm.PaymentType)
                .ToListAsync();
        }
    }
}
