using Newtonsoft.Json;
using NUnit.Framework;
using RestSharp;


namespace APITest.StepDefinitions
{
    [Binding]
    [Scope(Tag = "@UpdateUser-PUT")]
    public class UpdateUserPUTSteps
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

        [When(@"I send a PUT request to ""(.*)"" with the following body:")]
        public string WhenISendAPUTRequestToWithTheFollowingBody(string url, string requestBody)
        {
            _request = new RestRequest(url, Method.Put);
            //_request.AddHeader("Content-Type", "application/json");
            //_request.AddParameter("application/json", requestBody, ParameterType.RequestBody);
            _request.AddJsonBody(requestBody);
            _response = _client.ExecutePut(_request);
            return "";
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


        [Given(@"the user information is invalid")]
        public void GivenTheUserInformationIsInvalid()
        {
            _client = new RestClient();
            Assert.IsNotNull(_client);
        }

        [When(@"I send a PUT request to ""([^""]*)"" with the following body that has invalid data:")]
        public void WhenISendAPUTRequestToWithTheFollowingBodyThatHasInvalidData(string url, string requestBody)
        {
            _request = new RestRequest(url, Method.Put);
            _request.AddJsonBody(requestBody);
            _response = _client.ExecutePut(_request);
        }

        [Then(@"it should return response status code of (.*)")]
        public void ThenItShouldReturnResponseStatusCodeOf(int expectedStatusCode)
        {
            Assert.AreEqual(expectedStatusCode, (int)_response.StatusCode);
        }

        [Then(@"the response body should contain an error message")]
        public void ThenTheResponseBodyShouldContainAnErrorMessage()
        {
            dynamic? responseBody = JsonConvert.DeserializeObject(_response.Content);
            Assert.IsNotNull(responseBody?.error_message);
            Assert.IsNotEmpty(responseBody?.error_message);
        }

        [When(@"I send a PUT request to ""([^""]*)"" with the following body that has invalid schema:")]
        public void WhenISendAPUTRequestToWithTheFollowingBodyThatHasInvalidSchema(string url, string requestBody)
        {
            _request = new RestRequest(url, Method.Put);
            _request.AddJsonBody(requestBody);
            _response = _client.ExecutePut(_request);
        }

        [Then(@"it should return an invalid response status code of (.*)")]
        public void ThenItShouldReturnAnInvalidResponseStatusCodeOf(int expectedStatusCode)
        {
            Assert.AreEqual(expectedStatusCode, (int)_response.StatusCode);
        }

    }
}
