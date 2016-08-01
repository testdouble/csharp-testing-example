using System;
using Selenium.Test.Support;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;

namespace Selenium.Test.ToDo {
    public class ToDoUtil {
        public static void AddToDo(string text) {
            Browser.Any("#new-todo").SendKeys(text + "\n");
        }

        public static IWebElement ToDoAt(int index) {
            return ToDoAt(index, false);
        }

        public static IWebElement ToDoAt(int index, bool immediate) {
            var selector = "#todo-list li:nth-child(" + (index + 1) + ")";
            return immediate ? Browser.AnyImmediate(selector) : Browser.Any(selector);
        }

        public static void MarkToDoDone(IWebElement toDo) {
            Browser.Any(toDo, "input.check").Click();
        }

        public static bool IsDone(IWebElement toDo) {
            return Browser.AnyImmediate(toDo, ".todo.done") != null;
        }

        public static void DeleteToDo(IWebElement toDo) {
            new Actions(Browser.Driver).MoveToElement(toDo).MoveToElement(Browser.Any(toDo, ".todo-destroy")).Click().Build().Perform();
        }

        public static void ClearDoneToDos() {
            Browser.Any(".todo-clear").Click();
        }
    }
}