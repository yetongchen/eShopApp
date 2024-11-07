using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderMicroservice.ApplicationCore.Entities
{
    public class Address
    {
        public int Id { get; set; }
        public string Street1 { get; set; } = string.Empty;
        public string Street2 { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;
        public string Zipcode { get; set; } = string.Empty;
        public string State { get; set; } = string.Empty;
        public string Country { get; set; } = string.Empty;

        public ICollection<UserAddress> UserAddresses { get; set; } = [];
    }
}
