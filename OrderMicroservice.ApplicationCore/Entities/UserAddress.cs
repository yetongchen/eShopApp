using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderMicroservice.ApplicationCore.Entities
{
    public class UserAddress
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public int AddressId { get; set; }
        public bool IsDefaultAddress { get; set; }

        public required Customer Customer { get; set; }
        public required Address Address { get; set; }
    }
}
