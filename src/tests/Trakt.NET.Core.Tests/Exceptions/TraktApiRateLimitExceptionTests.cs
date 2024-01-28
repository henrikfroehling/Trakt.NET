namespace TraktNET.Exceptions
{
    public class TraktApiRateLimitExceptionTests
    {
        [Fact]
        public void TestTraktApiRateLimitExceptionCreate()
        {
            var exception = TraktApiException.Create(Constants.StatusCodes.RateLimitExceeded, HttpMethod.Get,
                                                     new HttpRequestMessage(), "response content");

            exception.Should().NotBeNull();
            exception.StatusCode.Should().Be(Constants.StatusCodes.RateLimitExceeded);
            exception.ReasonPhrase.Should().Be("Rate Limit Exceeded");
            exception.HttpMethod.Should().Be(HttpMethod.Get);
            exception.RequestMessage.Should().NotBeNull();
            exception.ResponseContent.Should().Be("response content");
            exception.Message.Should().Be("Trakt API request failed. Rate Limit Exceeded");

            var rateLimitException = exception as TraktApiRateLimitException;

            rateLimitException.Should().NotBeNull();
            rateLimitException!.RetryAfter.Should().BeNull();
        }
    }
}
