namespace webshopapp.View;

public partial class PostNewsPage : ContentPage
{
	public PostNewsPage(NewsViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;

    }
    protected override void OnNavigatedTo(NavigatedToEventArgs args)
    {
        base.OnNavigatedTo(args);
    }
}