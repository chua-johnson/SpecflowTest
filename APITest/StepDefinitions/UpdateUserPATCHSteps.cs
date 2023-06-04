using Newtonsoft.Json;
using NUnit.Framework;
using RestSharp;

namespace APITest.StepDefinitions
{
    [Binding]
    [Scope(Tag = "@UpdateUser-PATCH")]
    public class UpdateUserPATCHSteps
    {
        private RestClient _client;
        private RestRequest _request;
        private RestResponse _response;

        [Given(@"the user information is valid")]
        public void GivenTheUserInfoIsValid()
        {
            _client = new RestClient();
            Assert.IsNotNull(_client);
        }

        [When(@"I send a PATCH request to ""(.*)"" with the following body:")]
        public void WhenISendAPATCHRequestToWithTheFollowingBody(string url, string requestBody)
        {
            _request = new RestRequest(url, Method.Patch);
            //_request.AddHeader("Content-Type", "application/json");
            //_request.AddParameter("application/json", requestBody, ParameterType.RequestBody);
            _request.AddJsonBody(requestBody);
            _response = _client.ExecutePut(_request);
        }

        [Then(@"the response status code should be (.*)")]
        public void ThenTheResponseStatusCodeShouldBe(int expectedStatusCode)
        {
            Assert.AreEqual(expectedStatusCode, (int)_response.StatusCode);
        }

        [Then(@"the response body should contain the updated user information")]
        public void ThenTheResponseBodyShouldContainTheUpdatedUserInfo()
        {
            dynamic? responseBody = JsonConvert.DeserializeObject(_response.Content);
            Assert.IsEmpty(responseBody?.name);
        }
    }
}
