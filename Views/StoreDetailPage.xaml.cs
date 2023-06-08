using System.Security.Cryptography.X509Certificates;
using MarketFaith.Models;

namespace MarketFaith.Views;

public partial class StoreDetailPage : ContentPage
{
	public StoreDetailPage()
	{

		InitializeComponent();
	}
    public StoreDetailPage(Models.Location selectedLocation)
    {
        InitializeComponent();

        // Afficher les détails du magasin sélectionné
        ImageUrl.Source = selectedLocation.ImageUrl;
        StoreName.Text = selectedLocation.StoreName;
        LocationName.Text = selectedLocation.LocationName;
        OpeningHours.Text = selectedLocation.OpeningHours;
        // Ajoutez d'autres détails du magasin en fonction de vos besoins
    }
}