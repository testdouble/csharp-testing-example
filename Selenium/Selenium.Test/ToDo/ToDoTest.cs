using Selenium.Test.ToDo;
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
            ToDoUtil.AddToDo("Mow the Lawn");

            Assert.Equal("Mow the Lawn", ToDoUtil.ToDoAt(0).Text);
        }

        [Fact]
        public void CreateTwoToDos() {
            ToDoUtil.AddToDo("Shower");
            ToDoUtil.AddToDo("Get dressed");

            Assert.Equal("Shower", ToDoUtil.ToDoAt(0).Text);
            Assert.Equal("Get dressed", ToDoUtil.ToDoAt(1).Text);
        }

        [Fact]
        public void MarksAToDoDone() {
            ToDoUtil.AddToDo("Eat food");
            Assert.False(ToDoUtil.IsDone(ToDoUtil.ToDoAt(0)));

            ToDoUtil.MarkToDoDone(ToDoUtil.ToDoAt(0));

            Assert.True(ToDoUtil.IsDone(ToDoUtil.ToDoAt(0)));
        }

        [Fact]
        public void CanDeleteAToDo() {
            ToDoUtil.AddToDo("Thing");

            ToDoUtil.DeleteToDo(ToDoUtil.ToDoAt(0));

            Assert.Null(ToDoUtil.ToDoAt(0, true));
        }

        [Fact]
        public void ClearCompletedToDos() {
            ToDoUtil.AddToDo("Do stuff");
            ToDoUtil.MarkToDoDone(ToDoUtil.ToDoAt(0));

            ToDoUtil.ClearDoneToDos();

            Assert.Null(ToDoUtil.ToDoAt(0, true));
        }
    }
}