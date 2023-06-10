using MarketFaith.Models;
using MarketFaith.Views;
using MarketFaith.Services;
using Newtonsoft.Json;
using System.Collections.ObjectModel;

namespace MarketFaith.Views;

public partial class StorePage : ContentPage
{
    private ObservableCollection<CartItem> cartItems;
    private const string ApiBaseUrl = "http://127.0.0.1:8000/api/categories";
    List<Categorie> categories;

    public StorePage(Models.Enseigne selectedEnseigne)
    {
        InitializeComponent();
        cartItems = new ObservableCollection<CartItem>();

        // Afficher le nom de l'enseigne s�lectionn�e
        StoreName.Text = selectedEnseigne.name;

        // Obtenir les magasins de l'enseigne s�lectionn�e (supposons qu'il s'agit d'une liste de magasins)
        DownloadData(selectedEnseigne);
    }

    private void OnLocationSelected(object sender, SelectionChangedEventArgs e)
    {
        if (e.CurrentSelection == null || e.CurrentSelection.Count == 0)
            return;

        var selectedCategorie = (Models.Categorie)e.CurrentSelection[0];

        // Rediriger vers la page du magasin s�lectionn�
        //
        // Navigation.PushAsync(new StoreDetailPage(selectedLocation));
        Navigation.PushAsync(new ProductsPage(selectedCategorie));

        // D�s�lectionner l'�l�ment de la CollectionView
        StoreCollectionView.SelectedItem = null;
    }



    //protected override bool OnBackButtonPressed()
    //{
    //    base.OnDisappearing();
    //    // V�rifiez si le panier contient des produits
    //    if (cartItems.Count > 0)
    //    {
    //        var answer = DisplayAlert("Attention", "Si vous quittez cette page, votre panier sera vid�. �tes-vous s�r de vouloir continuer ?", "Oui", "Non");

    //        if (answer)
    //        {
    //            CartManager.ClearCart();
    //            this.Navigation.PopAsync();
    //        }
    //        this.Navigation.PopAsync();

    //    }
    //    return true;

    //}


    public async void DownloadData(Enseigne selectedEnseigne)
    {
        // Ici, vous devez impl�menter la logique pour r�cup�rer les magasins de l'enseigne s�lectionn�e.
        // Supposons que vous ayez une m�thode ou un service pour cela.
        // Vous pouvez remplacer cette impl�mentation factice par votre propre logique de r�cup�ration des magasins.

        //var storeLocations = new List<Models.Location>
        //    {
        //        new Models.Location
        //        {
        //            LocationName = "Poissonnerie",
        //            ImageUrl = "poissonnerie.png"
        //        },
        //        new Models.Location
        //        {
        //            LocationName = "Charcuterie",
        //            ImageUrl = "charcuterie.png"
        //        },
        //        new Models.Location
        //        {
        //            LocationName = "Fruits",
        //            ImageUrl = "fruit.png"
        //        },
        //        new Models.Location
        //        {
        //            LocationName = "L�gumes",
        //            ImageUrl = "legumes.png"
        //        },
        //        new Models.Location
        //        {
        //            LocationName = "Petit dej�uner",
        //            ImageUrl = "petit_dejeuner.png"
        //        },
        //        new Models.Location
        //        {
        //            LocationName = "Liqueurs",
        //            ImageUrl = "liqueur.png"
        //        },
        //        new Models.Location
        //        {
        //            LocationName = "Sacs � main",
        //            ImageUrl = "sacs.png"
        //        }
        //    };
        try
        {
            using (HttpClient client = new HttpClient())
            {
                string apiUrl = $"{ApiBaseUrl}/{selectedEnseigne.id}";

                HttpResponseMessage response = await client.GetAsync(apiUrl);

                if (response.IsSuccessStatusCode)
                {
                    string json = await response.Content.ReadAsStringAsync();
                    categories = JsonConvert.DeserializeObject<List<Categorie>>(json);

                    // Faites quelque chose avec le produit r�cup�r�, par exemple, l'afficher dans les contr�les de la page

                    // Assigner les magasins � la source de donn�es du CollectionView                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                     
                    StoreCollectionView.ItemsSource = categories;

                }
                else
                {
                    // G�rez l'erreur de la requ�te HTTP, par exemple, affichez un message d'erreur appropri�
                    Console.WriteLine($"Erreur lors de la r�cup�ration des enseignes. Code de statut : {response.StatusCode}");
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