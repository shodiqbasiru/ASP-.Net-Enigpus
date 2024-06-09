using Enigpus.entities;

namespace Enigpus.services;

public class InventoryService : IInventoryService
{
    private readonly List<Book> _books = new List<Book>();

    public void AddBook(Book book)
    {
        _books.Add(book);
    }

    public IEnumerable<Book> SearchBook(string title)
    {
       return _books.Where(book => book.GetTitle().Contains(title, StringComparison.CurrentCultureIgnoreCase));
    }

    public List<Book> GetAllBook()
    {
        return _books;
    }
}