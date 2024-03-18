﻿using BookCatalog.Data;
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
                Console.WriteLine("Book added successfully!");
            }
        }

        public static void RemoveBook()
        {
            Console.WriteLine("Enter the title of the book you want to remove: ");
            string title = Console.ReadLine();
            try
            {
                using (BookCatalogContext context = new BookCatalogContext())
                {
                    var book = context.Books.Where(b => b.Title == title).FirstOrDefault();
                    context.Books.Remove(book);
                    context.SaveChanges();
                    Console.WriteLine("Book removed successfully!");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("The title does not match any book in the catalog");
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

        public static void EditBook()
        {
            using (BookCatalogContext context = new BookCatalogContext())
            {
                var books = context.Books.ToList();
                Console.WriteLine("Enter the title of the book you want to edit: ");
                string title = Console.ReadLine();
                Book book = context.Books.Where(b => b.Title == title).FirstOrDefault();
                
                if (book == null)
                {
                    Console.WriteLine("\n" + "The title does not match any book in the catalog");
                    return;
                }

                Console.WriteLine("What would you like to edit: ");
                Console.WriteLine("1. Title");
                Console.WriteLine("2. Genre");
                Console.WriteLine("9. Exit");
                string userOption = Console.ReadLine();

                switch (userOption)
                {
                    case "1":

                        Console.WriteLine("Enter the new title of the book: ");
                        string newTitle = Console.ReadLine();
                        book.Title = newTitle;
                        context.SaveChanges();
                        Console.WriteLine("Book edited successfully!");
                        break;
                    case "2":
                        Console.WriteLine("Enter the new genre of the book: ");
                        string newGenre = Console.ReadLine();
                        book.Genre = newGenre;
                        context.SaveChanges();
                        Console.WriteLine("Book edited successfully!");
                        break;
                    case "9":
                        Console.WriteLine("Goodbye!");
                        break;
                    default:
                        Console.WriteLine("Invalid option. Please try again.");
                        break;
                }
            }
        }
    }
}
