using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketFaith.Models
{
    public class Order
    {
        public int userid { get; set; }
        public int[] productids { get; set; }
        public int[] productquantities { get; set; }
        public decimal TotalAmount { get; set; }
    }
}
