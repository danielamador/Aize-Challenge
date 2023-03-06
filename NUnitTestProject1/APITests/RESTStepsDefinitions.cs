using TechTalk.SpecFlow;

namespace NUnitTestProject1
{
    [Binding]
    public class RESTStepsDefinitions
    {
        private readonly RESTController controller;
        private User user;

        public RESTStepsDefinitions()
        {
            controller = new RESTController();
            user = new User();
        }

        [Given(@"I intend to access the API located at ""(.*)""")]
        public void GivenIIntendToAccessTheAPILocatedAt(string url)
        {
            controller.BasePage = url;
        }

        [When(@"I have inserted a user ""(.*)""")]
        public void WhenIHaveInsertedAUser(string username)
        {
            user.Id = 98765;
            user.Username = username;
            user.UserStatus = 0;
            controller.InsertUser(user);
        }


        [Then(@"I get the info for user ""(.*)""")]
        public void WhenIGetTheInfoForUser(string username)
        {
            user = controller.GetUser(username);
        }

        [Then(@"I delete the information for that user ""(.*)""")]
        public void ThenIDeleteTheInformationForThatUser(string username)
        {
            controller.DeleteUser(username);
        }


    }
}
