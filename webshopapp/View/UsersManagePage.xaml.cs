using webshopapp.ViewModel;

namespace webshopapp.View;

public partial class UsersManagePage : ContentPage
{
	public UsersManagePage(UsersManageViewModel viewModel)
	{
		InitializeComponent();
        BindingContext = viewModel;
    }
    protected override void OnNavigatedTo(NavigatedToEventArgs args)
    {
        base.OnNavigatedTo(args);
    }
}