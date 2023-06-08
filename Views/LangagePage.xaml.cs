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
        this.Navigation.PushAsync(new CategoriesPage());
    }

    private void FrBtnClicked(object sender, EventArgs e)
    {
        this.Navigation.PushAsync(new LoginPage());
    }
}