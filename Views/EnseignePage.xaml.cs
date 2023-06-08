
using MarketFaith.Models;

namespace MarketFaith.Views;

public partial class EnseignePage : ContentPage
{
	public EnseignePage()
	{
		InitializeComponent();
        // Créer une liste d'enseignes
        var stores = new List<Store>
            {
                new Store
                {
                    Name = "Santa Lucia",
                    ImageUrl = "santalucia.png",
                    OpenHours = "Lun - Ven: 8h - 20h"
                },
                new Store
                {
                    Name = "BAO",
                    ImageUrl = "bao.png",
                    OpenHours = "Lun - Ven: 9h - 21h"
                },
                new Store
                {
                    Name = "Carrefour",
                    ImageUrl = "carrefour.png",
                    OpenHours = "Lun - Ven: 8h30 - 19h30"
                },
                new Store
                {
                    Name = "DOVV",
                    ImageUrl = "dovv.png",
                    OpenHours = "Lun - Ven: 7h30 - 22h"
                },
                new Store
                {
                    Name = "Mahima",
                    ImageUrl = "mahima.png",
                    OpenHours = "Lun - Ven: 9h - 20h"
                }
            };

        // Assigner la liste d'enseignes à la source de données du ListView
        StoreListView.ItemsSource = stores;
    }

    private void OnStoreSelected(object sender, SelectedItemChangedEventArgs e)
    {
        if (e.SelectedItem == null)
            return;

        var selectedStore = (Store)e.SelectedItem;

        // Rediriger vers la page des magasins de l'enseigne sélectionnée
        Navigation.PushAsync(new StorePage(selectedStore));

        // Désélectionner l'élément du ListView
        StoreListView.SelectedItem = null;
    }
}