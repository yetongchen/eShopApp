using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShippingMicroservice.ApplicationCore.Entities
{
    public class Shipper
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? EmailId { get; set; }
        public string? Phone { get; set; }
        public string? Contact_Person { get; set; }

        // Navigation property
        public ICollection<Shipper_Region> Shipper_Regions { get; set; } = [];
        public ICollection<Shipper_Details> Shipping_Details { get; set; } = [];
    }
}
