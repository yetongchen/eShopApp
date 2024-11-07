using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PromotionMicroservice.ApplicationCore.Models.Request
{
    public class PromotionRequestModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is required.")]
        [MaxLength(256, ErrorMessage = "Name cannot exceed 256 characters.")]
        [MinLength(2, ErrorMessage = "Name must be at least 2 characters long.")]
        public string Name { get; set; } = string.Empty;

        [Required(ErrorMessage = "Description is required.")]
        [MaxLength(5000, ErrorMessage = "Description cannot exceed 5000 characters.")]
        [MinLength(0, ErrorMessage = "Description must be at least 0 characters long.")]
        public string Description { get; set; } = string.Empty;

        [Required(ErrorMessage = "Discount is required.")]
        [Range(0.01, 100, ErrorMessage = "Discount must be between 0.01 and 100.")]
        public decimal Discount { get; set; }

        [Required(ErrorMessage = "Start Date is required.")]
        public DateTime Start_Date { get; set; }

        [Required(ErrorMessage = "End Date is required.")]
        public DateTime End_Date { get; set; }
    }
}
