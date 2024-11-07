using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductMicroservice.ApplicationCore.Models.Request
{
    public class ProductVariationRequestModel
    {
        public int Product_Id { get; set; }
        public int Variation_Value_Id { get; set; }
    }
}
