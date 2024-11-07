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
    public class UserAddressRepositoryAsync : BaseRepositoryAsync<UserAddress>, IUserAddressRepositoryAsync
    {
        public UserAddressRepositoryAsync(OrderDbContext context) : base(context)
        {
        }
    }
}
