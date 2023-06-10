
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
        await DisplayAlert("Commande", "Votre commande a été passée avec succès !", "OK");

        /*
         * 
         * // Ajoutez ici la logique pour passer la commande à partir du panier  PUBLIC STATIC ASYNC Task<bool> PlaceOrder()
        // Récupérer les produits du panier
        var cartItems = CartManager.GetCartItems();

        // Créer un objet pour la commande
        var order = new Order
        {
            Items = cartItems,
            TotalAmount = CartManager.GetTotalAmount()
        };

        // Convertir la commande en JSON
        var jsonOrder = JsonSerializer.Serialize(order);

        // Envoyer la commande à l'API
        using (var client = new HttpClient())
        {
            var response = await client.PostAsync("https://votre-api.com/commandes", new StringContent(jsonOrder, System.Text.Encoding.UTF8, "application/json"));

            if (response.IsSuccessStatusCode)
            {
                // La commande a été envoyée avec succès
                CartManager.ClearCart();
                return true;
            }
            else
            {
                // Erreur lors de l'envoi de la commande
                return false;
            }
        }*/

    }

    //private async void GoBack_Clicked(object sender, EventArgs e)
    //{
    //    // Vérifiez si le panier contient des produits
    //    if (cartItems.Count > 0)
    //    {
    //        var answer = await DisplayAlert("Attention", "Si vous quittez cette page, votre panier sera vidé. Êtes-vous sûr de vouloir continuer ?", "Oui", "Non");

    //        if (answer)
    //        {
    //            CartManager.ClearCart();
    //            await Navigation.PopAsync();
    //        }
    //    }
    //    else
    //    {
    //        await Navigation.PopAsync();
    //    }
    //}
}