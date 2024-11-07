using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShippingMicroservice.ApplicationCore.Entities
{
    public class Shipper_Details
    {
        public int Id { get; set; }
        public int Order_Id { get; set; }
        public int Shipper_Id { get; set; }
        public string? Shipper_Status { get; set; }
        public string? Tracking_Number { get; set; }

        public Shipper? Shipper { get; set; }
    }
}
