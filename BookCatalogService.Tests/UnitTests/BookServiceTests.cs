using FluentAssertions;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitTestWithBookServices.API.Data;
using UnitTestWithBookServices.API.Models;
using UnitTestWithBookServices.API.Services;
using Xunit;

namespace BookCatalogService.Tests.UnitTests
{
    public class BookServiceTests
    {
        [Fact]
        public async Task AddBookIfNotExistsAsync_ShouldAddBook_WhenBookDoesNotExist()
        {
            //mocking IRepo
            var repoMock = new Mock<IBookRepository>();
            var bookIn = new Book { Title = "Test Title", Author = "Author" };

            //setting up rules 


            repoMock.Setup(r => r.ExistsByTitleAsync(bookIn.Title)).ReturnsAsync(true);

            var svc = new BookService(repoMock.Object);

            await Assert.ThrowsAsync<InvalidOperationException>(() => svc.AddBookAsync(bookIn));
            
            repoMock.Verify(r => r.AddAsync(It.IsAny<Book>()), Times.Never);


        }
    }
}
