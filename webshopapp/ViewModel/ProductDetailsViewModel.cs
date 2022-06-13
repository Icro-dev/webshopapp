using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using webshopapp.Models;
using webshopapp.View;

namespace webshopapp.ViewModel;
[QueryProperty(nameof(Product), "Product")]
public partial class ProductDetailsViewModel : BaseViewModel
{
    public ProductDetailsViewModel()
    {

    }

    [ObservableProperty]
    Product product;

    [ICommand]
    async Task GoBack()
    {
        await Shell.Current.GoToAsync("..");
    }
}
