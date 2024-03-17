using BookCatalog.Data;
using BookCatalog.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookCatalog
{
    internal class Utilities
    {

        public static void AddBook()
        {
            Console.WriteLine("Enter the title of the book: ");
            string title = Console.ReadLine();
            Console.WriteLine("Enter the genre of the book: ");
            string genre = Console.ReadLine();
            Book book = new Book(title, genre);
            using (BookCatalogContext context = new BookCatalogContext())
            {
                context.Books.Add(book);
                context.SaveChanges();
            }
        }

        public static void AddAuthor()
        {
            Console.WriteLine("Enter the first name of the author: ");
            string firstName = Console.ReadLine();
            Console.WriteLine("Enter the last name of the author: ");
            string lastName = Console.ReadLine();
            Author author = new Author(firstName, lastName);
            using (BookCatalogContext context = new BookCatalogContext())
            {
                context.Authors.Add(author);
                context.SaveChanges();
            }
        }
    }
}
