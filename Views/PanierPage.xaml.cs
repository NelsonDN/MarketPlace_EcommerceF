using MarketFaith.ViewModels;
using MarketFaith.Models;

namespace MarketFaith.Views;

public partial class PanierPage : ContentPage
{
    public PanierPage()
    {
        InitializeComponent();
        BindingContext = Application.Current.Resources["PanierViewModel"];
    }

    private void ModifierQuantite_Clicked(object sender, EventArgs e)
    {
        var button = (Button)sender;
        var produitPanier = (ProduitPanier)button.BindingContext;

        // Afficher un dialogue/modal pour permettre à l'utilisateur de modifier la quantité
        // et mettre à jour le panier en conséquence
    }
}
