using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderMicroservice.ApplicationCore.Entities
{
    public class PaymentMethod
    {
        public int Id { get; set; }
        public int PaymentTypeId { get; set; }
        public string Provider { get; set; } = string.Empty;
        public string AccountNumber { get; set; } = string.Empty;
        public DateTime Expiry { get; set; }
        public bool IsDefault { get; set; }
        public int CustomerId { get; set; }

        public PaymentType? PaymentType { get; set; }
    }
}
