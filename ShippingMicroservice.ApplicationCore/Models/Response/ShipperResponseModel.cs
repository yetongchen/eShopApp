using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShippingMicroservice.ApplicationCore.Models.Response
{
    public class ShipperResponseModel
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? EmailId { get; set; }
        public string? Phone { get; set; }
        public string ContactPerson { get; set; } = string.Empty;
        public string ShippingStatus { get; set; } = string.Empty;
    }

}
