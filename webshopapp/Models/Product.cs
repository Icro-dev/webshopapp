using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace webshopapp.Models
{
    [Table("Products")]
    public class Product
    {
        [PrimaryKey]
        public long ProductsId { get; set; }
        public string? Name { get; set; }
        public DateTime? AvailableSince { get; set; }
        public string? Property1 { get; set; }
        public string? Property2 { get; set; }
        public string? Property3 { get; set; }
        public string? Property4 { get; set; }
        public string? Property5 { get; set; }
        public string? Property6 { get; set; }
        public string? Property7 { get; set; }
        public string? Property8 { get; set; }
        public string? Property9 { get; set; }
        public string? Property10 { get; set; }
        public string? Property11 { get; set; }
        public string? Property12 { get; set; }
        public string? Property13 { get; set; }
        public string? Property14 { get; set; }
        public string? Property15 { get; set; }
        public string? Property16 { get; set; }
        public string? Property17 { get; set; }
        public string? Property18 { get; set; }
        public string? Property19 { get; set; }
        public string? Property20 { get; set; }
        public string? Property21 { get; set; }
        public string? Property22 { get; set; }
        public string? Property23 { get; set; }
        public string? Property24 { get; set; }
        public string? Property25 { get; set; }
        public double? Price { get; set; }
        public bool? IsAvailable { get; set; }
    }

}

