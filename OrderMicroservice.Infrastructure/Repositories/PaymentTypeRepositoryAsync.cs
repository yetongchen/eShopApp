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
    public class PaymentTypeRepositoryAsync : BaseRepositoryAsync<PaymentType>, IPaymentTypeRepositoryAsync
    {
        private readonly OrderDbContext context;
        public PaymentTypeRepositoryAsync(OrderDbContext context) : base(context)
        {
            this.context = context;
        }

        public async Task<PaymentType?> GetByNameAsync(string name)
        {
            return await context.PaymentTypes
                .Where(t => t.Name == name)
                .FirstOrDefaultAsync();
        }
    }
}
