using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using TechTalk.SpecFlow;

namespace NUnitTestProject1
{
    class BasePage
    {
        protected IWebDriver _driver;
        protected static string sauceDemoURL = "https://www.saucedemo.com/";

        public BasePage(ScenarioContext scenarioContext)
        {
            _driver = (IWebDriver) scenarioContext["DRIVER"];
        }

        protected IWebElement WaitUntilElementIsVisible(By by, int timeout = 20)
        {
            var wait = new WebDriverWait(_driver, new TimeSpan(0, 0, timeout));
            var element = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(by));
            return element;
        }
    }
}
