namespace SpecFlowGoRestAPITest.Support
{
    public class TestContextContainer
    {
        //store global values like client/id
        public HttpClient HttpClient { get; set; }
        public HttpClient HttpClientIco { get; set; }
        public int AlexId { get; set; }
        public int IcoId { get; set; }
    }
}
