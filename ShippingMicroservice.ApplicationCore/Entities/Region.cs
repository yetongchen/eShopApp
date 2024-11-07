using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShippingMicroservice.ApplicationCore.Entities
{
    public class Region
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;

        // Navigation property
        public ICollection<Shipper_Region> Shipper_Regions { get; set; } = [];
    }
}
