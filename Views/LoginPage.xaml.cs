using Newtonsoft.Json;
using System.Net.Http;
using System;
using MarketFaith.Views;
using MarketFaith.Models;

namespace MarketFaith.Views;

public partial class LoginPage : ContentPage
{
    private HttpClient httpClient;

    public LoginPage()
    {
        InitializeComponent();
        httpClient = new HttpClient();
        NavigationPage.SetHasNavigationBar(this, false);
    }

    //private void OnLoginButtonClicked(object sender, EventArgs e)
    //{
    //    // Vérifier les informations de connexion et effectuer les validations nécessaires
    //    // Rediriger vers la page des enseignes si les informations sont valides

    //    Navigation.PushAsync(new EnseignePage());
    //}

    private async void OnLoginButtonClicked(object sender, EventArgs e)
    {
        if (String.IsNullOrEmpty(UsernameEntry.Text)  || String.IsNullOrEmpty(PasswordEntry.Text) )
        {
            await DisplayAlert("Oops", "Remplir tous les champs", "OK");
            return;
        }

        var email = UsernameEntry.Text;
        var password = PasswordEntry.Text;

        var loginModel = new { email, password };

        var json = JsonConvert.SerializeObject(loginModel);
        var content = new StringContent(json, System.Text.Encoding.UTF8, "application/json");

        try
        {
            var response = await httpClient.PostAsync("http://127.0.0.1:8000/api/login", content);
            var responseContent = await response.Content.ReadAsStringAsync();

            if (response.IsSuccessStatusCode)
            {
                var userResponse = JsonConvert.DeserializeObject<User>(responseContent);
                var accessToken = userResponse.token;

                // Récupérer l'ID de l'utilisateur
                var userId = userResponse.id;

                // Enregistrer les informations de l'utilisateur connecté

                // Stocker les informations dans les préférences de l'application pour une persistance
                Preferences.Set("UserId", userResponse.id);
                Preferences.Set("UserName", userResponse.name);
                Preferences.Set("UserEmail", userResponse.email);
                Preferences.Set("UserToken", userResponse.token);

                App.CurrentUser = new CurrentUser
                {
                    id = userResponse.id,
                    name = userResponse.name,
                    email = userResponse.email,
                    token = userResponse.token
                };

                // Rediriger vers la page d'accueil
                await this.Navigation.PushAsync(new TabsPage());
            }
            else
            {
                // Gérer l'échec de la connexion
                await DisplayAlert("Erreur", "Identifiants invalides", "OK");
            }
        }
        catch (HttpRequestException)
        {
            await DisplayAlert("Erreur", "Impossible de se connecter à l'API. Vérifiez votre connexion réseau.", "OK");
        }
        catch (Exception ex)
        {
            await DisplayAlert("Erreur", ex.Message, "OK");
        }

    }

    private void OnSignUpLabelTapped(object sender, EventArgs e)
    {
        // Rediriger vers la page d'inscription
        Navigation.PushAsync(new SignUpPage());
    }

    private void OnForgotPasswordButtonClicked(object sender, EventArgs e)
    {
        DisplayAlert("Désolé", "Cette fonctionnalité est en cours de développement", "OK");
    }
}