namespace MarketFaith.Views;

public partial class HomePage : FlyoutPage
{
	public HomePage()
	{
		InitializeComponent();
	}
    private async void OnLoginPageClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new LoginPage());
        IsPresented = false; // Masquer le menu Flyout après la navigation
    }

    private async void OnSignUpPageClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new SignUpPage());
        IsPresented = false; // Masquer le menu Flyout après la navigation
    }
}