using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
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
        public Author Author { get; set; }
        [ForeignKey("AuthorId")]
        public int AuthorId { get; set; }
        

        public Book()
        {

        }

        public Book(string title, string genre, Author author)
        {
            Title = title;
            Genre = genre;
            Author = author;
        }

    }
}
