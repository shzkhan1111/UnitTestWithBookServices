using System.Collections;
using UnitTestWithBookServices.API.Models;

namespace UnitTestWithBookServices.API.Data
{
    public interface IBookRepository
    {
        Task<Book> AddAsync(Book book);
        Task<IEnumerable<Book>> GetAllAsync();
        Task<Book?> GetByIdAsync(int id);
        Task<bool> ExistsByTitleAsync(string title);

    }
}
