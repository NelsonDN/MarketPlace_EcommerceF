namespace MarketFaith.Views;

public partial class SignUpPage : ContentPage
{
	public SignUpPage()
	{
		InitializeComponent();
	}
    private void OnRegisterButtonClicked(object sender, EventArgs e)
    {
        // Récupérer les valeurs des champs de saisie
        string firstName = FirstNameEntry.Text;
        string lastName = LastNameEntry.Text;
        string phoneNumber = PhoneNumberEntry.Text;
        string location = LocationEntry.Text;
        string password = PasswordEntry.Text;

        // Effectuer les validations nécessaires sur les données saisies

        // Effectuer le traitement d'inscription, par exemple :
        // - Enregistrer les informations dans la base de données
        // - Rediriger vers une page de confirmation d'inscription

        // Après le traitement, vous pouvez rediriger l'utilisateur vers une autre page si nécessaire
        Navigation.PushAsync(new EnseignePage());

    }
}