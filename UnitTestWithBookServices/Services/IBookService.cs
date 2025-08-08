using UnitTestWithBookServices.API.Models;

namespace UnitTestWithBookServices.API.Services
{
    /// <summary>
    /// use services in test so it can be easily replaced
    /// </summary>
    public interface IBookService
    {
        Book AddBook(Book book);
        IEnumerable<Book> GetAllBooks();
    }
}
