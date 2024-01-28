namespace TraktNET.Exceptions
{
    public class TraktApiBadGatewayExceptionTests
    {
        [Fact]
        public void TestTraktApiBadGatewayExceptionCreate()
        {
            var exception = TraktApiException.Create(Constants.StatusCodes.ServiceUnavailableBadGateway, HttpMethod.Get,
                                                     new HttpRequestMessage(), "response content");

            exception.Should().NotBeNull();
            exception.StatusCode.Should().Be(Constants.StatusCodes.ServiceUnavailableBadGateway);
            exception.ReasonPhrase.Should().Be("Service Unavailable - server overloaded (try again in 30s) - Bad Gateway");
            exception.HttpMethod.Should().Be(HttpMethod.Get);
            exception.RequestMessage.Should().NotBeNull();
            exception.ResponseContent.Should().Be("response content");
            exception.Message.Should().Be("Trakt API request failed. Service Unavailable - server overloaded (try again in 30s) - Bad Gateway");
        }
    }
}
