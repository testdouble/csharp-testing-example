using static Selenium.Test.ToDo.ToDoUtil;
using System;
using OpenQA.Selenium;
using Xunit;
using TechTalk.SpecFlow;
using Selenium.Test.Support;

namespace Selenium.Test.ToDo {
    [Binding]
    public class ToDoSteps : IDisposable {
        private readonly IWebDriver _driver = Browser.Launch();

        public void Dispose() {
            _driver.Quit();
        }

        [Given(@"^I am on the todo page$")]
        public void I_Am_On_The_Todo_Page() {
            _driver.Navigate().GoToUrl("http://testdouble.github.io/todos/");
        }

        [When(@"^I type the todo ""([^\""]*)""$")]
        public void I_Type_The_Todo(string todoText) {
            AddToDo(todoText);
        }

        [Then(@"^todo list item (\d+) has text ""([^\""]*)""$")]
        public void Todo_List_Item_Has_Text(int ordinal, string expected) {
            Assert.Equal(expected, ToDoAt(ordinal - 1).Text);
        }
    }
}