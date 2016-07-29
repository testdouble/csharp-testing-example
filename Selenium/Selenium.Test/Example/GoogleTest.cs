using System;
using Xunit;
using OpenQA.Selenium;
using Selenium.Test.Support;

namespace Selenium.Test.Example {
    public class GoogleTest : IDisposable {
        private readonly IWebDriver _driver = Browser.Launch();

        public void Dispose() {
            _driver.Quit();
        }

        [Fact]
        public void GoogleForCheese() {
            _driver.Navigate().GoToUrl("https://www.google.com");
            var element = _driver.FindElement(By.Name("q"));
            element.SendKeys("Cheese!");

            element.Submit();

            _driver.FindElement(By.Id("res"));
            Assert.Contains("curds", _driver.FindElement(By.TagName("body")).Text);
        }
    }
}