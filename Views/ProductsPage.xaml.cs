using MarketFaith.Models;

using System.Xml;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Graphics;
using MarketFaith.Services;
using System.Security.Cryptography.X509Certificates;
using Newtonsoft.Json;

namespace MarketFaith.Views;


public partial class ProductsPage : ContentPage
{
    private decimal cartTotal = 0;
    private const string ApiBaseUrl = "http://127.0.0.1:8000/api/produits";
    List<Product> products;

    public ProductsPage(Categorie selectedCategorie)
    {
        InitializeComponent();


        // Obtenir les produits de la categorie sélectionnée 
        LoadProducts(selectedCategorie);
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

    public async void LoadProducts(Categorie selectedCategorie)
    {
        try
        {
            using (HttpClient client = new HttpClient())
            {
                string apiUrl = $"{ApiBaseUrl}/{selectedCategorie.id}";

                HttpResponseMessage response = await client.GetAsync(apiUrl);

                if (response.IsSuccessStatusCode)
                {
                    string json = await response.Content.ReadAsStringAsync();
                    products = JsonConvert.DeserializeObject<List<Product>>(json);

                    // Faites quelque chose avec le produit récupéré, par exemple, l'afficher dans les contrôles de la page

                    // Assigner les magasins à la source de données du CollectionView
                    int count1 = 0;
                    foreach(Product product in products)
                    {
                        if (count1>=5)
                        {
                            break;
                        }
                        var productView1 = CreateProductView(product);
                        // Section 1
                        section1Layout.Children.Add(productView1);
                        count1++;
                    }

                    int count2 = 0;
                    foreach (Product product in products.Skip(5))
                    {
                        if (count2 >= 5)
                        {
                            break;
                        }
                        var productView2 = CreateProductView(product);
                        // Section 2
                        section2Layout.Children.Add(productView2);
                        count2++;
                    }

                }
                else
                {
                    // Gérez l'erreur de la requête HTTP, par exemple, affichez un message d'erreur approprié
                    Console.WriteLine($"Erreur lors de la récupération des enseignes. Code de statut : {response.StatusCode}");
                }
            }
        }
        catch (Exception ex)
        {
            // Gérez les exceptions, par exemple, affichez un message d'erreur approprié
            Console.WriteLine($"Erreur lors de la récupération des enseignes : {ex.Message}");
        }

    }

    private View CreateProductView(Product product)
    {
        var image = new Image
        {
            Source = product.avatar,
            HeightRequest = 100,
            WidthRequest = 100,
            Aspect = Aspect.AspectFit
        };

        var nameLabel = new Label
        {
            Margin = new Thickness(10, 30, 0, 0),
            Text = product.name,
            HorizontalTextAlignment = TextAlignment.Start,
            FontAttributes = FontAttributes.Bold,
            TextColor = Color.FromArgb("#4e69a6")
        };

        var prixLabel = new Label
        {
            Margin = new Thickness(10, 14, 0, 0),
            Text = $"{product.prix:C}",
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
        prixLabel.GestureRecognizers.Add(productTapGestureRecognizer);


        var productLayout = new StackLayout
        {
            Orientation = StackOrientation.Vertical,
            HorizontalOptions = LayoutOptions.Center,
            BackgroundColor = Colors.White,
            HeightRequest = 265,
            WidthRequest = 170,
            Margin = new Thickness(0, 15, 5, 0),
            Children =
            {
                addButton,
                image,
                nameLabel,
                prixLabel,
            }
        };

        return productLayout;
    }

    private void AddToCart_Clicked(Product product)
    {
        // Ajouter le produit au panier
        CartManager.AddToCart(product);
        // Ajoutez ici la logique pour ajouter le produit au panier

        cartTotal += product.prix;

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