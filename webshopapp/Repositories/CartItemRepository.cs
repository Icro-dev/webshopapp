using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using webshopapp.Models;

namespace webshopapp.Repositories
{
    public class CartItemRepository
    {

        public string? StatusMessage { get; set; }

        static SQLiteAsyncConnection conn;

        static async Task Init()
        {
            if (conn != null)
            {
                return;
            }

             var databasePath = Path.Combine(FileSystem.AppDataDirectory, "webshopapp2.db");
             conn = new SQLiteAsyncConnection(databasePath);

            await conn.CreateTableAsync<Product>();
            await conn.CreateTableAsync<CartItem>();
            await conn.CreateTableAsync<Cart>();
        }


        public async Task<long> AddNewCartItem(CartItem cartItem)
        {
            await Init();
            int result = 0;
            try
            {

                result = await conn.InsertAsync(cartItem);
                /*StatusMessage = string.Format("{0} record(s) added (CartItemProduct: {1})", result, cartItem.CartItemProduct);*/
                return result;
            }
            catch (Exception ex)
            {
                StatusMessage = string.Format("Failed to add {0}. Error: {1}", ex.Message, cartItem);
            }
            return result;
        }

        public async Task<List<CartItem>> GetCartItems(long CartItemId)
        {
            await Init();
            try
            {

                return await conn.QueryAsync<CartItem>("SELECT * FROM CartItems WHERE CartId = ?", CartItemId);
            }
            catch (Exception ex)
            {
                StatusMessage = string.Format("Failed to retrieve data. {0}", ex.Message);
            }

            return new List<CartItem>();
        }

        public async Task<int> DeleteCartItems()
        {
            await Init();
            try
            {

                return await conn.DeleteAllAsync<CartItem>();
            }
            catch (Exception ex)
            {
                StatusMessage = string.Format("Failed to delete items. {0}", ex.Message);
            }

            return 0;
        }
    }
}



