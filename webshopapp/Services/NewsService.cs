using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using webshopapp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text.Json;
using System.Diagnostics;
using webshopapp.Helpers;

namespace webshopapp.Services
{
    public class NewsService
    {
        HttpClient httpClient;


        static string BaseUrl = DeviceInfoHelper.BaseUrl;
        public string Url = $"{BaseUrl}/News";

        public NewsService()
        {
            httpClient = new HttpClient();
        }

        List<News> newsList = new List<News>();


        public async Task<List<News>> GetNews()
        {
            if (newsList?.Count > 0)
                newsList = new List<News>();

            var url = Url;

            var response = await httpClient.GetAsync(url);

            if (response.IsSuccessStatusCode)
            {
                newsList = await response.Content.ReadFromJsonAsync<List<News>>();
            }

            return newsList;
        }

        public async Task<News> GetNews(long Id)
        {

            var news = new News();
            var url = $"{Url}/{Id}";

            var response = await httpClient.GetAsync(url);

            if (response.IsSuccessStatusCode)
            {
                news = await response.Content.ReadFromJsonAsync<News>();
            }

            return news;
        }

        public async Task<News> UpdateNews(News news)
        {
            var id = news.Id;
            var updateUrl = $"{Url}/{id}";
            var response = await httpClient.PutAsJsonAsync(updateUrl, news);

            if (response.IsSuccessStatusCode)
            {
                newsList = await GetNews();
            }

            return news;
        }

        public async Task<News> AddNews(News news)
        {

            Debug.WriteLine(news);
            var response = await httpClient.PostAsJsonAsync(Url, news);
            Debug.WriteLine(response);
            if (response.IsSuccessStatusCode)
            {
                newsList = await GetNews();
            }

            return news;
        }

        public async Task<News> DeleteNews(News news)
        {
            var id = news.Id;
            var deleteUrl = $"{Url}/{id}";
            var response = await httpClient.DeleteAsync(deleteUrl);

            if (response.IsSuccessStatusCode)
            {
                newsList = await GetNews();
            }

            return news;
        }
    }
}
