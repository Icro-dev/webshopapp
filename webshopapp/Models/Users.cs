using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
namespace webshopapp.Models
{
    [Table("Users")]
    public class Users
    {
            [PrimaryKey]
            public string username { get; set; }
            public string password { get; set; }
            public string role { get; set; }
            public double latitude { get; set; }
            public double longitude { get; set; }
            public string street { get; set; }
            public string houseNumber { get; set; }
            public string zipcode { get; set; }
            public string city { get; set; }
    }
}
