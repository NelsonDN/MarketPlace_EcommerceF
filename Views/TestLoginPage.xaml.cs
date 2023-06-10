using System.Security.Cryptography.X509Certificates;
using MarketFaith.Models;
namespace MarketFaith.Views;

public partial class TestLoginPage : ContentPage
{
	public TestLoginPage()
	{
		InitializeComponent();

        // Créer une liste d'enseignes
        var stores = new List<Store>
            {
                new Store
                {
                    Name = "Enseigne 1",
                    ImageUrl = "avion.png",
                    OpenHours = "Lun - Ven: 8h - 20h"
                },
                new Store
                {
                    Name = "Enseigne 2",
                    ImageUrl = "market.png",
                    OpenHours = "Lun - Ven: 9h - 21h"
                },
                new Store
                {
                    Name = "Enseigne 3",
                    ImageUrl = "avion.png",
                    OpenHours = "Lun - Ven: 8h30 - 19h30"
                },
                new Store
                {
                    Name = "Enseigne 4",
                    ImageUrl = "logo1.png",
                    OpenHours = "Lun - Ven: 7h30 - 22h"
                },
                new Store
                {
                    Name = "Enseigne 5",
                    ImageUrl = "voiture.png",
                    OpenHours = "Lun - Ven: 9h - 20h"
                },
                new Store
                {
                    Name = "Enseigne 6",
                    ImageUrl = "avion.png",
                    OpenHours = "Lun - Ven: 8h - 21h"
                }
            };

        // Assigner la liste d'enseignes à la source de données du ListView
        StoreListView.ItemsSource = stores;
    }

    private void OnStoreSelected(object sender, SelectedItemChangedEventArgs e)
    {
        if (e.SelectedItem == null)
            return;

        var selectedStore = (Enseigne)e.SelectedItem;

        // Rediriger vers la page des magasins de l'enseigne sélectionnée
        Navigation.PushAsync(new StorePage(selectedStore));

        // Désélectionner l'élément du ListView
        StoreListView.SelectedItem = null;
    }


}