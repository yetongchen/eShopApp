using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReviewMicroservice.ApplicaitonCore.Models.Response
{
    public class CustomerReviewResponseModel
    {
        public int Id { get; set; }
        public int Customer_Id { get; set; }
        public string Customer_Name { get; set; } = string.Empty;
        public int Order_Id { get; set; }
        public DateTime Order_Date { get; set; }
        public int Product_Id { get; set; }
        public string Product_Name { get; set; } = string.Empty;
        public double Rating_Value { get; set; }
        public string Comment { get; set; } = string.Empty;
        public DateTime Review_Date { get; set; }
        public bool? IsApproved { get; set; }
    }
}
