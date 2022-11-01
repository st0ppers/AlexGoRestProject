using TechTalk.SpecFlow.Infrastructure;

namespace SpecFlowGoRestAPITest.Support
{
    [Binding]
    public sealed class Hooks
    {
        private ISpecFlowOutputHelper _logger;
        private TestContextContainer _container;
        private readonly BaseConfig _config;
        private static ScenarioContext _scenarioContext;
        public Hooks(ISpecFlowOutputHelper logger, TestContextContainer container, BaseConfig config)
        {
            _logger = logger;
            _container = container;
            _config = config;
        }

        [BeforeScenario]
        public void TearUp()
        {
            //var example = _scenarioContext.ScenarioInfo.Tags.GetValue(1
            //    );
            _container.HttpClient = new HttpClient();
            _container.HttpClientIco = new HttpClient();
        }

        [BeforeScenario("AuthenticateAsAlex")]
        public void Authenticate()
        {
            _container.HttpClient.DefaultRequestHeaders.Add("Authorization", _config.HttpClientConfig.Token);
        }
        [BeforeScenario("AuthenticateAsIco")]
        public void AuthenticateAsIco()
        {
            _container.HttpClientIco.DefaultRequestHeaders.Add("Authorization", _config.HttpClientConfig.TokenIco);
        }

        [AfterScenario("DeleteAlexUser")]
        public void DeleteUserAlex()
        {
            _container.AlexId = default;
        }

        [AfterScenario("DeleteIcoUser")]
        public void DeleteUserIco()
        {
            _container.IcoId = default;
        }
        //[BeforeTestRun]
        //public static void BeforeTestRunExample()
        //{
        //    TestContext.Progress.WriteLine("Loading test data before test run - caches");

        //}
        //[AfterTestRun]
        //public static void AfterTestRunExample()
        //{
        //    TestContext.Progress.WriteLine("After test run");
        //}

        //[BeforeFeature]
        //public static void BeforeFeatureExample()
        //{
        //    TestContext.Progress.WriteLine("Before feature.");
        //}

        //[AfterFeature]
        //public static void AfterFeatureExample()
        //{
        //    TestContext.Progress.WriteLine("After feature.");
        //}

        //[BeforeScenario("Authenticate")]
        //public void Authenticate()
        //{
        //    _logger.WriteLine("Log in as admin scenario");
        //}

        //[BeforeScenario(Order = 1)]
        //public void OrderBy()
        //{
        //    _logger.WriteLine("Order = 1");
        //}

        //[AfterScenario]
        //public void ClearUp()
        //{
        //    _logger.WriteLine("Delete user");
        //}

        //[BeforeStep]
        //public void BeforeStep()
        //{

        //}

    }
}
