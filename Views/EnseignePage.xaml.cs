
using MarketFaith.Models;
using Newtonsoft.Json;
using System.Net;
using System.Xml;

namespace MarketFaith.Views;

public partial class EnseignePage : ContentPage
{
    private const string ApiBaseUrl = "http://127.0.0.1:8000/api/enseignes";
    List<Enseigne> enseignes;

    public EnseignePage(Models.Boutique boutique)
	{
		InitializeComponent();

        // Créer une liste d'enseignes
        //var stores = new List<Store>
        //    {
        //        new Store
        //        {
        //            Name = "Santa Lucia",
        //            ImageUrl = "santalucia.png",
        //            OpenHours = "Lun - Ven: 8h - 20h"
        //        },
        //        new Store
        //        {
        //            Name = "BAO",
        //            ImageUrl = "bao.png",
        //            OpenHours = "Lun - Ven: 9h - 21h"
        //        },
        //        new Store
        //        {
        //            Name = "Carrefour",
        //            ImageUrl = "carrefour.png",
        //            OpenHours = "Lun - Ven: 8h30 - 19h30"
        //        },
        //        new Store
        //        {
        //            Name = "DOVV",
        //            ImageUrl = "dovv.png",
        //            OpenHours = "Lun - Ven: 7h30 - 22h"
        //        },
        //        new Store
        //        {
        //            Name = "Mahima",
        //            ImageUrl = "mahima.png",
        //            OpenHours = "Lun - Ven: 9h - 20h"
        //        }
        //    };
        DownloadData(boutique.id);


        // Assigner la liste d'enseignes à la source de données du ListView
        //StoreListView.ItemsSource = stores;

        //NavigationPage.SetHasNavigationBar(this, false);
    }

    public async void DownloadData(int boutique_id)
    {
        try
        {
            using (HttpClient client = new HttpClient())
            {
                string apiUrl = $"{ApiBaseUrl}/{boutique_id}";

                HttpResponseMessage response = await client.GetAsync(apiUrl);

                if (response.IsSuccessStatusCode)
                {
                    string json = await response.Content.ReadAsStringAsync();
                    enseignes = JsonConvert.DeserializeObject<List<Enseigne>>(json);

                    // Faites quelque chose avec le produit récupéré, par exemple, l'afficher dans les contrôles de la page
                    
                    StoreListView.ItemsSource = enseignes;

                }
                else
                {
                    // Gérez l'erreur de la requête HTTP, par exemple, affichez un message d'erreur approprié
                    Console.WriteLine($"Erreur lors de la récupération des enseignes. Code de statut : {response.StatusCode}");
                }
            }
        }
        catch (Exception ex)
        {
            // Gérez les exceptions, par exemple, affichez un message d'erreur approprié
            Console.WriteLine($"Erreur lors de la récupération des enseignes : {ex.Message}");
        }
    }

    private void OnStoreSelected(object sender, SelectedItemChangedEventArgs e)
    {
        if (e.SelectedItem == null)
            return;

        var selectedEnseigne = (Enseigne)e.SelectedItem;

        // Rediriger vers la page des magasins de l'enseigne sélectionnée
        Navigation.PushAsync(new StorePage(selectedEnseigne));

        // Désélectionner l'élément du ListView
        StoreListView.SelectedItem = null;
    }


    private async void LogoutButton_Clicked(object sender, EventArgs e)
    {
        // Créez un objet HttpClient pour effectuer la requête HTTP
        // var httpClient = new HttpClient();

        // Valeur token
        string userToken = Preferences.Get("UserToken", string.Empty);

        // Ajoutez le jeton d'accès à l'en-tête Authorization
        //httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", userToken);

        //// Effectuez la requête HTTP de déconnexion
        //var response = await httpClient.PostAsync("http://127.0.0.1:8000/api/logout", null);

        //// Vérifiez la réponse HTTP
        //if (response.IsSuccessStatusCode)
        //{
        Preferences.Set("UserId", 0);
        Preferences.Set("UserName", "");
        Preferences.Set("UserEmail", "");
        Preferences.Set("UserToken", "");
        // Déconnexion réussie, redirigez vers la page de connexion
        await Navigation.PushAsync(new LoginPage());
        //}
        //else
        //{
        //    // Erreur lors de la déconnexion, affichez un message d'erreur
        //    await DisplayAlert("Erreur", "Une erreur s'est produite lors de la déconnexion.", "OK");
        //}
    }
}