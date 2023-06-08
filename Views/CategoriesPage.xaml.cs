using MarketFaith.Models;
using MarketFaith.ViewModels;
using MarketFaith.Views;

namespace MarketFaith.Views;

public partial class CategoriesPage : ContentPage
{
    public CategoriesPage()
    {
        InitializeComponent();
        BindingContext = new CategoriesViewModel();
    }

    private async void AfficherProduits_Clicked(object sender, EventArgs e)
    {
        var button = (Button)sender;
        var categorie = (Categorie)button.BindingContext;

        // Charger les produits associ�s � la cat�gorie depuis une source de donn�es (par exemple, une base de donn�es)

        var produits = new List<Produit>
        {
            new Produit { Nom = "Produit 1", Image = "market.png", Prix = 10.99m, Quantite = 0 },
            new Produit { Nom = "Produit 2", Image = "medaille.png", Prix = 15.99m, Quantite = 0 },
            new Produit { Nom = "Produit 3", Image = "etoile.png", Prix = 8.99m, Quantite = 0 }
        };

        await Navigation.PushAsync(new ProduitsPage(produits));
    }
}
