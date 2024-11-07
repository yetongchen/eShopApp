using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShippingMicroservice.ApplicationCore.Entities
{
    public class Shipper_Region
    {
        public int Region_Id { get; set; }
        public Region Region { get; set; } = null!;

        public int Shipper_Id { get; set; }
        public Shipper Shipper { get; set; } = null!;

        public bool Active { get; set; }
    }
}
