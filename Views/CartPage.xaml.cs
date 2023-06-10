
using MarketFaith.Models;
using System;
using System.Collections.ObjectModel;
using MarketFaith.Services;
using System.Text.Json;
using System.Net.Http;

namespace MarketFaith.Views;
public partial class CartPage : ContentPage
{
    private ObservableCollection<CartItem> cartItems;
    private decimal cartTotal;
    public int cartItemsCount;

    public CartPage()
    {
        InitializeComponent();
        cartItems = new ObservableCollection<CartItem>();
        cartItemsCount = cartItems.Count;
        if (cartItemsCount > 1 )
        {
            monPanier.Text = $"{cartItemsCount} produits";
        }
        else
        {
            monPanier.Text = $"{cartItemsCount} produit";
        }
        cartListView.ItemsSource = cartItems;
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        LoadCartItems();
        cartItemsCount = cartItems.Count;
        if (cartItemsCount > 1)
        {
            monPanier.Text = $"{cartItemsCount} produits";
        }
        else
        {
            monPanier.Text = $"{cartItemsCount} produit";
        }
        CalculateTotal();
    }

    private void LoadCartItems()
    {
        var cartItemsCopy = new List<CartItem>(CartManager.GetCartItems());

        foreach (var item in cartItemsCopy)
        {
            cartItems.Add(item);
        }
    }

    private void IncreaseQuantity_Clicked(object sender, EventArgs e)
    {
        var button = (Button)sender;
        var cartItem = button.CommandParameter as CartItem;
        cartItem.Quantity++;
        CalculateTotal();
    }

    private void DecreaseQuantity_Clicked(object sender, EventArgs e)
    {
        var button = (Button)sender;
        var cartItem = button.CommandParameter as CartItem;
        if (cartItem.Quantity > 1)
        {
            cartItem.Quantity--;
            CalculateTotal();
        }

    }

    private void CalculateTotal()
    {
        cartTotal = 0;
        foreach (var item in cartItems)
        {
            cartTotal += item.Product.prix * item.Quantity;
        }

        cartTotalLabel.Text = $"{cartTotal:C}";
    }

    private async void PlaceOrder_Clicked(object sender, EventArgs e)
    {
        int userid = Preferences.Get("UserId", 0);


        // R�cup�rer les noms des produits et les quantit�s
        int[] productids = cartItems.Select(item => item.Product.id).ToArray();
        int[] productquantities = cartItems.Select(item => item.Quantity).ToArray();

        // Cr�er un objet pour la commande
        var order = new Order
        {
            userid = userid,
            productids = productids,
            productquantities = productquantities,
            TotalAmount = CartManager.GetTotalAmount()
        };

        // Convertir la commande en JSON
        var jsonOrder = JsonSerializer.Serialize(order);

        try
        {

            // Envoyer la commande � l'API
                using (var client = new HttpClient())
            {
                var response = await client.PostAsync("http://127.0.0.1:8000/api/commande", new StringContent(jsonOrder, System.Text.Encoding.UTF8, "application/json"));

                if (response.IsSuccessStatusCode)
                {
                    // La commande a �t� envoy�e avec succ�s
                    CartManager.ClearCart();
                    
                    await DisplayAlert("Commande", "Votre commande a �t� pass�e avec succ�s !", "OK");

                    await this.Navigation.PushAsync(new CommandeSuccessPage());
                }
                else
                {
                    // Erreur lors de l'envoi de la commande
                    await DisplayAlert("Erreur", "Erreur lors de l'envoi de la commande !", "OK");

                }
            }
        }
        catch (Exception ex)
        {
            // G�rez les exceptions, par exemple, affichez un message d'erreur appropri�
            Console.WriteLine($"Erreur lors de la r�cup�ration des enseignes : {ex.Message}");
        }
    }

}