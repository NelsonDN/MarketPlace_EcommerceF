using System;
using Microsoft.Maui.Controls;

namespace MarketFaith.Views;

public partial class LangagePage : ContentPage
{
	public LangagePage()
	{
		InitializeComponent();
        NavigationPage.SetHasNavigationBar(this, false);
    }

    private void EnBtnClicked(object sender, EventArgs e)
    {
        Preferences.Set("Langue", "en");
        this.Navigation.PushAsync(new LoginPage());
    }

    private void FrBtnClicked(object sender, EventArgs e)
    {
        Preferences.Set("Langue", "fr");
        this.Navigation.PushAsync(new LoginPage());
    }
}