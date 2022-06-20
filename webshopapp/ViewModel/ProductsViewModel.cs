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
using webshopapp.Repositories;

namespace webshopapp.ViewModel;

public partial class ProductsViewModel : BaseViewModel
{
    public ObservableCollection<Product> Products { get; } = new();
    ProductService productService;
    CartRepository cartRepository;
    CartItemRepository cartItemRepository;
    UsersService usersService;
    public Cart cart { get; set; } = new();
    public long CartId { get; set; }
    

    public ProductsViewModel(ProductService productService, CartRepository cartRepository, CartItemRepository cartItemRepository, UsersService usersService)
    {
        Title = "Products";
        this.productService = productService;
        this.cartRepository = cartRepository;
        this.cartItemRepository = cartItemRepository;
        this.usersService = usersService;
    }


    [ICommand]
    async Task AddProductToCart(Product product)
    {
        if (IsBusy)
            return;

        try
        {

            var CartItem = new CartItem
            {
                ProductsId = product.ProductsId,
                Quantity = 1,
                CartId = 1
            };
            Debug.WriteLine(isLoggedIn);
            Debug.WriteLine(product);
            Debug.WriteLine(CartItem);
            Debug.WriteLine(usernamePref);
            
            await cartItemRepository.AddNewCartItem(CartItem);
            

        }
        catch (Exception ex)
        {
            Debug.WriteLine($"Unable to get products: {ex.Message}");
            await Shell.Current.DisplayAlert("Error!", ex.Message, "OK");
        }
    }

    [ICommand]
    async Task ShowCart()
    {
        try
        {
            if (!isLoggedIn)
            {
                await Shell.Current.GoToAsync(nameof(LoginPage));
            }
            if (isLoggedIn)
            {

                var username = usernamePref;
                Debug.WriteLine(username);
                cart.Username = username;
                
                Debug.WriteLine(cart);
                Debug.WriteLine(cart.Username);
                long numberLong = 1;
                Convert.ToInt64(numberLong);
                var CartExists = await cartRepository.CartExists(numberLong);

                Debug.WriteLine(CartExists);
                if (!CartExists)
                {
                    await cartRepository.AddNewCart(cart);
                }
                else
                {
                    CartId = numberLong;
                    Preferences.Set("CartId", CartId);
                    Debug.WriteLine(CartId);
                }

            
                await Shell.Current.GoToAsync(nameof(CartPage));
            }

        }
        catch (Exception ex)
        {
            Debug.WriteLine($"Unable to show cart: {ex.Message}");
            await Shell.Current.DisplayAlert("Error!", ex.Message, "OK");
        }

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


