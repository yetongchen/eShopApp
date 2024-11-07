using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShippingMicroservice.ApplicationCore.Models.Request
{
    public class ShipperRequestModel
    {
        public int Id { get; set; }

        [Required]
        [StringLength(256, MinimumLength = 2)]
        public string Name { get; set; } = string.Empty;

        [EmailAddress]
        [StringLength(255)]
        public string? EmailId { get; set; }

        [RegularExpression(@"^\d{10}$", ErrorMessage = "Phone number must be 10 digits")]
        public string? Phone { get; set; }

        [Required]
        [StringLength(256, MinimumLength = 2)]
        public required string ContactPerson { get; set; }
    }

}
