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

namespace webshopapp.Services;

public class ProductService
{
    HttpClient httpClient;
    static string BaseUrl = DeviceInfoHelper.BaseUrl;
    public string Url = $"{BaseUrl}/Products";

    public ProductService()
    {
        this.httpClient = new HttpClient();
    }

    List<Product> productList;
    public async Task<List<Product>> GetProducts()
    {
        if (productList?.Count > 0)
        return productList;

        var response = await httpClient.GetAsync("https://liquidizerapi.tk/api/Products/");

        if (response.IsSuccessStatusCode)
        {
            productList = await response.Content.ReadFromJsonAsync<List<Product>>();
        }
            Debug.WriteLine(productList);
            Debug.WriteLine(response);

        return productList;
    }

    public async Task <Product> GetProduct(long productsId)
    {
            var product = new Product();
            var url = $"{Url}/{productsId}";

            var response = await httpClient.GetAsync(url);
            Debug.WriteLine(response);
            if (response.IsSuccessStatusCode)
            {
            product = await response.Content.ReadFromJsonAsync<Product>();
            }

            return product;
    }
}

