using RestSharp;
using NUnit.Framework;
using TechTalk.SpecFlow;

namespace APITest.StepDefinitions
{
    [Binding]
    [Scope(Tag ="@AllUsers")]
    public class UserListSteps
    {
        private RestClient? client;
        private RestRequest? request;
        private RestResponse? response;
        private string baseUri = "https://reqres.in/api";
        private string invalidBaseUri = "https://reqres.in/api_invalid";

        [Given(@"I have a valid API endpoint")]
        public void GivenIHaveAValidAPIEndpoint()
        {
            client = new RestClient(baseUri);
            Assert.IsNotNull(client);
        }

        [When(@"I send a GET request to ""(.*)""")]
        public void WhenISendAGETRequestTo(string endpoint)
        {
            request = new RestRequest(endpoint, Method.Get);
            response = client?.Execute(request);
        }

        [Then(@"the response status code should be (\d+)")]
        [Scope(Tag ="@AllUsers1")]
        public void ThenTheResponseStatusCodeShouldBe(int expectedStatusCode)
        {
            Assert.AreEqual(expectedStatusCode, (int?)response?.StatusCode);
        }

        [Then(@"the response should contain user details")]
        public void ThenTheResponseShouldContainUserDetails()
        {
            Assert.IsTrue(response?.Content?.Contains("george.bluth@reqres.in"));
        }


        [Given(@"I have an invalid API endpoint")]
        public void GivenIHaveAnInvalidAPIEndpoint()
        {
            client = new RestClient(invalidBaseUri);
            Assert.IsNotNull(client);
        }

        [When(@"I send an invalid request to ""([^""]*)""")]
        public void WhenISendAnInvalidRequestTo(string endpoint)
        {
            request = new RestRequest(endpoint, Method.Get);
            response = client?.Execute(request);
        }

        [Then(@"the response status code should be invalid (.*)")]
        public void ThenTheResponseStatusCodeShouldBeInvalid(int expectedStatusCode)
        {
            Assert.AreEqual(expectedStatusCode, (int?)response?.StatusCode);
        }












    }



}
