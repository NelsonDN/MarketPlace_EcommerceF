using Microsoft.Maui;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Controls.Xaml;
using MarketFaith.Views;
using MarketFaith.Models;


[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace MarketFaith;

public partial class App : Application
{
    public static CurrentUser CurrentUser { get; set; }

    public App()
	{
		InitializeComponent();


        string valeur = Preferences.Get("Langue", "");
        //Preferences.Set("UserId", 0);
        //Preferences.Set("UserName", "");
        //Preferences.Set("UserEmail", "");
        //Preferences.Set("UserToken", "");
        // Récupérer les informations de l'utilisateur à partir des préférences de l'application
        int userId = Preferences.Get("UserId", 0); // Utilisez une valeur par défaut appropriée
        string userName = Preferences.Get("UserName", string.Empty);
        string userEmail = Preferences.Get("UserEmail", string.Empty);
        string userToken = Preferences.Get("UserToken", string.Empty);

        if (valeur == "fr" || valeur == "en")
        {
            MainPage = new NavigationPage(new LoginPage());
        }
        else
        {
            MainPage = new NavigationPage(new LangagePage());
        }

        if (userId == 0 || userName == "" || userEmail == "" || userToken == "")
        {
            MainPage = new NavigationPage(new LoginPage());
        }
        else
        {
            MainPage = new NavigationPage(new TabsPage());
        }

        //MainPage = new NavigationPage(new MagasinsPage());

    }
}
