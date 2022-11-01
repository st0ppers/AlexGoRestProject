using System.Text;
using FluentAssertions;
using Newtonsoft.Json;
using SpecFlowGoRestAPITest.Support;
using TechTalk.SpecFlow.Assist;

namespace SpecFlowGoRestAPITest.StepDefinitions
{
    [Binding]
    public sealed class UserSteps
    {
        //private HttpClient _client = new HttpClient();
        private TestContextContainer _container;
        private readonly BaseConfig _baseConfig;
        private HttpResponseMessage _response;
        private User _user;
        private User _userIco;
        private GoRestUser _updateUser;

        public UserSteps(BaseConfig baseConfig, TestContextContainer container)
        {
            _baseConfig = baseConfig;
            _container = container;
        }

        [Given(@"I want to prepaer a request")]
        public void GivenIWantToPrepaerARequest()
        {
            //_client.DefaultRequestHeaders.Add("Authorization", _baseConfig.HttpClientConfig.Token);
        }

        [When(@"I get all users from the (.*) endpoint")]
        public void WhenIGetAllUsersFromTheUsersEndpoint(string endpoint)
        {
            _response = _container.HttpClient.GetAsync($"{_baseConfig.HttpClientConfig.BaseUrl}{endpoint}").Result;
        }

        [Then(@"The response status code should be (.*)")]
        public void ThenTheResponseStatusCodeShouldBeOK(string statusCode)
        {
            _response.StatusCode.ToString().Should().Be(statusCode);
        }

        [Then(@"the response should contain a list of users")]
        public void ThenTheResponseShouldContainAListOfUsers()
        {
            var content = _response.Content.ReadAsStringAsync().Result;
            var expectedResponse = JsonConvert.DeserializeObject<List<GoRestUser>>(content);

            expectedResponse.Should().NotBeEmpty();
        }

        // CREATE
        [Given(@"I have the following user date")]
        public void GivenIHaveTheFollowingUserDate(Table table)
        {
            _user = table.CreateInstance<User>();
        }

        [When(@"I send a request to the (.*) endpoint")]
        public void WhenISendARequestToTheUsersEndpoint(string endpoint)
        {
            var request = JsonConvert.SerializeObject(_user);
            var content = new StringContent(request, Encoding.UTF8, "application/json");
            //_client.DefaultRequestHeaders.Add("Authorization", _baseConfig.HttpClientConfig.Token);

            var requestBody = new HttpRequestMessage()
            {
                Method = HttpMethod.Post,
                RequestUri = new Uri($"{_baseConfig.HttpClientConfig.BaseUrl}{endpoint}"),
                Content = content
            };

            _response = _container.HttpClient.SendAsync(requestBody).Result;
            //var deserialezedObject = JsonConvert.DeserializeObject<GoRestUser>(_response.Content.ReadAsStringAsync().Result);
            //_container.AlexId = deserialezedObject.Id;
        }

        [Then(@"the user should be created successfully")]
        public void ThenTheUserShouldBeCreatedSuccessfully()
        {
            var expectedResult = JsonConvert.DeserializeObject<User>(_response.Content.ReadAsStringAsync().Result);

            expectedResult.FirstName.Should().Be(_user.FirstName);
        }

        //ICO
        [Given(@"I have the following user date for Ico")]
        public void GivenIHaveTheFollowingUserDateForIco(Table table)
        {
            _userIco = table.CreateInstance<User>();
        }

        [When(@"I send a request to the (.*) endpoint as Ico")]
        public void WhenISendARequestToTheUsersEndpointAsIco(string endpoint)
        {
            var request = JsonConvert.SerializeObject(_userIco);
            var content = new StringContent(request, Encoding.UTF8, "application/json");

            var requestBody = new HttpRequestMessage()
            {
                Method = HttpMethod.Post,
                RequestUri = new Uri($"{_baseConfig.HttpClientConfig.BaseUrl}{endpoint}"),
                Content = content
            };

            _response = _container.HttpClientIco.SendAsync(requestBody).Result;
            //var deserialezedObject = JsonConvert.DeserializeObject<GoRestUser>(_response.Content.ReadAsStringAsync().Result);
            //_container.IcoId = deserialezedObject.Id;
        }

        [Then(@"the user should be created successfully as Ico")]
        public void ThenTheUserShouldBeCreatedSuccessfullyAsIco()
        {
            var expectedResult = JsonConvert.DeserializeObject<User>(_response.Content.ReadAsStringAsync().Result);
            expectedResult.FirstName.Should().Be(_userIco.FirstName);
        }

        //UPDATE

        [Given(@"I have a created user already")]
        public void GivenIHaveACreatedUserAlready(Table table)
        {
            _updateUser = table.CreateInstance<GoRestUser>();
        }
        [When(@"I send an update request to the (.*) endpoint")]
        public void WhenISendAnUpdateRequestToTheUsersEndpoint(string endpoint)
        {
            var request = JsonConvert.SerializeObject(_updateUser);
            var content = new StringContent(request, Encoding.UTF8, "application/json");
            //_client.DefaultRequestHeaders.Add("Authorization", _baseConfig.HttpClientConfig.Token);

            var requestBody = new HttpRequestMessage()
            {
                Method = HttpMethod.Put,
                RequestUri = new Uri($"{_baseConfig.HttpClientConfig.BaseUrl}{endpoint}/{_updateUser.Id}"),
                Content = content
            };

            _response = _container.HttpClient.SendAsync(requestBody).Result;
        }

        //DELETE 
        [When(@"I send a delete request to the (.*) endpoint")]
        public void WhenISendADeleteRequestToTheUsersEndpoint(string endpoint)
        {
            var request = JsonConvert.SerializeObject(_updateUser);
            var content = new StringContent(request, Encoding.UTF8, "application/json");
            //_client.DefaultRequestHeaders.Add("Authorization", _baseConfig.HttpClientConfig.Token);

            var requestBody = new HttpRequestMessage()
            {
                Method = HttpMethod.Delete,
                RequestUri = new Uri($"{_baseConfig.HttpClientConfig.BaseUrl}{endpoint}/{_updateUser.Id}"),
                Content = content
            };

            _response = _container.HttpClient.SendAsync(requestBody).Result;
        }



        //HOOKS
        //[Given(@"I want to show the hooks")]
        //public void GivenIWantToShowTheHooks()
        //{
        //    throw new PendingStepException();
        //}

        //[When(@"I execute the scenario")]
        //public void WhenIExecuteTheScenario()
        //{
        //    throw new PendingStepException();
        //}

        //[Then(@"Everyone will see the hook")]
        //public void ThenEveryoneWillSeeTheHook()
        //{
        //    throw new PendingStepException();
        //}



    }
}