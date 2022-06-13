using webshopapp.Models;
using webshopapp.ViewModel;

namespace webshopapp.View;

public partial class MainPage : ContentPage
{

	public MainPage(ProductsViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
	}

    protected override void OnNavigatedTo(NavigatedToEventArgs args)
    {
        base.OnNavigatedTo(args);
    }
}

