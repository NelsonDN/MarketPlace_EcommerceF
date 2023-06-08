using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketFaith.Models
{
    public class CartItem : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public Product Product { get; set; }

        private int quantity;
        public int Quantity 
        {  
            get { return quantity; }
            set
            {
                if (quantity != value)
                {
                    quantity = value;
                    OnPropertyChanged(nameof(Quantity));
                }
            }
        }

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }

}
