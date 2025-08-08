using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitTestWithBookServices.API.Models;
using UnitTestWithBookServices.API.Services;
using Xunit;

namespace BookCatalogService.Tests.UnitTests
{
    public class BookServiceTests
    {
        [Fact]
        public void AddBook_ShouldAssignId_AndReturnBook()
        {
            var service = new BookService();
            var newBook = new Book { Author = string.Empty , Title = "eded"};

            Assert.Throws<ArgumentException>(() => service.AddBook(newBook));
        }
        [Fact]
        public void GetAllBooks_ShouldReturnAllAddedBooks()
        {
            var service = new BookService();
            service.AddBook(new Book { Author = "Author 1", Title = "Title 1" });
            service.AddBook(new Book { Author = "Author 2", Title = "Title 2" });

            // Act
            var books = service.GetAllBooks();

            // Assert
            Assert.Equal(2, books.Count());
            
        }
    }
}
