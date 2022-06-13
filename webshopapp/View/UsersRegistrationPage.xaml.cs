namespace webshopapp.View;

public partial class UsersRegistrationPage : ContentPage
{
	public UsersRegistrationPage(UsersManageViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
	}

    protected override void OnNavigatedTo(NavigatedToEventArgs args)
    {
        base.OnNavigatedTo(args);
    }
}