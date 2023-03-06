using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text;
using TechTalk.SpecFlow;

namespace NUnitTestProject1
{
    class InventoryPage : BasePage
    {
        private readonly string shoppingCartClass     = "shopping_cart_link";
        private readonly string addBoltTShirtButtonId = "add-to-cart-sauce-labs-bolt-t-shirt";
        private readonly string boltTShirtPriceXPath = "//div[text()='Sauce Labs Bolt T-Shirt']/../../..//div[@class='inventory_item_price']";

        public InventoryPage(ScenarioContext scenarioContext) : base(scenarioContext) { }

        public bool IsShoppingCartVisible()
        {
            WaitUntilElementIsVisible(By.ClassName(shoppingCartClass));
            return true;
        }

        public void ClickShoppingCart()
        {
            WaitUntilElementIsVisible(By.ClassName(shoppingCartClass)).Click();
        }

        public void ClickAddBoltTShirtToCart()
        {
            WaitUntilElementIsVisible(By.Id(addBoltTShirtButtonId)).Click();
        }

        public string GetBoltTShirtPrice() => WaitUntilElementIsVisible(By.XPath(boltTShirtPriceXPath)).Text;
    }
}
