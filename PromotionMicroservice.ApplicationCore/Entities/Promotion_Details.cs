using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PromotionMicroservice.ApplicationCore.Entities
{
    public class Promotion_Details
    {
        public int Id { get; set; }
        public int Promotion_Id { get; set; }
        public int Product_Category_Id { get; set; }
        public string Product_Category_Name { get; set; } = string.Empty;

        // Navigation property
        public Promotion Promotion { get; set; } = null!;
    }
}
