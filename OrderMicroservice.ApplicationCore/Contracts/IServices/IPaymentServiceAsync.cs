using OrderMicroservice.ApplicationCore.Models.Request;
using OrderMicroservice.ApplicationCore.Models.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderMicroservice.ApplicationCore.Contracts.IServices
{
    public interface IPaymentServiceAsync
    {
        Task<IEnumerable<PaymentResponseModel>> GetPaymentsByCustomerIdAsync(int customerId);
        Task<int> SavePaymentAsync(PaymentRequestModel request);
        Task<int> DeletePaymentAsync(int id);
        Task<int> UpdatePaymentAsync(PaymentRequestModel request);
    }
}
