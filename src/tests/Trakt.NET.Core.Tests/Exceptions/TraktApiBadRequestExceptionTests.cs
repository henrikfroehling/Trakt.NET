namespace TraktNET.Exceptions
{
    public class TraktApiBadRequestExceptionTests
    {
        [Fact]
        public void TestTraktApiBadRequestExceptionCreate()
        {
            var exception = TraktApiException.Create(Constants.StatusCodes.BadRequest, HttpMethod.Get,
                                                     new HttpRequestMessage(), "response content");

            exception.Should().NotBeNull();
            exception.StatusCode.Should().Be(Constants.StatusCodes.BadRequest);
            exception.ReasonPhrase.Should().Be("Bad Request - request couldn't be parsed");
            exception.HttpMethod.Should().Be(HttpMethod.Get);
            exception.RequestMessage.Should().NotBeNull();
            exception.ResponseContent.Should().Be("response content");
            exception.Message.Should().Be("Trakt API request failed. Bad Request - request couldn't be parsed");
        }
    }
}
