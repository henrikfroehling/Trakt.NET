namespace TraktNET.Exceptions
{
    public class TraktApiMethodNotFoundExceptionTests
    {
        [Fact]
        public void TestTraktApiMethodNotFoundExceptionCreate()
        {
            var exception = TraktApiException.Create(Constants.StatusCodes.MethodNotFound, HttpMethod.Get,
                                                     new HttpRequestMessage(), "response content");

            exception.Should().NotBeNull();
            exception.StatusCode.Should().Be(Constants.StatusCodes.MethodNotFound);
            exception.ReasonPhrase.Should().Be("Method Not Found - method doesn't exist");
            exception.HttpMethod.Should().Be(HttpMethod.Get);
            exception.RequestMessage.Should().NotBeNull();
            exception.ResponseContent.Should().Be("response content");
            exception.Message.Should().Be("Trakt API request failed. Method Not Found - method doesn't exist");
        }
    }
}
