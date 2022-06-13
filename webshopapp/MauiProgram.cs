using webshopapp.Services;
using webshopapp.View;
using webshopapp.ViewModel;

namespace webshopapp;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			});

		builder.Services.AddTransient<MainPage>();
		builder.Services.AddSingleton<ProductService>();
        builder.Services.AddSingleton<UsersService>();
        builder.Services.AddTransient<ProductsViewModel>();
        builder.Services.AddSingleton<ProductDetailsViewModel>();
        builder.Services.AddTransient<DetailsPage>();
        builder.Services.AddSingleton<LoginViewModel>();
        builder.Services.AddTransient<LoginPage>();
        builder.Services.AddSingleton<UsersManageViewModel>();
        builder.Services.AddTransient<UsersManagePage>();
        builder.Services.AddSingleton<UsersViewModel>();
        builder.Services.AddTransient<UsersPage>();
        builder.Services.AddTransient<UsersRegistrationPage>();
        
        return builder.Build();
	}
}
