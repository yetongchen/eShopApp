using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductMicroservice.ApplicationCore.Entities
{
    public class Category_Variation
    {
        public int Id { get; set; }
        public int Category_Id { get; set; }
        public string Variation_Name { get; set; } = string.Empty;

        public Product_Category Category { get; set; } = null!;
        public ICollection<Variation_Value> Variation_Values { get; set; } = [];
    }
}
