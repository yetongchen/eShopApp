using OrderMicroservice.ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderMicroservice.ApplicationCore.Models.Request
{
    public class PaymentRequestModel
    {
        public int Id { get; set; }
        public int PaymentTypeId { get; set; }
        public string Provider { get; set; } = string.Empty;
        public string AccountNumber { get; set; } = string.Empty;
        public DateTime Expiry { get; set; }
        public bool IsDefault { get; set; }
        public int CustomerId { get; set; }

        public string PaymentTypeName { get; set; } = string.Empty;
    }
}
