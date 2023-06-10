
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

        // Cr�er une liste d'enseignes
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


        // Assigner la liste d'enseignes � la source de donn�es du ListView
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

                    // Faites quelque chose avec le produit r�cup�r�, par exemple, l'afficher dans les contr�les de la page
                    
                    StoreListView.ItemsSource = enseignes;

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

    private void OnStoreSelected(object sender, SelectedItemChangedEventArgs e)
    {
        if (e.SelectedItem == null)
            return;

        var selectedEnseigne = (Enseigne)e.SelectedItem;

        // Rediriger vers la page des magasins de l'enseigne s�lectionn�e
        Navigation.PushAsync(new StorePage(selectedEnseigne));

        // D�s�lectionner l'�l�ment du ListView
        StoreListView.SelectedItem = null;
    }


    private async void LogoutButton_Clicked(object sender, EventArgs e)
    {
        // Cr�ez un objet HttpClient pour effectuer la requ�te HTTP
        // var httpClient = new HttpClient();

        // Valeur token
        string userToken = Preferences.Get("UserToken", string.Empty);

        // Ajoutez le jeton d'acc�s � l'en-t�te Authorization
        //httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", userToken);

        //// Effectuez la requ�te HTTP de d�connexion
        //var response = await httpClient.PostAsync("http://127.0.0.1:8000/api/logout", null);

        //// V�rifiez la r�ponse HTTP
        //if (response.IsSuccessStatusCode)
        //{
        Preferences.Set("UserId", 0);
        Preferences.Set("UserName", "");
        Preferences.Set("UserEmail", "");
        Preferences.Set("UserToken", "");
        // D�connexion r�ussie, redirigez vers la page de connexion
        await Navigation.PushAsync(new LoginPage());
        //}
        //else
        //{
        //    // Erreur lors de la d�connexion, affichez un message d'erreur
        //    await DisplayAlert("Erreur", "Une erreur s'est produite lors de la d�connexion.", "OK");
        //}
    }
}