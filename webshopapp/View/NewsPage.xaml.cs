namespace webshopapp.View;

public partial class NewsPage : ContentPage
{
	public NewsPage(NewsViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;

    }

    protected override void OnNavigatedTo(NavigatedToEventArgs args)
    {
        base.OnNavigatedTo(args);
    }
}