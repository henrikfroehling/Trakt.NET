namespace TraktNET.Exceptions
{
    public class TraktApiGatewayTimeoutExceptionTests
    {
        [Fact]
        public void TestTraktApiGatewayTimeoutExceptionCreate()
        {
            var exception = TraktApiException.Create(Constants.StatusCodes.ServiceUnavailableGatewayTimeout, HttpMethod.Get,
                                                     new HttpRequestMessage(), "response content");

            exception.Should().NotBeNull();
            exception.StatusCode.Should().Be(Constants.StatusCodes.ServiceUnavailableGatewayTimeout);
            exception.ReasonPhrase.Should().Be("Service Unavailable - server overloaded (try again in 30s) - Gateway Timeout");
            exception.HttpMethod.Should().Be(HttpMethod.Get);
            exception.RequestMessage.Should().NotBeNull();
            exception.ResponseContent.Should().Be("response content");
            exception.Message.Should().Be("Trakt API request failed. Service Unavailable - server overloaded (try again in 30s) - Gateway Timeout");
        }
    }
}
