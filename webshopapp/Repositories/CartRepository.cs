using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using webshopapp.Models;

namespace webshopapp.Repositories
{
    public class CartRepository
    {

        public string? StatusMessage { get; set; }

        static SQLiteAsyncConnection conn;

        static async Task Init()
        {
            if(conn != null)
            {
                return;
            }

            var databasePath = Path.Combine(FileSystem.AppDataDirectory, "webshopapp2.db");
            conn = new SQLiteAsyncConnection(databasePath);

            await conn.CreateTableAsync<Product>();
            await conn.CreateTableAsync<CartItem>();
            await conn.CreateTableAsync<Cart>();

        }

        public async Task<long> AddNewCart(Cart cart)
        {
            await Init();
            int result = 0;
            try
            {
                result = await conn.InsertAsync(cart);
                /*StatusMessage = string.Format("{0} record(s) added [Username: {1})", result, cart.Username);*/
                return result;
            }
            catch (Exception ex)
            {
                StatusMessage = string.Format("Failed to add {0}. Error: {1}", cart, ex.Message);
            }
            return result; 
        }

        public async Task<Cart> GetCart(long CartId)
        {
            await Init();
            try
            {

                var result = await conn.FindAsync<Cart>(CartId);
                Debug.WriteLine(result);
            }
            catch (Exception ex)
            {
                StatusMessage = string.Format("Failed to retrieve data. {0}", ex.Message);
            }

            return new Cart();
        }

        public async Task<long>UpdateCart(Cart cart)
        {
            await Init();
            return await conn.UpdateAsync(cart);
        }

        public async Task<long> Delete(Cart cart)
        {
            await Init();
            return await conn.DeleteAsync(cart);
        }

        public async Task<bool> CartExists(long CartId)
        {
            await Init();
            bool exists = false;
            string Cart = "Cart";
            try
            {
                
                exists = await conn.ExecuteScalarAsync<bool>("SELECT EXISTS(SELECT 1 FROM " + Cart + " WHERE CartId = ?)", CartId);
            }
            catch (Exception ex)
            {
                StatusMessage = string.Format("Failed to retrieve data. {0}", ex.Message);
                
            }
            return exists;
        }
    }
}


