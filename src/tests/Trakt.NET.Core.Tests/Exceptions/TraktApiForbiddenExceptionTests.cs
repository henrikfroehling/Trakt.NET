namespace TraktNET.Exceptions
{
    public class TraktApiForbiddenExceptionTests
    {
        [Fact]
        public void TestCreateTraktApiForbiddenException()
        {
            var exception = TraktApiException.Create(Constants.StatusCodes.Forbidden, HttpMethod.Get,
                                                     new HttpRequestMessage(), "response content");

            exception.Should().NotBeNull();
            exception.StatusCode.Should().Be(Constants.StatusCodes.Forbidden);
            exception.ReasonPhrase.Should().Be("Forbidden - invalid API key or unapproved app");
            exception.HttpMethod.Should().Be(HttpMethod.Get);
            exception.RequestMessage.Should().NotBeNull();
            exception.ResponseContent.Should().Be("response content");
            exception.Message.Should().Be("Trakt API request failed. Forbidden - invalid API key or unapproved app");
        }
    }
}
