using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperstoreTool.Model
{
    [MetadataType(typeof(Product))]
    public class YearSales
    {
        [Display(Order = 0)]
        public string State { get; set; }
        
        [Display(Order = 1)]
        public int? SaleYear { get; set; }
        [Display(Order = 2)]
        public Double? Sales { get; set; }
        [Display(Order = 3)]
        public Double? Increment { get; set; }
        [Display(Order = 4)]
        public Double? IncreaseSales { get; set; }
    }
}
