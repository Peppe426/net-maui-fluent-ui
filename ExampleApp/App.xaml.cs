using ExampleApp.Infrastructure;

namespace ExampleApp;

public partial class App : Application
{
    public App()
    {
        InitializeComponent();
        CultureInfoService.SetCultureInfo(null);

        MainPage = new MainPage();
    }
}