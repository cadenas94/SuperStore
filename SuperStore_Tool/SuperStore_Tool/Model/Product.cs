using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperstoreTool.Model
{
    [MetadataType(typeof(Product))]
    public class Product
    {
        [Display(Order = 0)]
        public string OrderId { get; set; }
        [Display(Order = 1)]
        public string ProductId { get; set; }
        [Display(Order = 2)]
        public string Category { get; set; }
        [Display(Order = 3)]
        public string SubCategory { get; set; }
        [Display(Order = 4)]
        public string ProductName { get; set; }
        [Display(Order = 5)]
        public Double? Sales { get; set; }
        [Display(Order = 6)]
        public Double? Quantity { get; set; }
        [Display(Order = 7)]
        public Double? Discount { get; set; }
        [Display(Order = 8)]
        public Double? Profit { get; set; }
    }
}
