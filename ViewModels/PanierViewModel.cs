using MarketFaith.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MarketFaith.ViewModels
{
    public class PanierViewModel
    {
        public ObservableCollection<ProduitPanier> ProduitsPanier { get; set; }

        public decimal CoutTotal => ProduitsPanier.Sum(p => p.Prix * p.Quantite);

        public PanierViewModel()
        {
            ProduitsPanier = new ObservableCollection<ProduitPanier>();
        }

        public void AjouterProduit(Produit produit)
        {
            var produitPanier = ProduitsPanier.FirstOrDefault(p => p.Nom == produit.Nom);
            if (produitPanier != null)
            {
                produitPanier.Quantite++;
            }
            else
            {
                ProduitsPanier.Add(new ProduitPanier
                {
                    Nom = produit.Nom,
                    Image = produit.Image,
                    Prix = produit.Prix,
                    Quantite = 1
                });
            }
        }

        public void ModifierQuantite(ProduitPanier produitPanier, int nouvelleQuantite)
        {
            produitPanier.Quantite = nouvelleQuantite;
        }
    }
}
