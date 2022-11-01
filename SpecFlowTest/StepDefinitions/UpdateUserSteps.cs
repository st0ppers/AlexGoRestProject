using System.Text;
using Newtonsoft.Json;
using SpecFlowGoRestAPITest.Support;

namespace SpecFlowGoRestAPITest.StepDefinitions
{
    [Binding]
    public class UpdateUserSteps
    {
        private readonly BaseConfig _baseConfig;
        private HttpClient _client = new HttpClient();
        private int _id;

        public UpdateUserSteps(BaseConfig config)
        {
            _baseConfig = config;
        }

        private HttpResponseMessage CreateUser()
        {
            var user = new GoRestUser()
            {
                Name = "asd",
                Email = "asdf@asdf.com",
                Gender = "male",
                Status = "active"
            };

            var requestBody = new StringContent(JsonConvert.SerializeObject(user), Encoding.UTF8, "application/json");
            var request = new HttpRequestMessage()
            {
                Method = HttpMethod.Post,
                RequestUri = new Uri($"{_baseConfig.HttpClientConfig.BaseUrl}users"),
                Content = requestBody
            };

            return _client.Send(request);

        }
    }
}
