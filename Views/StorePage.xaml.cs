using MarketFaith.Models;
using MarketFaith.Views;

namespace MarketFaith.Views;

public partial class StorePage : ContentPage
{

    public StorePage(Models.Store selectedStore)
    {
        InitializeComponent();

        // Afficher le nom de l'enseigne s�lectionn�e
        StoreName.Text = selectedStore.Name;

        // Obtenir les magasins de l'enseigne s�lectionn�e (supposons qu'il s'agit d'une liste de magasins)
        var storeLocations = GetStoreLocations(selectedStore);

        // Assigner les magasins � la source de donn�es du CollectionView                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                     
        StoreCollectionView.ItemsSource = storeLocations;
    }

    private void OnLocationSelected(object sender, SelectionChangedEventArgs e)
    {
        if (e.CurrentSelection == null || e.CurrentSelection.Count == 0)
            return;

        var selectedLocation = (Models.Location)e.CurrentSelection[0];

        // Rediriger vers la page du magasin s�lectionn�
        //
        // Navigation.PushAsync(new StoreDetailPage(selectedLocation));
        Navigation.PushAsync(new ProductsPage());

        // D�s�lectionner l'�l�ment de la CollectionView
        StoreCollectionView.SelectedItem = null;
    }

    private List<Models.Location> GetStoreLocations(Store selectedStore)
    {
        // Ici, vous devez impl�menter la logique pour r�cup�rer les magasins de l'enseigne s�lectionn�e.
        // Supposons que vous ayez une m�thode ou un service pour cela.
        // Vous pouvez remplacer cette impl�mentation factice par votre propre logique de r�cup�ration des magasins.

        var storeLocations = new List<Models.Location>
            {
                new Models.Location
                {
                    LocationName = "Poissonnerie",
                    ImageUrl = "poissonnerie.png"
                },
                new Models.Location
                {
                    LocationName = "Charcuterie",
                    ImageUrl = "charcuterie.png"
                },
                new Models.Location
                {
                    LocationName = "Fruits",
                    ImageUrl = "fruit.png"
                },
                new Models.Location
                {
                    LocationName = "L�gumes",
                    ImageUrl = "legumes.png"
                },
                new Models.Location
                {
                    LocationName = "Petit dej�uner",
                    ImageUrl = "petit_dejeuner.png"
                },
                new Models.Location
                {
                    LocationName = "Liqueurs",
                    ImageUrl = "liqueur.png"
                },
                new Models.Location
                {
                    LocationName = "Sacs � main",
                    ImageUrl = "sacs.png"
                }
            };

        return storeLocations;
    }
}