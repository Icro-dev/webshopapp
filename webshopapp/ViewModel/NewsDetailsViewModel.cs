using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using webshopapp.Models;
using webshopapp.View;
using webshopapp.Services;

namespace webshopapp.ViewModel;

[QueryProperty(nameof(News), "News")]
public partial class NewsDetailsViewModel : BaseViewModel
{
    NewsService newsService;
    public NewsDetailsViewModel(NewsService newsService)
    {
        this.newsService = newsService;
    }

    [ObservableProperty]
    News news;

    [ICommand]
    async Task GoBack()
    {
        await Shell.Current.GoToAsync("..");
    }

    [ICommand]
    async Task UpdateNews(News news)
    {
        if (IsBusy)
            return;

        try
        {
            IsBusy = true;
            var newsPost = await newsService.UpdateNews(news);
            Debug.WriteLine(newsPost);
            await Shell.Current.GoToAsync("..");

        }
        catch (Exception ex)
        {
            Debug.WriteLine($"Unable to update news: {ex.Message}");
            await Shell.Current.DisplayAlert("Error!", ex.Message, "OK");
        }
        finally
        {
            IsBusy = false;
        }
    }

    [ICommand]
    async Task DeleteNews(News news)
    {
        if (IsBusy)
            return;

        try
        {
            IsBusy = true;
            var newsPost = await newsService.DeleteNews(news);
            Debug.WriteLine(newsPost);
            await Shell.Current.GoToAsync("..");

        }
        catch (Exception ex)
        {
            Debug.WriteLine($"Unable to delete news: {ex.Message}");
            await Shell.Current.DisplayAlert("Error!", ex.Message, "OK");
        }
        finally
        {
            IsBusy = false;
        }
    }
}
