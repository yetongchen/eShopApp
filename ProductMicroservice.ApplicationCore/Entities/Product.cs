﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductMicroservice.ApplicationCore.Entities
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public int CategoryId { get; set; }
        public decimal Price { get; set; }
        public int Qty { get; set; }
        public string Product_Image { get; set; } = string.Empty;
        public string SKU { get; set; } = string.Empty;
        public bool? IsActive { get; set; }

        public Product_Category Category { get; set; } = null!;
        public ICollection<Product_Variation_Values> Product_Variation_Values { get; set; } = [];
    }

}