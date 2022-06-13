using webshopapp.ViewModel;

namespace webshopapp.View;

public partial class DetailsPage : ContentPage
{
	public DetailsPage(ProductDetailsViewModel viewModel)
	{
		InitializeComponent();

		BindingContext = viewModel;
	}

    protected override void OnNavigatedTo(NavigatedToEventArgs args)
    {
        base.OnNavigatedTo(args);
    }
}