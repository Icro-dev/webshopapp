using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using webshopapp.Models;
using webshopapp.Services;
using webshopapp.ViewModel;
using webshopapp.View;

namespace webshopapp.ViewModel
{
    public partial class LoginViewModel : BaseViewModel
    {
        UsersService usersService;

        public ObservableCollection<Users> User { get; } = new();

        public string username { get; set; }
        public string password { get; set; }

        public System.Windows.Input.ICommand LogIn { get; }
        public System.Windows.Input.ICommand Register { get; }

        public LoginViewModel(UsersService usersService)
        {
            Title = "Log in";

            LogIn = new Command(LogInAsync);
            Register = new Command(RegisterAsync);

            this.usersService = usersService;
        }

        private async void LogInAsync()
        {

            var user = new Users
            {
                username = username,
                password = password,
            };

            try
            {
                var userDB = await usersService.UserAuth(user);
                Preferences.Set("username", userDB.username);
                Preferences.Set("isLoggedIn", true);

                await Shell.Current.DisplayAlert("Login succesful", $"Succes!", "OK");

                UsersViewModel userViewModel = new(usersService);


                await Shell.Current.GoToAsync(nameof(UsersPage), true,

                    new Dictionary<string, object>
                    {
                        { "UsersViewModel", userViewModel }
                    });

            }
            catch
            {
                await Shell.Current.DisplayAlert("Account not allowed", $"Password or username doesn't match existing records", "OK");
                return;
            }
        }
        private async void RegisterAsync()
        {

            try
            {
                var usersManageViewModel = new UsersManageViewModel();


                // check if user already exists

                await Shell.Current.GoToAsync(nameof(UsersRegistrationPage), true,

                    new Dictionary<string, object>
                    {
                            { "UsersManageViewModel", usersManageViewModel }
                    });

            }
            catch
            {
                await Shell.Current.DisplayAlert("Account not allowed", $"Enter a unique username", "OK");
                return;
            }
        }
    }
}
