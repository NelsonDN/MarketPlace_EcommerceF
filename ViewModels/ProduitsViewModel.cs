using MarketFaith.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketFaith.ViewModels
{
    public class ProduitsViewModel
    {
        public ObservableCollection<Produit> Produits { get; set; }

        public ProduitsViewModel(List<Produit> produits)
        {
            Produits = new ObservableCollection<Produit>(produits);
        }
    }
}
