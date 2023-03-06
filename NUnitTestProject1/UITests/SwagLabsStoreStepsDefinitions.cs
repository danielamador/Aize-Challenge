using TechTalk.SpecFlow;
using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using NUnit.Framework;

namespace NUnitTestProject1
{
    [Binding]
    public class SwagLabsStoreStepsDefinitions
    {
        private readonly ScenarioContext _scenarioContext;
        private readonly LoginPage _loginPage;
        private readonly InventoryPage _inventoryPage;
        private readonly CheckoutPage _checkoutPage;

        public SwagLabsStoreStepsDefinitions(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
            _loginPage = new LoginPage(_scenarioContext);
            _inventoryPage = new InventoryPage(_scenarioContext);
            _checkoutPage = new CheckoutPage(_scenarioContext);
            
        }

        [Given(@"I navigate to the Sauce Demo page")]
        public void GivenINavigateToTheSauceDemoPage()
        {
            _loginPage.NavigateToTheLoginPage();
        }

        [When(@"I enter the username ""(.*)"" and password ""(.*)"" and hit the login button")]
        public void WhenIEnterTheUsernameAndPasswordAndHitTheLoginButton(string username, string password)
        {
            _loginPage.LoginWithUsernameAndPassword(username, password);
        }

        [Then(@"I should be logged successfully on the virtual store")]
        public void ThenIShouldBeLoggedSuccessfullyOnTheVirtualStore()
        {
            var isCartVisible = _inventoryPage.IsShoppingCartVisible();
            Assert.IsTrue(isCartVisible);
        }

        [Then(@"I see the error message ""(.*)""")]
        public void ThenISeeTheErrorMessage(string errorMessage)
        {
            var isErrorMessageVisible = _loginPage.IsErrorMessageIsVisible();
            Assert.IsTrue(isErrorMessageVisible);
            var actualErrorMessage = _loginPage.GetErrorText();
            Assert.IsTrue(actualErrorMessage.ToUpper().Contains(errorMessage.ToUpper()));
        }

        [Then(@"I assert the price for the Sauce Labs Bolt T-shirt is ""(.*)""")]
        public void ThenIAssertThePriceForTheSauceLabsBoltT_ShirtIs(string price)
        {
            var actualPrice = _inventoryPage.GetBoltTShirtPrice();
            Assert.AreEqual(actualPrice, price);
        }

        [When(@"I add the Sauce Labs Bolt T-shirt to the basket")]
        public void WhenIAddTheSauceLabsBoltT_ShirtToTheBasket()
        {
            _inventoryPage.ClickAddBoltTShirtToCart();
        }

        [When(@"I go to checkout and enter the user details")]
        public void WhenIGoToCheckoutAndEnterTheUserDetails()
        {
            _inventoryPage.ClickShoppingCart();
            _checkoutPage.ClickCheckout();
            _checkoutPage.FillUserInfoAndClickOnContinue();
        }

        [When(@"I assert the total price is ""(.*)""")]
        public void WhenIAssertTheTotalPriceIs(string price)
        {
            var actualPrice = _checkoutPage.GetTotalPrice();
            Assert.True(actualPrice.Contains(price));
        }

        [Then(@"I finish the order and verify the message ""(.*)""")]
        public void ThenIFinishTheOrderAndVerifyTheMessage(string message)
        {
            var actualMessage =_checkoutPage.FinishOrder();
            Assert.True(actualMessage.ToUpper().Contains(message.ToUpper()));
        }


    }
}
