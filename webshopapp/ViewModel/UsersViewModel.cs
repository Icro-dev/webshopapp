using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using webshopapp.Services;
using webshopapp.View;

namespace webshopapp.ViewModel
{
    public partial class UsersViewModel : BaseViewModel
    {
        public ObservableCollection<Users> User { get; } = new();
      
        UsersService usersService;


        public string username = Preferences.Get("usernamePref", "");
        


        public UsersViewModel(UsersService usersService)
        {

            Title = "User";
            this.usersService = usersService;

        }

        [ICommand]
        async Task GetUsersAsync()
        {
            if (IsBusy)
                return;

            try
            {
                IsBusy = true;

                var users = await usersService.GetUsers();

                if (User.Count != 0)
                    User.Clear();

                foreach (var user in users)
                    User.Add(user);
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Unable to get users: {ex.Message}");
                await Shell.Current.DisplayAlert("Error!", ex.Message, "OK");
            }
            finally
            {
                IsBusy = false;
            }
        }

    }

}

