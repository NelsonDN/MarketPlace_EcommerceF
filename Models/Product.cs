using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketFaith.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ImagePath { get; set; }
        public decimal Price { get; set; }

        public Product( int id, string name, string imagePath, decimal price)
        {
            Id = id;
            Name = name;
            ImagePath = imagePath;
            Price = price;
        }
    }
}
