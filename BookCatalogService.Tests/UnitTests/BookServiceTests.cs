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
            var mockRepo = new Mock<IBookRepository>();

            //setting up rules 

            
            mockRepo.Setup(r => r.ExistsByTitleAsync("Test Book"))
                .ReturnsAsync(false);
            //set up rules if ExistsByTitleAsync is called for "Test Book" return false

            //send the object to Book Service
            var service = new BookService(mockRepo.Object);
            var newBook = new Book { Title = "Test Book" };

            var result = await service.AddBookIfNotExistsAsync(newBook);

            Assert.True(result);
            mockRepo.Verify(r => r.AddAsync(It.IsAny<Book>()), Times.Once);


        }
    }
}
