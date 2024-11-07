﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductMicroservice.ApplicationCore.Models.Request
{
    public class VariationValueRequestModel
    {
        public int Id { get; set; }
        public int Variation_Id { get; set; }
        public string Value { get; set; } = string.Empty;
    }
}
