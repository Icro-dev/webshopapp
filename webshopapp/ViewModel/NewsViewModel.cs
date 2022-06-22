using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using webshopapp.Services;
using webshopapp.View;

namespace webshopapp.ViewModel
{
    public partial class NewsViewModel : BaseViewModel
    {
        public ObservableCollection<News> NewsItems { get; } = new();
        NewsService newsService;

        [ObservableProperty]
        News news;

        public string Author { get; set; }

        public string ArticleTitle { get; set; }

        public string ArticleText { get; set; }
        
        public DateTime CreatedDate { get; set; }


        public News newsTest { get; set; }

        public NewsViewModel(NewsService newsService)
        {
            Title = "News Page";
            this.newsService = newsService;
        }

        [ICommand]
        async Task GoToNewsDetails(News news)
        {
            if (news == null)
                return;
            try
            {
                await Shell.Current.GoToAsync(nameof(NewsDetailsPage), true, new Dictionary<string, object>
                {
                    {"News", news }
                });
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Unable to go to details: {ex.Message}");
                await Shell.Current.DisplayAlert("Error!", ex.Message, "OK");
            }
            finally
            {
                IsBusy = false;
            }
        }
            

        [ICommand]
        async Task GetNews()
        {
            if (IsBusy)
                return;

            try
            {
                IsBusy = true;
                var news = await newsService.GetNews();

                if (NewsItems.Count != 0)
                    NewsItems.Clear();

                foreach (var newsItem in news)
                    NewsItems.Add(newsItem);

            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Unable to get news: {ex.Message}");
                await Shell.Current.DisplayAlert("Error!", ex.Message, "OK");
            }
            finally
            {
                IsBusy = false;
            }

        }

        [ICommand]
        async Task ToPostPage()
        {
            if (IsBusy)
                return;

            try
            {
                IsBusy = true;
                await Shell.Current.GoToAsync(nameof(PostNewsPage));

            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Unable to get news: {ex.Message}");
                await Shell.Current.DisplayAlert("Error!", ex.Message, "OK");
            }
            finally
            {
                IsBusy = false;
            }

        }

        [ICommand]
        async Task PostArticle(News news)
        {
            if (IsBusy)
                return;

            try
            {

                IsBusy = true;

                var Postnews = new News()
                {
                    Title = ArticleTitle,
                    Author = Author,
                    CreatedDate = CreatedDate,
                    ArticleText = ArticleText,
                };
                Debug.WriteLine(Postnews);
                var newsPost = await newsService.AddNews(Postnews);
                Debug.WriteLine(newsPost);
                await Shell.Current.GoToAsync("..");

            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Unable to post news: {ex.Message}");
                await Shell.Current.DisplayAlert("Error!", ex.Message, "OK");
            }
            finally
            {
                IsBusy = false;
            }

        }
    }
}
