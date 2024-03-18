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
            Console.WriteLine("Enter the first name of the author: ");
            string firstName = Console.ReadLine();
            Console.WriteLine("Enter the last name of the author: ");
            string lastName = Console.ReadLine();
            Author author = new Author(firstName, lastName);
            Console.WriteLine("Enter the title of the book: ");
            string title = Console.ReadLine();
            Console.WriteLine("Enter the genre of the book: ");
            string genre = Console.ReadLine();
            Book book = new Book(title, genre, author);
            using (BookCatalogContext context = new BookCatalogContext())
            {
                context.Books.Add(book);
                context.Authors.Add(author);
                context.SaveChanges();
            }
        }

        public static void GetBooks()
        {
            using (BookCatalogContext context = new BookCatalogContext())
            {
                var books = context.Books.ToList();
                var authors = context.Authors.ToList();
                foreach (var book in books)
                {
                    foreach (var author in authors)
                    {
                        if (book.AuthorId == author.AuthorId)
                        {
                            book.Author = author;
                        }
                    }
                    Console.WriteLine($"Title: {book.Title}, Genre: {book.Genre}, Author: {book.Author.FirstName} {book.Author.LastName}");
                }
            }
        }

        public static void GetAuthors()
        {
            using (BookCatalogContext context = new BookCatalogContext())
            {
                var authors = context.Authors.ToList();
                foreach (var author in authors)
                {
                    Console.WriteLine($"Author: {author.FirstName} {author.LastName}");
                }
            }
        }
    }
}
