using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductMicroservice.ApplicationCore.Models.Response
{
    public class ProductVariationResponseModel
    {
        public int Product_Id { get; set; }
        public int Variation_Value_Id { get; set; }
    }
}
