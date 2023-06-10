namespace MarketFaith.Views;

public partial class CommandeSuccessPage : ContentPage
{
	public CommandeSuccessPage()
	{
		InitializeComponent();
        NavigationPage.SetHasNavigationBar(this, false);
    }

    private void ValiderButton(object sender, EventArgs e)
    {
        this.Navigation.PushAsync(new TabsPage());
    }
}