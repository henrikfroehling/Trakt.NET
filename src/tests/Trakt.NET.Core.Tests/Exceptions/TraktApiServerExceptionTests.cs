namespace TraktNET.Exceptions
{
    public class TraktApiServerExceptionTests
    {
        [Fact]
        public void TestCreateTraktApiServerException()
        {
            var exception = TraktApiException.Create(Constants.StatusCodes.ServerError, HttpMethod.Get,
                                                     new HttpRequestMessage(), "response content");

            exception.Should().NotBeNull();
            exception.StatusCode.Should().Be(Constants.StatusCodes.ServerError);
            exception.ReasonPhrase.Should().Be("Server Error - please open a support ticket");
            exception.HttpMethod.Should().Be(HttpMethod.Get);
            exception.RequestMessage.Should().NotBeNull();
            exception.ResponseContent.Should().Be("response content");
            exception.Message.Should().Be("Trakt API request failed. Server Error - please open a support ticket");
        }
    }
}
