using MarketFaith.Models;
using MarketFaith.Views;

namespace MarketFaith.Views;

public partial class ProductDetailPage : ContentPage
{
	public ProductDetailPage()
	{
		InitializeComponent();
	}

    public ProductDetailPage(Product product)
    {
        InitializeComponent();
        BindingContext = product;
    }

    private void AddToCart_Clicked(object sender, EventArgs e)
    {
        var product = (Product)BindingContext;
        // Ajoutez ici la logique pour ajouter le produit au panier
    }
}
