using MarketFaith.Models;
using MarketFaith.ViewModels;
using MarketFaith.Views;
namespace MarketFaith.Views;

public partial class ProduitsPage : ContentPage
{
    public ProduitsPage(List<Produit> produits)
    {
        InitializeComponent();
        BindingContext = new ProduitsViewModel(produits);
    }

    private void AjouterAuPanier_Clicked(object sender, EventArgs e)
    {
        var button = (Button)sender;
        var produit = (Produit)button.BindingContext;

        var panierViewModel = (PanierViewModel)Application.Current.Resources["PanierViewModel"];
        panierViewModel.AjouterProduit(produit);
    }
}
