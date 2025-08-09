using UnitTestWithBookServices.API.Models;

namespace UnitTestWithBookServices.API.Services
{
    /// <summary>
    /// use services in test so it can be easily replaced
    /// </summary>
    public interface IBookService
    {
        Task<Book> AddBookAsync(Book book);
        Task<IEnumerable<Book>> GetAllAsync();
        Task<Book?> GetByIdAsync(int id);
    }

}
