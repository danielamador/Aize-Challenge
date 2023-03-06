using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text;
using TechTalk.SpecFlow;

namespace NUnitTestProject1
{
    class LoginPage : BasePage
    {
        private readonly string usernameId                  = "user-name";
        private readonly string passwordId                  = "password";
        private readonly string loginButtonClass            = "submit-button";
        private static readonly string errorContainerClass  = "error-message-container";
        private readonly string errorTextXPath              = $"//div[contains(@class, $'{errorContainerClass}')]//h3";

        public LoginPage(ScenarioContext scenarioContext) : base(scenarioContext) { }

        public void NavigateToTheLoginPage() => _driver.Url = sauceDemoURL;

        public void LoginWithUsernameAndPassword(string username, string password)
        {
            var usernameInput =_driver.FindElement(By.Id(usernameId));
            usernameInput.SendKeys(username);
            var passwordInput = _driver.FindElement(By.Id(passwordId));
            passwordInput.SendKeys(password);
            var loginButton = _driver.FindElement(By.ClassName(loginButtonClass));
            loginButton.Click();
        }

        public bool IsErrorMessageIsVisible()
        {
            WaitUntilElementIsVisible(By.ClassName(errorContainerClass));
            return true;
        }

        public string GetErrorText() => WaitUntilElementIsVisible(By.ClassName(errorContainerClass)).Text;
    }
}
