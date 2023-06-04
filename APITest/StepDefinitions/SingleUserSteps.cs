using RestSharp;
using NUnit.Framework;
using TechTalk.SpecFlow;

namespace APITest.StepDefinitions
{
    [Binding]
    [Scope(Tag = "@SingleUser")]
    public class SingleUserSteps
    {
        private RestClient? client;
        private RestRequest? request;
        private RestResponse? response;

        [Given(@"I sent a valid userid ""([^""]*)""")]
        public void GivenISentAValidUserid(string endpoint)
        {
            client = new RestClient();
            request = new RestRequest(endpoint, Method.Get);
            response = client?.Execute(request);
        }

        [Then(@"the response status code should be (.*)")]
        public void ThenTheResponseStatusCodeShouldBe(int expectedStatusCode)
        {
            Assert.AreEqual(expectedStatusCode, (int?)response?.StatusCode);
        }

        [Then(@"the response should contain the user details")]
        public void ThenTheResponseShouldContainTheUserDetails()
        {
            Assert.IsTrue(response?.Content?.Contains("janet.weaver@reqres.in"));
        }

        [Given(@"I sent an invalid userid ""([^""]*)""")]
        public void GivenISentAnInvalidUserid(string endpoint)
        {
            client = new RestClient();
            request = new RestRequest(endpoint, Method.Get);
            response = client?.Execute(request);
        }

        [Then(@"the response status code should return an invalid code (.*)")]
        public void ThenTheResponseStatusCodeShouldReturnAnInvalidCode(int expectedStatusCode)
        {
            Assert.AreEqual(expectedStatusCode, (int?)response?.StatusCode);
        }

    }
}
