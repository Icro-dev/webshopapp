using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using webshopapp.Models;
using webshopapp.Services;
using webshopapp.View;

namespace webshopapp.ViewModel
{
    [QueryProperty("User", "User")]
    public partial class UsersManageViewModel : BaseViewModel
    {
        [ObservableProperty]
        Users user;
        public ObservableCollection<Users> Users { get; set; } = new();
        UsersService usersService;

        public string username { get; set; }
        public string password { get; set; }
        public string role { get; set; }
        public double latitude { get; set; }
        public double longitude { get; set; }
        public string street { get; set; }
        public string houseNumber { get; set; }
        public string zipcode { get; set; }
        public string city { get; set; }

        public UsersManageViewModel(UsersService userService)
        {
            Title = "User management";
            this.usersService = userService;
            if (user == null)
                user = new Users();


            var Users = new ObservableCollection<Users>();

            _ = GetUsers();
        }

        public UsersManageViewModel()
        {
        }

        [ICommand]
        async Task NotImplemented()
        {
            await Shell.Current.DisplayAlert("Not implemented", $"Unfinished feature", "OK");
            await Shell.Current.GoToAsync($"{nameof(UsersPage)}");
        }

        [ICommand]
        async Task GetUsers()
        {
            if (IsBusy)
                return;

            try
            {
                IsBusy = true;
                List<Users> users = await usersService.GetUsers();

                if (Users.Count != 0)
                    Users.Clear();

                foreach (Users user in users)
                    Users.Add(user);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                await Shell.Current.DisplayAlert("Error!", $"Unable to get users: {ex.Message}", "OK");
            }
            finally
            {
                IsBusy = false;
            }
        }

        [ICommand]
        async Task GetUser(Users user)
        {
            if (IsBusy)
                return;

            await Shell.Current.GoToAsync(nameof(UsersManagePage), true,
                new Dictionary<string, object>
                    {
                            { "User", user }
                });

        }

        [ICommand]
        async void UpdateUser()
        {
            if (IsBusy)
                return;


            try
            {
                var userPut = await usersService.UpdateUserAsync(user);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                await Shell.Current.DisplayAlert("Error!", $"Unable to change user: {ex.Message}", "OK");
            }


            await Shell.Current.GoToAsync(nameof(UsersPage));

        }

            [ICommand]
            async void AddUser(Users user)
            {
                if (IsBusy)
                    return;

                if (user == null)
                    user = new Users();

                try
                {
                    if ((user.username != null) && (user.password != null))
                    {
                        user = await usersService.AddUserAsync(user);
                        await Shell.Current.GoToAsync(nameof(UsersPage));
                    }

                    else
                        await Shell.Current.DisplayAlert("Error!", $"Unable to add user, enter a unique username", "OK");
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex);
                    await Shell.Current.DisplayAlert("Error!", $"An unexpected error occurred", "OK");
                }
                await Shell.Current.GoToAsync(nameof(UsersPage));
            }

            [ICommand]
            async Task DeleteUser(Users user)
            {
                try
                {
                    var deleteUser = await usersService.DeleteUserAsync(user);
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex);
                    await Shell.Current.DisplayAlert("Error!", $"Unable to delete user: {ex.Message}", "OK");
                }


                await Shell.Current.GoToAsync(nameof(UsersPage));

            }


    }


}


