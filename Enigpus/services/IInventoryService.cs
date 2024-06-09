using Enigpus.entities;

namespace Enigpus.services;

public interface IInventoryService
{
    void AddBook(Book book);
    IEnumerable<Book> SearchBook(string title);
    List<Book> GetAllBook();
}