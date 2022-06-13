using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using webshopapp.Helpers;
using webshopapp.Models;

namespace webshopapp.Services
{
    public class UsersService
    {
        HttpClient httpClient;


        static string BaseUrl = DeviceInfoHelper.BaseUrl;
        public string Url = $"{BaseUrl}/Users";

        public UsersService()
        {
            httpClient = new HttpClient();
        }

        List<Users> userList = new List<Users>();

        public async Task<List<Users>> GetUsers()
        {
            if (userList?.Count > 0)
                userList = new List<Users>();

            var url = Url;

            var response = await httpClient.GetAsync(url);

            if (response.IsSuccessStatusCode)
            {
                userList = await response.Content.ReadFromJsonAsync<List<Users>>();
            }

            return userList;
        }

        public async Task<Users> GetUser(string username)
        {

            var user = new Users();
            var url = $"{Url}/{username}";

            var response = await httpClient.GetAsync(url);

            if (response.IsSuccessStatusCode)
            {
                user = await response.Content.ReadFromJsonAsync<Users>();
            }

            return user;
        }

        public async Task<Users> UpdateUserAsync(Users user)
        {
            var username = user.username;
            var updateUrl = $"{Url}/{username}";
            var response = await httpClient.PutAsJsonAsync(updateUrl, user);

            if (response.IsSuccessStatusCode)
            {
                userList = await GetUsers();
            }

            return user;
        }

        public async Task<Users> AddUserAsync(Users user)
        {

            var response = await httpClient.PostAsJsonAsync(Url, user);

            if (response.IsSuccessStatusCode)
            {
                userList = await GetUsers();
            }

            return user;
        }

        public async Task<Users> DeleteUserAsync(Users user)
        {
            var username = user.username;
            var deleteUrl = $"{Url}/{username}";
            var response = await httpClient.DeleteAsync(deleteUrl);

            if (response.IsSuccessStatusCode)
            {
                userList = await GetUsers();
            }

            return user;
        }

        public async Task<Users> UserAuth(Users user)
        {

            var response = await httpClient.GetAsync(Url);

            if (response.IsSuccessStatusCode)
            {
                userList = await response.Content.ReadFromJsonAsync<List<Users>>();
            }


            var userAccount = userList?.Find(u => u.username == user.username);
            if (userAccount.password == user.password)
            {
                return userAccount;
            }

            return user;
        }
    }
}
