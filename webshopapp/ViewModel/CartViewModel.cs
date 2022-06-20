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

namespace webshopapp.ViewModel
{
    public partial class CartViewModel : BaseViewModel
    {
        public ObservableCollection<Product> Products { get; } = new();
        ProductService productService;
        CartRepository cartRepository;
        CartItemRepository cartItemRepository;
        UsersService usersService;
        public Cart cart { get; set; } = new();
        public int _CartId = 1;
        public List<CartItem> listOfCartItems = new List<CartItem>();
        public List<Product> listOfProducts = new List<Product>();

        public CartViewModel(ProductService productService, CartRepository cartRepository, CartItemRepository cartItemRepository, UsersService usersService)
        {
            Title = "Cart";
            this.productService = productService;
            this.cartRepository = cartRepository;
            this.cartItemRepository = cartItemRepository;
            this.usersService = usersService; 
        }

        [ICommand]
        async Task GetCartItemsButton()
        {
            if (IsBusy)
                return;

            Debug.WriteLine(_CartId);
            var cartRetrieved = await cartRepository.GetCart(_CartId);
            Debug.WriteLine(cartRetrieved);
            cart.CartId = cartRetrieved.CartId;
            cart.Username = cartRetrieved.Username;

            var cartItems = await cartItemRepository.GetCartItems(_CartId);
            listOfCartItems.AddRange(cartItems);
            var productIds = (from ci in listOfCartItems select ci.ProductsId).ToArray();
            Debug.WriteLine(productIds);
            foreach(long ProductsId in productIds)
            {
                Products.Add(await productService.GetProduct(ProductsId));
            }
            IsBusy = false;
        }

        [ICommand]
        async Task ClearCart()
        {
            if (IsBusy)
                return;

            try
            {
                await cartItemRepository.DeleteCartItems();
                Products.Clear();
                await Shell.Current.GoToAsync(nameof(CartPage));
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Unable to delete items: {ex.Message}");
                await Shell.Current.DisplayAlert("Error!", ex.Message, "OK");
            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}
