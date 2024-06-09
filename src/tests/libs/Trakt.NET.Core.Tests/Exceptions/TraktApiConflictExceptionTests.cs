namespace TraktNET.Exceptions
{
    public class TraktApiConflictExceptionTests
    {
        [Fact]
        public void TestTraktApiConflictExceptionCreate()
        {
            var exception = TraktApiException.Create(Constants.StatusCodes.Conflict, HttpMethod.Get,
                                                     new HttpRequestMessage(), "response content");

            exception.Should().NotBeNull();
            exception.StatusCode.Should().Be(Constants.StatusCodes.Conflict);
            exception.ReasonPhrase.Should().Be("Conflict - resource already created");
            exception.HttpMethod.Should().Be(HttpMethod.Get);
            exception.RequestMessage.Should().NotBeNull();
            exception.ResponseContent.Should().Be("response content");
            exception.Message.Should().Be("Trakt API request failed. Conflict - resource already created");
        }
    }
}
