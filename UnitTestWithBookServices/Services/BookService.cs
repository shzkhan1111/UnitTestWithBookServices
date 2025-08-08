using UnitTestWithBookServices.API.Models;

namespace UnitTestWithBookServices.API.Services
{
    public class BookService : IBookService
    {
        private readonly List<Book> _books = new();
        public Book AddBook(Book book)
        {
            
            if (_books.Any(b=> b.Title == book.Title))
            {
                throw new InvalidOperationException("Book already exist");
            }
            if (string.IsNullOrWhiteSpace(book.Author))
                throw new ArgumentException("Author is required", nameof(book.Author));

            book.Id = _books.Count + 1;
            _books.Add(book);
            return book;
        }
        public Book? GetBookById(int Id)
        {
            return _books.FirstOrDefault(x => x.Id == Id);
        }
        public IEnumerable<Book> GetAllBooks() => _books;
    }
}
