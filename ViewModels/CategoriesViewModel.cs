using MarketFaith.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace MarketFaith.ViewModels
{
    public class CategoriesViewModel
    {
        public ObservableCollection<Categorie> Categories { get; set; }

        public CategoriesViewModel()
        {
            Categories = new ObservableCollection<Categorie>();
            // Ajoutez des catégories de test
            Categories.Add(new Categorie { Nom = "Catégorie 1", Image = "voiture.png" });
            Categories.Add(new Categorie { Nom = "Catégorie 2", Image = "avion.png" });
        }
    }
}
