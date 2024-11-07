using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductMicroservice.ApplicationCore.Entities
{
    public class Variation_Value
    {
        public int Id { get; set; }
        public int Variation_Id { get; set; }
        public string Value { get; set; } = string.Empty;

        public Category_Variation Variation { get; set; } = null!;
        public ICollection<Product_Variation_Values> Product_Variation_Values { get; set; } = [];
    }
}
