using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace webshopapp.Models
{
    [Table("Cart")]
    public class Cart
    {
        [PrimaryKey, AutoIncrement]
        public long CartId { get; set; }
        public string? Username { get; set; }
        
    }
}
