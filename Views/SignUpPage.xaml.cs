using Newtonsoft.Json;
using System.Net.Http;
using System.Net;

namespace MarketFaith.Views;

public partial class SignUpPage : ContentPage
{
    private HttpClient httpClient;
    public SignUpPage()
	{
		InitializeComponent();
        httpClient = new HttpClient();

        NavigationPage.SetHasNavigationBar(this, false);
    }

    private async void OnRegisterButtonClicked(object sender, EventArgs e)
    {

        if (String.IsNullOrEmpty(NameEntry.Text) || String.IsNullOrEmpty(EmailEntry.Text) || String.IsNullOrEmpty(PhoneNumberEntry.Text) || String.IsNullOrEmpty(PasswordEntry.Text) || String.IsNullOrEmpty(ConfirmationPasswordEntry.Text))
        {
            await DisplayAlert("Oops", "Remplir tous les champs", "OK");
            return;
        }

        // R�cup�rer les valeurs des champs de saisie
        string name = NameEntry.Text;
        string email = EmailEntry.Text;
        string telephone = PhoneNumberEntry.Text;
        string password = PasswordEntry.Text;
        string password_confirmation = ConfirmationPasswordEntry.Text;

        // Cr�er l'objet JSON pour les donn�es d'inscription
        var registerData = new
        {
            name,
            email,
            telephone, 
            password,
            password_confirmation,
        };

        var json = JsonConvert.SerializeObject(registerData);
        var content = new StringContent(json, System.Text.Encoding.UTF8, "application/json");

        try
        {
            // Appeler l'API pour l'inscription
            var response = await httpClient.PostAsync("http://127.0.0.1:8000/api/register", content);

            if (response.StatusCode == HttpStatusCode.OK)
            {
                // L'inscription a r�ussi, rediriger vers la page de connexion
                await Navigation.PushAsync(new LoginPage());
            }
            else
            {
                // G�rer les erreurs d'inscription
                // var responseContent = await response.Content.ReadAsStringAsync();
                // var error = JsonConvert.DeserializeObject<ErrorResponse>(responseContent);

                // Afficher le message d'erreur
                await DisplayAlert("Erreur", "Verifier vos informations", "OK");
            }
        }
        catch (HttpRequestException)
        {
            // Erreur de connexion au serveur
            await DisplayAlert("Erreur", "Impossible de se connecter au serveur", "OK");
        }
        catch (Exception ex)
        {
            // Autre erreur inattendue
            await DisplayAlert("Erreur", "Une erreur s'est produite : " + ex.Message, "OK");
        }


    }
}