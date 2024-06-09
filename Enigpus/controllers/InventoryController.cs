using Enigpus.entities;
using Enigpus.services;

namespace Enigpus.controllers;

public class InventoryController
{
    private readonly IInventoryService _inventoryService = new InventoryService();

    public void Run()
    {
        MainMenu();
    }

    private void MainMenu()
    {
        while (true)
        {
            Console.WriteLine("1. Add book");
            Console.WriteLine("2. Search book");
            Console.WriteLine("3. View all books");
            Console.WriteLine("4. Exit");
            Console.Write("Choose an option: ");

            var option = Console.ReadLine();

            switch (option)
            {
                case "1":
                    AddBook();
                    break;
                case "2":
                    SearchBook();
                    break;
                case "3":
                    ViewAllBooks();
                    break;
                case "4":
                    return;
                default:
                    Console.WriteLine("Invalid option");
                    break;
            }
        }
    }
    
     private void AddBook()
    {
        Console.WriteLine("1. Add novel");
        Console.WriteLine("2. Add magazine");
        Console.Write("Choose an option: ");
        var option = Console.ReadLine();

        switch (option)
        {
            case "1":
                AddNovel();
                break;
            case "2":
                AddMagazine();
                break;
            default:
                Console.WriteLine("Invalid option");
                break;
        }
    }

    private void AddNovel()
    {
        Console.Write("Enter book code: ");
        var code = Console.ReadLine();
        Console.Write("Enter book title: ");
        var title = Console.ReadLine();
        Console.Write("Enter book publisher: ");
        var publisher = Console.ReadLine();
        Console.Write("Enter year published: ");
        var yearPublished = int.Parse(Console.ReadLine() ?? string.Empty);
        Console.Write("Enter author: ");
        var author = Console.ReadLine();
        
        var novel = new Novel
        {
            Code = code,
            Title = title,
            Publisher = publisher,
            YearPublished = yearPublished,
            Author = author
        };

        _inventoryService.AddBook(novel);
    }
    
    private void AddMagazine()
    {
        Console.Write("Enter book code: ");
        var code = Console.ReadLine();
        Console.Write("Enter book title: ");
        var title = Console.ReadLine();
        Console.Write("Enter book publisher: ");
        var publisher = Console.ReadLine();
        Console.Write("Enter year published: ");
        var yearPublished = int.Parse(Console.ReadLine() ?? string.Empty);
        
        var magazine = new Magazine
        {
            Code = code,
            Title = title,
            Publisher = publisher,
            YearPublished = yearPublished
        };

        _inventoryService.AddBook(magazine);
    }
    
    private void ViewAllBooks()
    {
        var books = _inventoryService.GetAllBook();
        foreach (var book in books)
        {
            switch (book)
            {
                case Novel novel:
                    Console.WriteLine(new string('=', 50));
                    Console.WriteLine("Novel");
                    Console.WriteLine(new string('=', 50));
                    Console.WriteLine($"Code: {novel.Code}");
                    Console.WriteLine($"Title: {novel.GetTitle()}");
                    Console.WriteLine($"Publisher: {novel.Publisher}");
                    Console.WriteLine($"Year Published: {novel.YearPublished}");
                    Console.WriteLine($"Author: {novel.Author}");
                    Console.WriteLine();
                    break;
                case Magazine magazine:
                    Console.WriteLine(new string('=', 50));
                    Console.WriteLine("Magazine");
                    Console.WriteLine(new string('=', 50));
                    Console.WriteLine($"Code: {magazine.Code}");
                    Console.WriteLine($"Title: {magazine.GetTitle()}");
                    Console.WriteLine($"Publisher: {magazine.Publisher}");
                    Console.WriteLine($"Year Published: {magazine.YearPublished}");
                    Console.WriteLine();
                    break;
            }
        }
    }
    
    private void SearchBook()
    {
        Console.Write("Enter book title: ");
        var title = Console.ReadLine();
        
        var books = _inventoryService.SearchBook(title ?? throw new InvalidOperationException());
        foreach (var book in books)
        {
            Console.WriteLine($"Code: {book.Code}");
            Console.WriteLine($"Title: {book.GetTitle()}");
            Console.WriteLine($"Publisher: {book.Publisher}");
            Console.WriteLine($"Year Published: {book.YearPublished}");
            Console.WriteLine();
        }
    }
}