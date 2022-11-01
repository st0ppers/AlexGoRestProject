using Microsoft.Extensions.Configuration;

namespace SpecFlowGoRestAPITest.Support
{
    public class BaseConfig
    {
        public BaseConfig()
        {
            var config = new ConfigurationBuilder().AddJsonFile("TestConfig.json").Build();
            HttpClientConfig = config.GetSection("HttpClient").Get<HttpClientConfig>();
        }
        public HttpClientConfig HttpClientConfig { get; set; }
    }
}
