using TechTalk.SpecFlow;
using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using System.Reflection;
using AventStack.ExtentReports.Gherkin.Model;

namespace NUnitTestProject1
{
    // Adapted using the following reference:
    // https://codebun.com/how-to-generate-extent-report-with-specflow-and-selenium-c/
    // https://medium.com/@avadhy03/getting-start-with-specflow-and-extent-report-cb4515c4fd91
    [Binding]
    class ReportHook : Steps
    {
        private static ExtentTest featureName;
        private static ExtentTest scenario;
        private static ExtentReports extent;

        [BeforeTestRun]
        public static void InitializeReport()
        {
            string path = "C:\\Users\\Daniel Amador" + "\\Report\\index.html";
            var htmlReporter = new ExtentHtmlReporter(path);

            extent = new ExtentReports();
            extent.AttachReporter(htmlReporter);
        }

        [BeforeFeature]
        public static void BeforeFeature(FeatureContext featurecontext)
        {
            featureName = extent.CreateTest(featurecontext.FeatureInfo.Title);
        }

        [BeforeScenario]
        public void GrabScenarioName(ScenarioContext scenarioContext)
        {
            scenario = featureName.CreateNode<Scenario>(scenarioContext.ScenarioInfo.Title);
        }

        [AfterStep]
        public void InsertReportingSteps(ScenarioContext scenarioContext)
        {
            var stepType = ScenarioStepContext.Current.StepInfo.StepDefinitionType.ToString();
            PropertyInfo pInfo = typeof(ScenarioContext).GetProperty("ScenarioExecutionStatus", BindingFlags.Instance | BindingFlags.Public);
            MethodInfo getter = pInfo.GetGetMethod(nonPublic: true);
            object TestResult = getter.Invoke(scenarioContext, null);
            string stepInfo = ScenarioStepContext.Current.StepInfo.Text;

            if (scenarioContext.TestError == null)
            {
                switch(stepType)
                {
                    case "Given":
                        scenario.CreateNode<Given>(stepInfo);
                        break;
                    case "When":
                        scenario.CreateNode<When>(stepInfo);
                        break;
                    case "Then":
                        scenario.CreateNode<Then>(stepInfo);
                        break;
                    case "And":
                        scenario.CreateNode<And>(stepInfo);
                        break;
                }
            }
            else 
            {
                string errorMessage = scenarioContext.TestError.Message;
                switch (stepType)
                {
                    case "Given":
                        scenario.CreateNode<Given>(stepInfo).Fail(errorMessage);
                        break;
                    case "When":
                        scenario.CreateNode<When>(stepInfo).Fail(errorMessage);
                        break;
                    case "Then":
                        scenario.CreateNode<Then>(stepInfo).Fail(errorMessage);
                        break;
                    case "And":
                        scenario.CreateNode<And>(stepInfo).Fail(errorMessage);
                        break;
                }
            }
        }

        [AfterTestRun]
        public static void TearDownReport()
        {
            extent.Flush();
        }
    }
}