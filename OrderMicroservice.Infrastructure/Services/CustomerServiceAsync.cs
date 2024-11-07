using AutoMapper;
using OrderMicroservice.ApplicationCore.Contracts.IRepositories;
using OrderMicroservice.ApplicationCore.Contracts.IServices;
using OrderMicroservice.ApplicationCore.Entities;
using OrderMicroservice.ApplicationCore.Models.Request;
using OrderMicroservice.ApplicationCore.Models.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderMicroservice.Infrastructure.Services
{
    public class CustomerServiceAsync : ICustomerServiceAsync
    {
        private readonly ICustomerRepositoryAsync customerRepository;
        private readonly IAddressRepositoryAsync addressRepository;
        private readonly IUserAddressRepositoryAsync userAddressRepository;
        private readonly IMapper mapper;

        public CustomerServiceAsync(ICustomerRepositoryAsync customerRepository, IAddressRepositoryAsync addressRepository, IUserAddressRepositoryAsync userAddressRepository, IMapper mapper)
        {
            this.customerRepository = customerRepository;
            this.addressRepository = addressRepository;
            this.userAddressRepository = userAddressRepository;
            this.mapper = mapper;
        }

        public async Task<IEnumerable<CustomerAddressResponseModel>> GetCustomerAddressesByUserId(int userId)
        {
            var addresses = await customerRepository.GetAddressesByUserIdAsync(userId);

            return addresses.Select(address => 
            {
                var response = mapper.Map<CustomerAddressResponseModel>(address);
                response.IsDefaultAddress = address.UserAddresses.FirstOrDefault(ua => ua.CustomerId == userId)?.IsDefaultAddress ?? false;
                return response;
            });
        }

        public async Task<int> SaveCustomerAddress(CustomerAddressRequestModel model)
        {
            var address = mapper.Map<Address>(model);
            var userAddress = mapper.Map<UserAddress>(model);

            var userAddressResult = await userAddressRepository.InsertAsync(userAddress);
            var addressResult = await addressRepository.InsertAsync(address);

            if (userAddressResult > 0 && addressResult > 0)
            {
                return 0;
            }
            return 1;
        }
    }
}
