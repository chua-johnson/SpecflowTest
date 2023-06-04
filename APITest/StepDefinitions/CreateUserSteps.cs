using TechTalk.SpecFlow;
using RestSharp;
using NUnit.Framework;
using Newtonsoft.Json;

namespace APITest.StepDefinitions
{
    [Binding]
    [Scope(Tag = "@CreateUser")]
    public class CreateUserSteps
    {
        private RestClient? client;
        private RestRequest? request;
        private RestResponse? response;

        [Given(@"I have a valid user payload")]
        public void GivenIHaveAValidUserPayload()
        {
            client = new RestClient("https://reqres.in");
            request = new RestRequest("/api/users", Method.Post);
            request.AddJsonBody(new { name = "John Doe", job = "Software Developer" });
        }

        [When(@"I send a POST request to ""([^""]*)""")]
        public void WhenISendAPOSTRequestTo(string endpoint)
        {
            request.Resource = endpoint;
            response = client?.Execute(request);
        }

        [Then(@"the response status code should be (.*)")]
        public void ThenTheResponseStatusCodeShouldBe(int statusCode)
        {
            Assert.AreEqual(statusCode, (int)response.StatusCode);
        }

        [Then(@"the response body should contain the user ID")]
        public void ThenTheResponseBodyShouldContainTheUserID()
        {
            dynamic? responseBody = JsonConvert.DeserializeObject(response.Content);
            Assert.IsNotNull(responseBody?.id);
        }

        

        [Given(@"I have an invalid user payload")]
        public void GivenIHaveAnInvalidUserPayload()
        {
            client = new RestClient("https://reqres.in");
            request = new RestRequest("/api/users", Method.Post);
            request.AddJsonBody(new { namex = "John Doe", job = "Software Developer" });
        }

        [When(@"I call a POST request to ""([^""]*)""")]
        public void WhenICallAPOSTRequestTo(string endpoint)
        {
            request.Resource = endpoint;
            response = client?.Execute(request);
        }

        [Then(@"the invalid response status code should be (.*)")]
        public void ThenTheInvalidResponseStatusCodeShouldBe(int statusCode)
        {
            Assert.AreEqual(statusCode, (int)response.StatusCode);
        }

        

    }
}
