namespace MarketFaith.Views;

public partial class LoginPage : ContentPage
{
	public LoginPage()
	{
		InitializeComponent();
	}

    private void OnLoginButtonClicked(object sender, EventArgs e)
    {
        // Vérifier les informations de connexion et effectuer les validations nécessaires
        // Rediriger vers la page des enseignes si les informations sont valides

        Navigation.PushAsync(new EnseignePage());
    }

    private void OnSignUpLabelTapped(object sender, EventArgs e)
    {
        // Rediriger vers la page d'inscription
        Navigation.PushAsync(new SignUpPage());
    }

    private void OnForgotPasswordButtonClicked(object sender, EventArgs e)
    {
        DisplayAlert("Désolé!", "Cette fonctionnalité ne marche pas encore!", "OK");
    }
}