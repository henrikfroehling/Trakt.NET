namespace TraktNET.Exceptions
{
    public class TraktApiServerUnavailableExceptionTests
    {
        [Fact]
        public void TestCreateTraktApiServerUnavailableException()
        {
            var exception = TraktApiException.Create(Constants.StatusCodes.ServiceUnavailable, HttpMethod.Get,
                                                     new HttpRequestMessage(), "response content");

            exception.Should().NotBeNull();
            exception.StatusCode.Should().Be(Constants.StatusCodes.ServiceUnavailable);
            exception.ReasonPhrase.Should().Be("Service Unavailable - server overloaded (try again in 30s)");
            exception.HttpMethod.Should().Be(HttpMethod.Get);
            exception.RequestMessage.Should().NotBeNull();
            exception.ResponseContent.Should().Be("response content");
            exception.Message.Should().Be("Trakt API request failed. Service Unavailable - server overloaded (try again in 30s)");
        }
    }
}
