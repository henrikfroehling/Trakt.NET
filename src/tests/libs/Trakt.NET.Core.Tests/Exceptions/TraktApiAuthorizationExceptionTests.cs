namespace TraktNET.Exceptions
{
    public class TraktApiAuthorizationExceptionTests
    {
        [Fact]
        public void TestTraktApiAuthorizationExceptionCreate()
        {
            var exception = TraktApiException.Create(Constants.StatusCodes.Unauthorized, HttpMethod.Get,
                                                     new HttpRequestMessage(), "response content");

            exception.Should().NotBeNull();
            exception.StatusCode.Should().Be(Constants.StatusCodes.Unauthorized);
            exception.ReasonPhrase.Should().Be("Unauthorized - OAuth must be provided");
            exception.HttpMethod.Should().Be(HttpMethod.Get);
            exception.RequestMessage.Should().NotBeNull();
            exception.ResponseContent.Should().Be("response content");
            exception.Message.Should().Be("Trakt API request failed. Unauthorized - OAuth must be provided");
        }
    }
}
