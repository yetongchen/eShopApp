using ShippingMicroservice.ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShippingMicroservice.ApplicationCore.Models.Request
{
    public class ShipperDetailsRequestModel
    {
        public int Id { get; set; }
        public int Order_Id { get; set; }
        public int Shipper_Id { get; set; }
        public string? Shipping_Status { get; set; }
        public string? Tracking_Number { get; set; }
    }
}
