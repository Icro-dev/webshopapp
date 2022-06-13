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
        public bool isLoggedIn = Preferences.Get("isLoggedIn", true);


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
           /* {
                    UsersManageViewModel usersManageViewModel = new UsersManageViewModel();

                    var user = await usersService.GetUser(username);
                    usersManageViewModel.User = user;
                    await Shell.Current.GoToAsync(nameof(UsersManagePage), true,
                    new Dictionary<string, object>
                        {
                        { "UsersManageViewModel", usersManageViewModel }
                    });

                }
                else
                {
                    await Shell.Current.GoToAsync(nameof(UsersManagePage));
                }

            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                await Shell.Current.DisplayAlert("Error!", $"Unable to get users: {ex.Message}", "OK");
            }
            finally
            {
                IsBusy = false;
            }*/
        }

    }

}

