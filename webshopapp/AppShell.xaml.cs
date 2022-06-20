using webshopapp.View;

namespace webshopapp;

public partial class AppShell : Shell
{
    public AppShell()
    {
        InitializeComponent();

        Routing.RegisterRoute(nameof(DetailsPage), typeof(DetailsPage));
        Routing.RegisterRoute(nameof(UsersManagePage), typeof(UsersManagePage));
        Routing.RegisterRoute(nameof(LoginPage), typeof(LoginPage));
        Routing.RegisterRoute(nameof(UsersPage), typeof(UsersPage));
        Routing.RegisterRoute(nameof(MainPage), typeof(MainPage));
        Routing.RegisterRoute(nameof(UsersRegistrationPage), typeof(UsersRegistrationPage));
        Routing.RegisterRoute(nameof(CartPage), typeof(CartPage));

    }
}
