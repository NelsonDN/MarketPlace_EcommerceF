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

        // Charger les produits associés à la catégorie depuis une source de données (par exemple, une base de données)

        var produits = new List<Produit>
        {
            new Produit { Nom = "Produit 1", Image = "market.png", Prix = 10.99m, Quantite = 0 },
            new Produit { Nom = "Produit 2", Image = "medaille.png", Prix = 15.99m, Quantite = 0 },
            new Produit { Nom = "Produit 3", Image = "etoile.png", Prix = 8.99m, Quantite = 0 }
        };

        await Navigation.PushAsync(new ProduitsPage(produits));
    }
}
