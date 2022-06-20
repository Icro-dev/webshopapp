using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace webshopapp.Models
{
    public class News
    {
        public long Id { get; set; }
        public string? Title { get; set; }
        public string? ArticleText { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string? Author { get; set; }
    }
}
