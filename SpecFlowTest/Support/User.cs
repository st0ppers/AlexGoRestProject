using Newtonsoft.Json;

namespace SpecFlowGoRestAPITest.Support
{
    public class User
    {
        [JsonProperty("name")]
        public string FirstName { get; set; }
        public string LastName { get; set; }
        [JsonProperty("email")]
        public string Email { get; set; }
        [JsonProperty("gender")]
        public Bogus.DataSets.Name.Gender Gender { get; set; }
        [JsonProperty("status")]
        public string Status { get; set; }
    }
}
