using webshopapp.View;
using webshopapp.Repositories;

namespace webshopapp;

public partial class App : Application
{
   

    public App()
    {
        InitializeComponent();

        MainPage = new AppShell();

    }
}