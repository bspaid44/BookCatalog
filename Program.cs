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
    Console.WriteLine("Please select an option:");
    Console.WriteLine("1. Add a book");
    Console.WriteLine("9. Exit");

    userOption = Console.ReadLine();

    switch (userOption)
    {
        case "1":
            Utilities.AddBook();
            Console.WriteLine("Book added successfully!");
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
    