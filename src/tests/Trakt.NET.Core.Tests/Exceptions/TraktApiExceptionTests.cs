namespace TraktNET.Exceptions
{
    public class TraktApiExceptionTests
    {
        [Fact]
        public void TestTraktApiExceptionCreate()
        {
            // Test with a random unused status code
            var exception = TraktApiException.Create(System.Net.HttpStatusCode.UnavailableForLegalReasons, HttpMethod.Get,
                                                     new HttpRequestMessage(), "response content");

            exception.Should().NotBeNull();
            exception.StatusCode.Should().Be(System.Net.HttpStatusCode.UnavailableForLegalReasons);
            exception.ReasonPhrase.Should().Be("Response status code does not indicate success: 451");
            exception.HttpMethod.Should().Be(HttpMethod.Get);
            exception.RequestMessage.Should().NotBeNull();
            exception.ResponseContent.Should().Be("response content");
            exception.Message.Should().Be("Trakt API request failed. Response status code does not indicate success: 451");
        }
    }
}
