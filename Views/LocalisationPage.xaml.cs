namespace MarketFaith.Views;

public partial class LocalisationPage : ContentPage
{
	public LocalisationPage()
	{
		InitializeComponent();
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