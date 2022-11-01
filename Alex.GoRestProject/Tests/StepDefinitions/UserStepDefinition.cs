using System.Text;
using Alex.GoRestProject.Core.Support;
using Newtonsoft.Json;
using TechTalk.SpecFlow.Assist;

namespace Alex.GoRestProject.Tests.StepDefinitions
{
    [Binding]
    public class UserStepDefinition
    {
        private HttpResponseMessage _responseMessage;
        private UserContextContainer _userContextContainer;
        private readonly BaseConfig _baseConfig;
        private UserRequest _user;

        //get all
        public UserStepDefinition(UserContextContainer userContextContainer, BaseConfig baseConfig)
        {
            _userContextContainer = userContextContainer;
            _baseConfig = baseConfig;
        }

        [Given(@"I have users to get")]
        public void GivenIHaveUsersToGet()
        {

        }

        [When(@"I get all the users from the (.*) endpoint")]
        public void WhenIGetAllTheUsersFromTheUsersEndpoint(string endpoint)
        {
            _responseMessage = _userContextContainer.HttpClient.GetAsync($"{_baseConfig.ClientConfig.BaseUrl}{endpoint}").Result;
        }

        [Then(@"The status code should be (.*)")]
        public void ThenTheStatusCodeShouldBeOK(string status)
        {
            _responseMessage.StatusCode.ToString().Should().Be(status);
        }

        //Create user
        [Given(@"I have the following user to add (.*)")]
        public void GivenIHaveTheFollowingUserToAddTrue(bool valid)
        {
            if (valid)
            {
                _user = _userContextContainer.User;
            }
            else
            {
                _user = _userContextContainer.User;
                _user.Email = "";
            }
        }

        [When(@"I send post request to the (.*) endpoint")]
        public void WhenISendPostRequestToTheUsersEndpoint(string endpoint)
        {
            var request = JsonConvert.SerializeObject(_userContextContainer.User);
            var content = new StringContent(request, Encoding.UTF8, "application/json");

            var requestBody = new HttpRequestMessage()
            {
                Method = HttpMethod.Post,
                RequestUri = new Uri($"{_baseConfig.ClientConfig.BaseUrl}{endpoint}"),
                Content = content
            };

            _responseMessage = _userContextContainer.HttpClient.SendAsync(requestBody).Result;
            //_responseMessage.IsSuccessStatusCode
        }
        [Then(@"the user should be created successfully")]
        public void ThenTheUserShouldBeCreatedSuccessfully()
        {
            if (_responseMessage.IsSuccessStatusCode)
            {
                var expectedResult = JsonConvert.DeserializeObject<UserRequest>(_responseMessage.Content.ReadAsStringAsync().Result);
                expectedResult.Name.Should().Be(_user.Name);
            }
            else
            {
                var badResult = JsonConvert.DeserializeObject<IEnumerable<FailedMessage>>(_responseMessage.Content.ReadAsStringAsync().Result);
            }
        }

        //Update user
        [Given(@"I have already created a user")]
        public void GivenIHaveAlreadyCreatedAUser(Table table)
        {
            throw new PendingStepException();
        }

        [When(@"I send put request to the (.*)endpoint")]
        public void WhenISendPutRequestToTheUsersEndpoint(string endpoint)
        {
            throw new PendingStepException();
        }

    }
}
