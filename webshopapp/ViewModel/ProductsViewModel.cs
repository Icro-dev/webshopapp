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

namespace webshopapp.ViewModel;

public partial class ProductsViewModel : BaseViewModel
{
    public ObservableCollection<Product> Products { get; } = new();
    ProductService productService;

    public ProductsViewModel(ProductService productService)
    {
        Title = "Products";
        this.productService = productService;
    }

    [ICommand]
    async Task GoToDetails(Product product)
    {
        if (product == null)
            return;

        await Shell.Current.GoToAsync(nameof(DetailsPage), true, new Dictionary<string, object>
        {
            {"Product", product }
        });
    }

    [ICommand]
    async Task GetProductsAsync()
    {
        if (IsBusy)
            return;

        try
        {
            IsBusy = true;
            var products = await productService.GetProducts();

            if (Products.Count != 0)
                Products.Clear();

            foreach (var product in products)
                Products.Add(product);

        }
        catch (Exception ex)
        {
            Debug.WriteLine($"Unable to get products: {ex.Message}");
            await Shell.Current.DisplayAlert("Error!", ex.Message, "OK");
        }
        finally
        {
            IsBusy = false;
        }

    }

    [ICommand]
    async Task GoToLogin()
    {
            await Shell.Current.GoToAsync(nameof(LoginPage));
    }


}


