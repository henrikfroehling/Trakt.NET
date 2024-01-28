namespace TraktNET.Exceptions
{
    public class TraktApiLockedUserAccountExceptionTests
    {
        [Fact]
        public void TestTraktApiLockedUserAccountExceptionCreate()
        {
            var exception = TraktApiException.Create(Constants.StatusCodes.LockedUserAccount, HttpMethod.Get,
                                                     new HttpRequestMessage(), "response content");

            exception.Should().NotBeNull();
            exception.StatusCode.Should().Be(Constants.StatusCodes.LockedUserAccount);
            exception.ReasonPhrase.Should().Be("Locked User Account - have the user contact support");
            exception.HttpMethod.Should().Be(HttpMethod.Get);
            exception.RequestMessage.Should().NotBeNull();
            exception.ResponseContent.Should().Be("response content");
            exception.Message.Should().Be("Trakt API request failed. Locked User Account - have the user contact support");
        }
    }
}
