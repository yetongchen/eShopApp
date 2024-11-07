using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReviewMicroservice.ApplicaitonCore.Models.Request
{
    public class CustomerReviewRequestModel
    {
        public int Id { get; set; }
        public int? Customer_Id { get; set; }

        [Required]
        [StringLength(256, MinimumLength = 2)]
        public string Customer_Name { get; set; } = string.Empty;
        public int? Order_Id { get; set; }

        [Required]
        public DateTime Order_Date { get; set; }
        public int? Product_Id { get; set; }
        [Required]
        [StringLength(255, MinimumLength = 2)]
        public string Product_Name { get; set; } = string.Empty;
        public double Rating_Value { get; set; }

        [Required]
        [StringLength(500, MinimumLength = 2)]
        public string Comment { get; set; } = string.Empty;

        [Required]
        public DateTime Review_Date { get; set; }
        public bool? IsApproved { get; set; }
    }
}
