using MarketFaith.Models;
using MarketFaith.Views;

namespace MarketFaith.Views;

public partial class StorePage : ContentPage
{

    public StorePage(Models.Store selectedStore)
    {
        InitializeComponent();

        // Afficher le nom de l'enseigne sélectionnée
        StoreName.Text = selectedStore.Name;

        // Obtenir les magasins de l'enseigne sélectionnée (supposons qu'il s'agit d'une liste de magasins)
        var storeLocations = GetStoreLocations(selectedStore);

        // Assigner les magasins à la source de données du CollectionView                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                     
        StoreCollectionView.ItemsSource = storeLocations;
    }

    private void OnLocationSelected(object sender, SelectionChangedEventArgs e)
    {
        if (e.CurrentSelection == null || e.CurrentSelection.Count == 0)
            return;

        var selectedLocation = (Models.Location)e.CurrentSelection[0];

        // Rediriger vers la page du magasin sélectionné
        //
        // Navigation.PushAsync(new StoreDetailPage(selectedLocation));
        Navigation.PushAsync(new ProductsPage());

        // Désélectionner l'élément de la CollectionView
        StoreCollectionView.SelectedItem = null;
    }

    private List<Models.Location> GetStoreLocations(Store selectedStore)
    {
        // Ici, vous devez implémenter la logique pour récupérer les magasins de l'enseigne sélectionnée.
        // Supposons que vous ayez une méthode ou un service pour cela.
        // Vous pouvez remplacer cette implémentation factice par votre propre logique de récupération des magasins.

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
                    LocationName = "Légumes",
                    ImageUrl = "legumes.png"
                },
                new Models.Location
                {
                    LocationName = "Petit dejêuner",
                    ImageUrl = "petit_dejeuner.png"
                },
                new Models.Location
                {
                    LocationName = "Liqueurs",
                    ImageUrl = "liqueur.png"
                },
                new Models.Location
                {
                    LocationName = "Sacs à main",
                    ImageUrl = "sacs.png"
                }
            };

        return storeLocations;
    }
}