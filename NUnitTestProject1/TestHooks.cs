using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using TechTalk.SpecFlow;
using System.Collections.Generic;

namespace NUnitTestProject1
{
    [Binding]
    public class TestHooks
    {
        [Before]
        public void CreateWebDriver(ScenarioContext context)
        {
            List<string> tagsList = new List<string>(context.ScenarioInfo.Tags);
            if (tagsList.Contains("UITest"))
            {
                var options = new ChromeOptions();
                options.AddArgument("--start-maximized");
                options.AddArgument("--disable-notifications");

                context["DRIVER"] = new ChromeDriver(options);
            }
        }

        [After]
        public void CloseWebDriver(ScenarioContext context)
        {
            List<string> tagsList = new List<string>(context.ScenarioInfo.Tags);
            if (tagsList.Contains("UITest"))
            {
                var driver = context["DRIVER"] as IWebDriver;
                driver.Quit();
            }
        }
    }
}
