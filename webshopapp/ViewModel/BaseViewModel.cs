using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace webshopapp.ViewModel;

public partial class BaseViewModel : ObservableObject
{
    [ObservableProperty]
    [AlsoNotifyChangeFor(nameof(IsNotBusy))]
    public bool isBusy;

    [ObservableProperty]
    public string title;

    public bool IsNotBusy => !IsBusy;

    public bool isAdmin => Preferences.Get("isAdmin", false);
    public bool isNotAdmin => !isAdmin;
    public string usernamePref => Preferences.Get("username", "");
  
    public bool isLoggedIn => Preferences.Get("isLoggedIn", false);
    public bool isNotLoggedIn => !isLoggedIn;

  /*  public long CartId => Preferences.Get("CartId", CartId);*/

    [ICommand]
    async Task GoBack()
    {
        await Shell.Current.GoToAsync("..");
    }

    [ICommand]
    async Task NotImplemented()
    {
        await Shell.Current.DisplayAlert("Not implemented", $"Unfinished feature", "OK");
        return;
    }
}
