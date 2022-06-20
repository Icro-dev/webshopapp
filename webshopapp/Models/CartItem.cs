using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace webshopapp.Models
{
    [Table("CartItems")]
    public class CartItem
    {
        [PrimaryKey, AutoIncrement]
        public long CartItemId { get; set; }
        public long ProductsId { get; set; }
        public int? Quantity { get; set; }
        public long CartId { get;set; }
    }
}
