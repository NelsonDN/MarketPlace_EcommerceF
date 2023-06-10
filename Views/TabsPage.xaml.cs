namespace MarketFaith.Views;

public partial class TabsPage : TabbedPage
{
	public TabsPage()
	{
		InitializeComponent();
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
    protected override void OnAppearing()
    {
        base.OnAppearing();
        // Récupérer les informations de l'utilisateur à partir des préférences de l'application
        int userId = Preferences.Get("UserId", 0); // Utilisez une valeur par défaut appropriée
        string userName = Preferences.Get("UserName", string.Empty);
        string userEmail = Preferences.Get("UserEmail", string.Empty);
        string userToken = Preferences.Get("UserToken", string.Empty);

        if (userId == 0 || userName == "" || userEmail == "" || userToken == "")
        {
            this.Navigation.PushAsync(new LoginPage());
        }
        else
        {
            var a = 0;
        }
    }

}