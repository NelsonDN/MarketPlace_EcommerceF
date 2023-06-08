using MarketFaith.Models;

using System.Xml;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Graphics;
using MarketFaith.Services;

namespace MarketFaith.Views;


public partial class ProductsPage : ContentPage
{
    private decimal cartTotal = 0;

    public ProductsPage()
    {
        InitializeComponent();

        LoadProducts();
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();

        if (CartManager.IsCartEmpty())
        {
            cartTotal = 0;
        }

        UpdateCartTotal();
    }

    private void LoadProducts()
    {
        // Exemple de produits
        var product1 = new Product(1, "Produit 1", "voiture.png", 10.99m);
        var product2 = new Product(2, "Produit 2", "avion.png", 19.99m);
        var product3 = new Product(3, "Produit 2", "voiture.png", 19.99m);
        var product4 = new Product(4, "Produit 2", "avion.png", 19.99m);
        var product5 = new Product(5, "Produit 2", "voiture.png", 19.99m);
        var product6 = new Product(6, "Produit 2", "avion.png", 19.99m);

        // Section 1
        var productView1 = CreateProductView(product1);
        var productView2 = CreateProductView(product2);
        var productView3 = CreateProductView(product3);
        var productView4 = CreateProductView(product4);
        var productView5 = CreateProductView(product5);
        var productView6 = CreateProductView(product6);
        var productView7 = CreateProductView(product6);
        var productView8 = CreateProductView(product6);
        var productView9 = CreateProductView(product6);

        section1Layout.Children.Add(productView1);
        section1Layout.Children.Add(productView2);
        section1Layout.Children.Add(productView3);
        section1Layout.Children.Add(productView4);
        section1Layout.Children.Add(productView5);
        section1Layout.Children.Add(productView7);
        section1Layout.Children.Add(productView8);
        section1Layout.Children.Add(productView9);

        // Section 2
        var productView10 = CreateProductView(product1);
        var productView11 = CreateProductView(product2);
        var productView12 = CreateProductView(product2);
        var productView13 = CreateProductView(product2);

        section2Layout.Children.Add(productView10);
        section2Layout.Children.Add(productView6);
        section2Layout.Children.Add(productView11);
        section2Layout.Children.Add(productView12);
        section2Layout.Children.Add(productView13);

        var productView21 = CreateProductView(product1);
        var productView22 = CreateProductView(product2);
        var productView23 = CreateProductView(product2);
        var productView24 = CreateProductView(product2);

        // Section  3
        section3Layout.Children.Add(productView21);
        section3Layout.Children.Add(productView22);
        section3Layout.Children.Add(productView23);
        section3Layout.Children.Add(productView24);
    }

    private View CreateProductView(Product product)
    {
        var image = new Image
        {
            Source = product.ImagePath,
            HeightRequest = 100,
            WidthRequest = 100,
            Aspect = Aspect.AspectFit
        };

        var nameLabel = new Label
        {
            Margin = new Thickness(10, 30, 0, 0),
            Text = product.Name,
            HorizontalTextAlignment = TextAlignment.Start,
            FontAttributes = FontAttributes.Bold,
            TextColor = Color.FromArgb("#4e69a6")
        };

        var priceLabel = new Label
        {
            Margin = new Thickness(10, 14, 0, 0),
            Text = $"{product.Price:C}",
            HorizontalTextAlignment = TextAlignment.Start,
            FontAttributes= FontAttributes.Bold,
            TextColor = Colors.IndianRed,
        };

        var addButton = new ImageButton
        {
            Source = "cart32.png",
            CornerRadius = 10,
            Aspect = Aspect.AspectFit,
            HeightRequest = 20,
            WidthRequest = 25,
            BackgroundColor = Colors.Transparent,
            HorizontalOptions = LayoutOptions.End,
            Margin = new Thickness(0, 10, 18, 0)
        };

        addButton.Clicked += (sender, e) => AddToCart_Clicked(product);

        var productTapGestureRecognizer = new TapGestureRecognizer();
        productTapGestureRecognizer.Tapped += (s, e) => GoToProductDetail(product);


        image.GestureRecognizers.Add(productTapGestureRecognizer);
        nameLabel.GestureRecognizers.Add(productTapGestureRecognizer);
        priceLabel.GestureRecognizers.Add(productTapGestureRecognizer);


        var productLayout = new StackLayout
        {
            Orientation = StackOrientation.Vertical,
            HorizontalOptions = LayoutOptions.Center,
            BackgroundColor = Colors.White,
            HeightRequest = 245,
            WidthRequest = 160,
            Margin = new Thickness(0, 15, 5, 0),
            Children =
            {
                addButton,
                image,
                nameLabel,
                priceLabel,
            }
        };

        return productLayout;
    }

    private void AddToCart_Clicked(Product product)
    {
        // Ajouter le produit au panier
        CartManager.AddToCart(product);
        // Ajoutez ici la logique pour ajouter le produit au panier

        cartTotal += product.Price;

        UpdateCartTotal();
    }

    private void UpdateCartTotal()
    {
        // var cartToolbarItem = (ToolbarItem)this.ToolbarItems[0];
        decimal cartTotal = CartManager.GetTotalAmount();
        cartButton.Text = $"{cartTotal:C}";
    }

    private void GoToProductDetail(Product product)
    {
        Navigation.PushAsync(new ProductDetailPage(product));
    }

    private void GoToCartPage_Clicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new CartPage());
    }

}