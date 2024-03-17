using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookCatalog.Models
{
    public class Book
    {
        public int BookId { get; set; }
        public string Title { get; set; }
        public string Genre { get; set; }

        public Book(string title, string genre)
        {
            Title = title;
            Genre = genre;
        }

    }
}
