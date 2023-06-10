using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MarketFaith.Models;


namespace MarketFaith.Services
{
    public static class CartManager
    {
        private static List<CartItem> cartItems;

        static CartManager()
        {
            cartItems = new List<CartItem>();
        }

        public static void AddToCart(Product product)
        {
            // Vérifier si le produit est déjà dans le panier
            var existingItem = cartItems.Find(item => item.Product.id == product.id);

            if (existingItem != null)
            {
                // Si le produit existe déjà dans le panier, augmenter la quantité
                existingItem.Quantity++;
            }
            else
            {
                // Sinon, créer un nouvel élément dans le panier
                var newItem = new CartItem
                {
                    Product = product,
                    Quantity = 1
                };
                cartItems.Add(newItem);
            }
        }

        public static void RemoveFromCart(CartItem cartItem)
        {
            cartItems.Remove(cartItem);
        }

        public static List<CartItem> GetCartItems()
        {
            return cartItems;
        }

        public static void ClearCart()
        {
            cartItems.Clear();
        }
        
        public static decimal GetTotalAmount()
        {
            decimal totalAmount = 0;
            foreach (var item in cartItems)
            {
                totalAmount += item.Product.prix * item.Quantity;
            }
            return totalAmount;
        }

        public static bool IsCartEmpty()
        {
            return cartItems.Count == 0;
        }
    }
}
