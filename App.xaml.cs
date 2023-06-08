using Microsoft.Maui;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Controls.Xaml;
using MarketFaith.Views;


[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace MarketFaith;

public partial class App : Application
{
	public App()
	{
		InitializeComponent();
        
        MainPage = new NavigationPage(new LangagePage());
	}
}
