using MarketFaith.Models;
using MarketFaith.Views;

using System.Xml;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Graphics;
using MarketFaith.Services;
using System.Security.Cryptography.X509Certificates;
using Newtonsoft.Json;

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

}
