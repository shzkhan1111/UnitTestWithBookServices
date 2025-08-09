using UnitTestWithBookServices.API.Data;
using UnitTestWithBookServices.API.Models;

namespace UnitTestWithBookServices.API.Services
{
    public class BookService : IBookService
    {
        private readonly IBookRepository _repo;
        public BookService(IBookRepository repo) => _repo = repo;

        public async Task<Book> AddBookAsync(Book book)
        {
            if (string.IsNullOrWhiteSpace(book.Title))
                throw new ArgumentException("Title is required", nameof(book.Title));
            if (string.IsNullOrWhiteSpace(book.Author))
                throw new ArgumentException("Author is required", nameof(book.Author));


            if (await _repo.ExistsByTitleAsync(book.Title))
                throw new InvalidOperationException("Book already exists");

            return await _repo.AddAsync(book);

        }

        public Task<IEnumerable<Book>> GetAllAsync()
        {
            return _repo.GetAllAsync();
        }

        public Task<Book?> GetByIdAsync(int id) => _repo.GetByIdAsync(id);

        public async Task<bool> AddBookIfNotExistsAsync(Book book)
        {
            if (await _repo.ExistsByTitleAsync(book.Title))
            {
                return false; // Book already exists
            }

            await _repo.AddAsync(book);
            return true; // Book added
        }

    }
}
