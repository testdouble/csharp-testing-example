using static Selenium.Test.Support.Browser;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;

namespace Selenium.Test.ToDo {
    public class ToDoUtil {
        public static void AddToDo(string text) {
            Any("#new-todo").SendKeys(text + "\n");
        }

        public static IWebElement ToDoAt(int index) {
            return ToDoAt(index, false);
        }

        public static IWebElement ToDoAt(int index, bool immediate) {
            var selector = $"#todo-list li:nth-child({index + 1})";
            return immediate ? AnyImmediate(selector) : Any(selector);
        }

        public static void MarkToDoDone(IWebElement toDo) {
            Any(toDo, "input.check").Click();
        }

        public static bool IsDone(IWebElement toDo) {
            return AnyImmediate(toDo, ".todo.done") != null;
        }

        public static void DeleteToDo(IWebElement toDo) {
            new Actions(Driver).MoveToElement(toDo).MoveToElement(Any(toDo, ".todo-destroy")).Click().Build().Perform();
        }

        public static void ClearDoneToDos() {
            Any(".todo-clear").Click();
        }
    }
}