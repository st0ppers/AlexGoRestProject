using Microsoft.Extensions.Configuration;

namespace Alex.GoRestProject.Core.Support
{
    public class BaseConfig
    {
        public HttpClientConfig ClientConfig { get; set; }
        public BaseConfig()
        {
            var config = new ConfigurationBuilder().AddJsonFile("httpConfig.json").Build();
            ClientConfig = config.GetSection("HttpClient").Get<HttpClientConfig>();
        }
    }
}
