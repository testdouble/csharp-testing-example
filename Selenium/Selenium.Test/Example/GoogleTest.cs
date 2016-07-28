using OpenQA.Selenium;
using Xunit;
using Selenium.Test.Support;

namespace Selenium.Test.Example {
    public class GoogleTest {
        private IWebDriver _driver = Browser.Launch();

        [Fact]
        public void GoogleForChees() {
        }
    }
}