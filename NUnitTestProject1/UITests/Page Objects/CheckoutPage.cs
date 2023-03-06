using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace NUnitTestProject1
{
    class CheckoutPage : BasePage
    {
        private readonly string checkoutButtonId = "checkout";
        private readonly string firstNameId = "first-name";
        private readonly string lastNameId = "last-name";
        private readonly string postalCodeId = "postal-code";
        private readonly string continueButtonId = "continue";
        private readonly string totalPriceLabel = "//div[contains(@class, 'summary_total_label')]";
        private readonly string finishButtonId = "finish";
        private readonly string orderCompleteTextClass = "complete-header";

        public CheckoutPage(ScenarioContext scenarioContext) : base(scenarioContext) { }

        public void ClickCheckout()
        {
            WaitUntilElementIsVisible(By.Id(checkoutButtonId)).Click();
        }

        public void FillUserInfoAndClickOnContinue()
        {
            _driver.FindElement(By.Id(firstNameId)).SendKeys("Joseph");
            _driver.FindElement(By.Id(lastNameId)).SendKeys("Silva");
            _driver.FindElement(By.Id(postalCodeId)).SendKeys("postal-code");
            _driver.FindElement(By.Id(continueButtonId)).Click();
        }

        public string GetTotalPrice() => _driver.FindElement(By.XPath(totalPriceLabel)).Text;

        public string FinishOrder()
        {
            _driver.FindElement(By.Id(finishButtonId)).Click();
            return WaitUntilElementIsVisible(By.ClassName(orderCompleteTextClass)).Text;
        }
    }
}
