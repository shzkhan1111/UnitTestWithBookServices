using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitTestWithBookServices.API.Services;
using Xunit;

namespace BookCatalogService.Tests.UnitTests
{
    public class ToDoServiceTest
    {
        [Fact]
        public void Add_SavesTodoItem()
        {
            //arrange
            var list = new ToDoList();

            //act
            list.Add(new("Test Content"));
            //assert 

            var  savedItem = Assert.Single(list.All);
            Assert.Equal("Test Content", savedItem.Content);

        }
        [Fact]
        public void TodoItemIdIncrementsEveryTimeWeSave()
        {
            //arrange
            var list = new ToDoList();

            //act
            list.Add(new("Test 1"));
            list.Add(new("Test 2"));
            //assert
            var items = list.All.ToArray();

            Assert.Equal(1, items[0].Id);
            Assert.Equal(2, items[1].Id);


        }
        [Fact]
        public void Complete_SetTodoItemCompletetrue()
        {
            //arrange
            var list = new ToDoList();
            list.Add(new("Test 1"));
            list.Complete(1);
            var completedItem = Assert.Single(list.All);
            Assert.NotNull(completedItem);
            Assert.Equal(1, completedItem.Id);
            Assert.True(completedItem.Complete);
        }
    }
}
