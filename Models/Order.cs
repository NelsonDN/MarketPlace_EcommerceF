using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketFaith.Models
{
    public class Order
    {
        public List<CartItem> Items { get; set; }
        public decimal TotalAmount { get; set; }
    }
}
