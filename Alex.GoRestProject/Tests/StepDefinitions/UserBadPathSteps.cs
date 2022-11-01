using Alex.GoRestProject.Core.Support;

namespace Alex.GoRestProject.Tests.StepDefinitions
{
    [Binding]
    public class UserBadPathSteps
    {

        private HttpResponseMessage _responseMessage;
        private UserContextContainer _userContextContainer;
        private readonly BaseConfig _baseConfig;

        public UserBadPathSteps(UserContextContainer userContextContainer, BaseConfig baseConfig)
        {
            _userContextContainer = userContextContainer;
            _baseConfig = baseConfig;
        }

        [Given(@"I have users to get from wrong url")]
        public void GivenIHaveUsersToGetFromWrongUrl()
        {

        }

        [When(@"I get all the users from bad path (.*) endpoint")]
        public void WhenIGetAllTheUsersFromBadPathUserEndpoint(string endpoint)
        {
            _responseMessage = _userContextContainer.HttpClient
                .GetAsync($"{_baseConfig.ClientConfig.BaseUrl}{endpoint}").Result;
        }

        [Then(@"The bad path status code should be (.*)")]
        public void ThenTheBadPathStatusCodeShouldBeNotFound(string status)
        {
            _responseMessage.StatusCode.ToString().Should().Be(status);
        }

    }
}
