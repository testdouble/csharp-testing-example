using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;

namespace Selenium.Test.Support {
    public class Browser {
        public static readonly int DefaultTimeout = 5;
        public static IWebDriver Driver;
        public static readonly string BrowserName = "firefox";

        public static IWebDriver Launch() {
            Driver = CreateDriver();
            Driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(DefaultTimeout));
            return Driver;
        }

        public static IWebElement Any(string css) {
            return Any(Driver.FindElement(By.CssSelector("html")), css);
        }

        public static IWebElement Any(IWebElement parent, string css) {
            try {
                return parent.FindElement(By.CssSelector(css));
            }
            catch (NoSuchElementException) {
                return null;
            }
        }

        public static IWebElement AnyImmediate(string css) {
            return AnyImmediate(Driver.FindElement(By.CssSelector("html")), css);
        }

        public static IWebElement AnyImmediate(IWebElement parent, string css) {
            Driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromMilliseconds(10));
            var el = Any(parent, css);
            Driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(DefaultTimeout));
            return el;
        }

        public static IWebDriver CreateDriver() {
            if (BrowserName.Equals("firefox")) {
                return new FirefoxDriver();
            }
            if (BrowserName.Equals("chrome")) {
                return new ChromeDriver();
            }
            if (BrowserName.Equals("msie")) {
                return new InternetExplorerDriver();
            }
            throw new ArgumentException($"Unrecognized browser: {BrowserName}");
        }
    }
}