using UnitTestWithBookServices.API.Models;

namespace UnitTestWithBookServices.API.Data
{
    public class InMemoryBookRepository : IBookRepository
    {
        private readonly List<Book> _books = new();
        private int _nextId = 1;

        public Task<Book> AddAsync(Book book)
        {
            book.Id = _nextId++;
            _books.Add(book);
            return Task.FromResult(book);
        }

        public Task<bool> ExistsByTitleAsync(string title)
        {
            var exists = _books.Any(b => b.Title.Equals(title, StringComparison.OrdinalIgnoreCase));
            return Task.FromResult(exists);
        }

        public Task<IEnumerable<Book>> GetAllAsync()
        {
            return Task.FromResult<IEnumerable<Book>>(_books);
        }

        public Task<Book?> GetByIdAsync(int id)
        {
            var book = _books.FirstOrDefault(b => b.Id == id);
            return Task.FromResult(book);

        }
    }
}
