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
    public class PaymentServiceAsync : IPaymentServiceAsync
    {
        private readonly IPaymentMethodRepositoryAsync paymentMethodRepository;
        private readonly IPaymentTypeRepositoryAsync paymentTypeRepository;
        private readonly IMapper mapper;

        public PaymentServiceAsync(IPaymentMethodRepositoryAsync paymentMethodRepository, IPaymentTypeRepositoryAsync paymentTypeRepository, IMapper mapper)
        {
            this.paymentMethodRepository = paymentMethodRepository;
            this.paymentTypeRepository = paymentTypeRepository;
            this.mapper = mapper;
        }

        public async Task<IEnumerable<PaymentResponseModel>> GetPaymentsByCustomerIdAsync(int customerId)
        {
            var payments = await paymentMethodRepository.GetPaymentsByCustomerIdAsync(customerId);
            return mapper.Map<IEnumerable<PaymentResponseModel>>(payments);
        }

        public async Task<int> SavePaymentAsync(PaymentRequestModel request)
        {
            var paymentTypeId = request.PaymentTypeId;
            var paymentType = await paymentTypeRepository.GetByIdAsync(request.PaymentTypeId);
            if (paymentType == null && request.PaymentTypeName != null && request.PaymentTypeName != "")
            {
                await paymentTypeRepository.InsertAsync(new PaymentType { Name = request.PaymentTypeName });
                paymentType = await paymentTypeRepository.GetByNameAsync(request.PaymentTypeName);
                if (paymentType != null)
                {
                    paymentTypeId = paymentType.Id;
                }
            }
            var paymentMethod = mapper.Map<PaymentMethod>(request);
            paymentMethod.PaymentTypeId = paymentTypeId;
            return await paymentMethodRepository.InsertAsync(paymentMethod);
        }

        public async Task<int> DeletePaymentAsync(int id)
        {
            return await paymentMethodRepository.DeleteAsync(id);
        }

        public async Task<int> UpdatePaymentAsync(PaymentRequestModel request)
        {
            var paymentMethod = mapper.Map<PaymentMethod>(request);
            return await paymentMethodRepository.UpdateAsync(paymentMethod);
        }
    }
}
