using static Selenium.Test.ToDo.ToDoUtil;
using System;
using Xunit;
using OpenQA.Selenium;
using Selenium.Test.Support;

namespace Selenium.Test.ToDo {
    public class ToDoTest : IDisposable {
        private readonly IWebDriver _driver = Browser.Launch();

        public ToDoTest() {
            _driver.Navigate().GoToUrl("http://testdouble.github.io/todos/");
        }

        public void Dispose() {
            _driver.Quit();
        }

        [Fact]
        public void CreateToDo() {
            AddToDo("Mow the Lawn");

            Assert.Equal("Mow the Lawn", ToDoAt(0).Text);
        }

        [Fact]
        public void CreateTwoToDos() {
            AddToDo("Shower");
            AddToDo("Get dressed");

            Assert.Equal("Shower", ToDoAt(0).Text);
            Assert.Equal("Get dressed", ToDoAt(1).Text);
        }

        [Fact]
        public void MarksAToDoDone() {
            AddToDo("Eat food");
            Assert.False(IsDone(ToDoAt(0)));

            MarkToDoDone(ToDoAt(0));

            Assert.True(IsDone(ToDoAt(0)));
        }

        [Fact]
        public void CanDeleteAToDo() {
            AddToDo("Thing");

            DeleteToDo(ToDoAt(0));

            Assert.Null(ToDoAt(0, true));
        }

        [Fact]
        public void ClearCompletedToDos() {
            AddToDo("Do stuff");
            MarkToDoDone(ToDoAt(0));

            ClearDoneToDos();

            Assert.Null(ToDoAt(0, true));
        }
    }
}