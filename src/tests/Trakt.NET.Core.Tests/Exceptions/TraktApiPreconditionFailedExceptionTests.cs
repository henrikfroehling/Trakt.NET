namespace TraktNET.Exceptions
{
    public class TraktApiPreconditionFailedExceptionTests
    {
        [Fact]
        public void TestCreateTraktApiPreconditionFailedException()
        {
            var exception = TraktApiException.Create(Constants.StatusCodes.PreconditionFailed, HttpMethod.Get,
                                                     new HttpRequestMessage(), "response content");

            exception.Should().NotBeNull();
            exception.StatusCode.Should().Be(Constants.StatusCodes.PreconditionFailed);
            exception.ReasonPhrase.Should().Be("Precondition Failed - use application/json content type");
            exception.HttpMethod.Should().Be(HttpMethod.Get);
            exception.RequestMessage.Should().NotBeNull();
            exception.ResponseContent.Should().Be("response content");
            exception.Message.Should().Be("Trakt API request failed. Precondition Failed - use application/json content type");
        }
    }
}
