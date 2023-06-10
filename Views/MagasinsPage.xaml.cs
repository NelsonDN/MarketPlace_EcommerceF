using Newtonsoft.Json;
using System.ComponentModel;
using System.Net;
using MarketFaith.Models;


namespace MarketFaith.Views;

public partial class MagasinsPage : ContentPage
{
    private const string ApiBaseUrl = "http://127.0.0.1:8000/api/boutiques";
    List<Boutique> boutiques;

    public MagasinsPage()
    {
        InitializeComponent();

        maListeView.RefreshCommand = new Command((obj) =>
        {
            DownloadData();
        });

        maListeView.IsVisible = false;
        waitLayout.IsVisible = true;


        // Appel a ma fonction de chargement de données
        DownloadData();


        /*
         * pizzas = new List<Pizza>();
		pizzas.Add(new Pizza { nom = "Vegetarienne", prix = 7, ingredients = new string[] { "tomate", "sel", "patate" }, imageUrl="" });
		pizzas.Add(new Pizza { nom = "camerounaise", prix = 25, ingredients = new string[] { "tomate", "sel", "patate" }, imageUrl = "" });
		pizzas.Add(new Pizza { nom = "italienne", prix = 14, ingredients = new string[] { "tomate", "sel", "patate" }, imageUrl = "" });
		pizzas.Add(new Pizza { nom = "portugaise", prix = 16, ingredients = new string[] { "tomate", "sel", "patate", "tomate", "sel", "patate", "tomate", "sel", "patate", "tomate", "sel", "patate" }, imageUrl = "" });
        */

		maListeView.ItemSelected += (sender, e) =>
		{
			if (maListeView.SelectedItem != null)
			{
				Boutique boutique = maListeView.SelectedItem as Boutique;
                Navigation.PushAsync(new EnseignePage(boutique));
                maListeView.SelectedItem = null;
			}
		};
    }

    public async void DownloadData()
    {

        try
        {
            using (HttpClient client = new HttpClient())
            {
                string apiUrl = $"{ApiBaseUrl}";

                HttpResponseMessage response = await client.GetAsync(apiUrl);

                if (response.IsSuccessStatusCode)
                {
                    string json = await response.Content.ReadAsStringAsync();
                    boutiques = JsonConvert.DeserializeObject<List<Boutique>>(json);

                    // Faites quelque chose avec le produit récupéré, par exemple, l'afficher dans les contrôles de la page

                    maListeView.ItemsSource = boutiques;

                    maListeView.IsVisible = true;
                    waitLayout.IsVisible = false;
                    maListeView.IsRefreshing = false;

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
}

//const string URL = "http://127.0.0.1:8000/api/boutiques";

////string pizzasJson = "[\r\n  {\r\n    \"nom\": \"fromages\",\r\n    \"prix\": 9,\r\n    \"imageUrl\": \"\",\r\n    \"ingredients\": [\r\n      \"blue\",\r\n      \"sucre\",\r\n      \"sel\"\r\n    ]\r\n  },\r\n  {\r\n    \"nom\": \"camerounaise\",\r\n    \"prix\": 12,\r\n    \"imageUrl\": \"\",\r\n    \"ingredients\": [\r\n      \"tomate\",\r\n      \"poivron\"\r\n    ]\r\n  },\r\n  {\r\n    \"nom\": \"spécial nelson\",\r\n    \"prix\": 30,\r\n    \"imageUrl\": \"\",\r\n    \"ingredients\": [\r\n      \"pain\",\r\n      \"farine\",\r\n      \"sel\",\r\n      \"blé\",\r\n      \"viande\",\r\n      \"condiments vert\",\r\n      \"djindja\",\r\n      \"love\"\r\n    ]\r\n  }\r\n]";

//string pizzasJson = "";

//        using (WebClient webclient = new WebClient())
//        {
//            webclient.Encoding = System.Text.Encoding.UTF8;

//            // Thread Main (ui)
//            //SYNCHRONE
//            pizzasJson = webclient.DownloadString(URL);

//            //ANSYNCHRONE  DownloadStringCompletedEventArgs (string) AsyncCompletedEventArgs (file)
//            webclient.DownloadStringCompleted += (object sender, DownloadStringCompletedEventArgs e) =>
//            {
//                Console.WriteLine("ok");

//                try
//                {
//                    string pizzasJson = e.Result;

//boutiques = JsonConvert.DeserializeObject<List<Boutique>>(pizzasJson);

//                    Device.BeginInvokeOnMainThread(() =>
//                    {
//                        maListeView.ItemsSource = boutiques;

//                    });

//                }
//                catch (WebException ex)
//                {
//    // Thread réseau

//    Device.BeginInvokeOnMainThread(() =>
//    {
//        DisplayAlert("Erreur", "Une erreur réseau s'est produite : " + ex.Message, "OK");

//    });

//    string message = ex.Message;
//    if (ex.Status == WebExceptionStatus.ProtocolError)
//    {
//        DisplayAlert("Erreur", "Verifiez votre url", "OK"); ;
//    }
//    if (ex.Status == WebExceptionStatus.NameResolutionFailure)
//    {
//        DisplayAlert("Erreur", "Verifiez votre accès réseau", "OK");
//    }
//    return;
//}

//            };

//webclient.DownloadStringAsync(new Uri(URL));
//            //webclient.DownloadFileAsync(new Uri(URL), tempNameFile);
//        }