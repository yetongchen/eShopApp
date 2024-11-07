using OrderMicroservice.ApplicationCore.Contracts.IRepositories;
using OrderMicroservice.ApplicationCore.Entities;
using OrderMicroservice.ApplicationCore.Models.Request;
using OrderMicroservice.ApplicationCore.Models.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderMicroservice.ApplicationCore.Contracts.IServices
{
    public interface ICustomerServiceAsync
    {
        Task<IEnumerable<CustomerAddressResponseModel>> GetCustomerAddressesByUserId(int userId);
        Task<int> SaveCustomerAddress(CustomerAddressRequestModel model);
    }
}
