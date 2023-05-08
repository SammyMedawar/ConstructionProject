using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Construction
{
    public class Receipt
    {
        public int ID { get; set; }
        public string MaterialName { get; set; }
        public double Quantity { get; set; }
        public double PriceEach { get; set; }
        public double PriceOther { get; set; }
        public double TotalPrice { get; set; }
        public string CompanyName { get; set; }
    }
}
