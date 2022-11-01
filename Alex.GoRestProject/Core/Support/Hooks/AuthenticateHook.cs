using Bogus;
using Newtonsoft.Json;

namespace Alex.GoRestProject.Core.Support.Hooks
{
    [Binding]
    public class AuthenticateHook
    {
        private UserContextContainer _userContextContainer;
        private readonly BaseConfig _baseConfig;
        private UserContextContainer _container;
        enum Status
        {
            active,
        }
        enum Gender
        {
            male,
            female
        }
        public AuthenticateHook(UserContextContainer userContextContainer, BaseConfig baseConfig, UserContextContainer container)
        {
            _userContextContainer = userContextContainer;
            _baseConfig = baseConfig;
            _container = container;
        }

        [BeforeScenario]
        public void TearUp()
        {
            _userContextContainer.HttpClient = new HttpClient();
        }

        [BeforeScenario]
        public void Authenticate()
        {
            _userContextContainer.HttpClient.DefaultRequestHeaders.Add("Authorization", _baseConfig.ClientConfig.Token);
        }

        [BeforeScenario("CreateUser")]
        public void GivenIWantToCreateANewUser()
        {
            var user = new Faker<UserRequest>()
                .RuleFor(u => u.Gender, f => f.PickRandom<Gender>().ToString())
                .RuleFor(u => u.Name, f => f.Name.FirstName())
                .RuleFor(u => u.Email, f => f.Internet.Email())
                .RuleFor(u => u.Status, f => f.PickRandom<Status>().ToString());

            _container.User = user.Generate();
        }


    }
}
