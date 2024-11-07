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
    public class AddressRepositoryAsync : BaseRepositoryAsync<Address>, IAddressRepositoryAsync
    {
        public AddressRepositoryAsync(OrderDbContext context) : base(context)
        {
        }
    }
}
