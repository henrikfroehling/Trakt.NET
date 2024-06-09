namespace TraktNET.Exceptions
{
    public class TraktApiNotFoundExceptionTests
    {
        [Fact]
        public void TestTraktApiNotFoundExceptionCreate()
        {
            var exception = TraktApiException.Create(Constants.StatusCodes.NotFound, HttpMethod.Get,
                                                     new HttpRequestMessage(), "response content");

            exception.Should().NotBeNull();
            exception.StatusCode.Should().Be(Constants.StatusCodes.NotFound);
            exception.ReasonPhrase.Should().Be("Not Found - method exists, but no record found");
            exception.HttpMethod.Should().Be(HttpMethod.Get);
            exception.RequestMessage.Should().NotBeNull();
            exception.ResponseContent.Should().Be("response content");
            exception.Message.Should().Be("Trakt API request failed. Not Found - method exists, but no record found");
        }
    }
}
