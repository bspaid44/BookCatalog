﻿// See https://aka.ms/new-console-template for more information
using BookCatalog;
using BookCatalog.Data;
using BookCatalog.Models;
using Microsoft.Extensions.DependencyInjection;

using (BookCatalogContext context = new BookCatalogContext())
{
    context.Database.EnsureCreated();
}

string userOption;

do
{
    Console.WriteLine("Welcome to the Book Catalog!");
    using (BookCatalogContext context = new BookCatalogContext())
    {
        var books = context.Books.ToList();
        Console.WriteLine($"There are {books.Count} books in the catalog.");
    }
    Console.WriteLine("Please select an option:");
    Console.WriteLine("1. Add a book");
    Console.WriteLine("2. View all books");
    Console.WriteLine("3. View all authors");
    Console.WriteLine("4. Remove a book");
    Console.WriteLine("9. Exit");

    userOption = Console.ReadLine();

    switch (userOption)
    {
        case "1":
            Utilities.AddBook();
            break;
        case "2":
            Utilities.GetBooks();
            break;
        case "3":
            Utilities.GetAuthors();
            break;
        case "4":
            Utilities.RemoveBook();
            break;
        case "9":
            Console.WriteLine("Goodbye!");
            break;
        default:
            Console.WriteLine("Invalid option. Please try again.");
            break;
    }
} 
while (userOption != "9");
    