using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductMicroservice.ApplicationCore.Models.Request
{
    public class CategoryRequestModel
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public int? Parent_Category_Id { get; set; }
    }
}
