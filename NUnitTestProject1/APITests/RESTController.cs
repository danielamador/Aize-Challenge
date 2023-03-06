using System.Text.Json.Serialization;
using NUnit.Framework;
using RestSharp;

namespace NUnitTestProject1
{
    class RESTController
    {
        RestClient client;

        public string BasePage { set => client = new RestClient("https://petstore.swagger.io/v2"); }

        public User GetUser(string username)
        {
            RestRequest request = new RestRequest($"/user/{username}");
            User response = client.Get<User>(request);
            return response;
        }

        public void InsertUser(User user)
        {
            RestRequest request = new RestRequest($"/user", Method.Post);
            request.AddBody(user);
            RestResponse response = client.Post(request);
            Assert.AreEqual(response.StatusCode.ToString(), "OK");
        }

        public void DeleteUser(string username)
        {
            RestRequest request = new RestRequest($"/user/{username}", Method.Delete);
            RestResponse response = client.Delete(request);
            Assert.AreEqual(response.StatusCode.ToString(), "OK");
        }
    }
}
