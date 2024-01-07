namespace TraktNET.Exceptions
{
    public class TraktApiAccountLimitExceptionTests
    {
        [Fact]
        public void TestCreateTraktApiAccountLimitException()
        {
            var exception = TraktApiException.Create(Constants.StatusCodes.AccountLimitExceeded, HttpMethod.Get,
                                                     new HttpRequestMessage(), "response content");

            exception.Should().NotBeNull();
            exception.StatusCode.Should().Be(Constants.StatusCodes.AccountLimitExceeded);
            exception.ReasonPhrase.Should().Be("Account Limit Exceeded - list count, item count, etc");
            exception.HttpMethod.Should().Be(HttpMethod.Get);
            exception.RequestMessage.Should().NotBeNull();
            exception.ResponseContent.Should().Be("response content");
            exception.Message.Should().Be("Trakt API request failed. Account Limit Exceeded - list count, item count, etc");

            var accountLimitException = exception as TraktApiAccountLimitException;

            accountLimitException.Should().NotBeNull();
            accountLimitException!.UpgradeURL.Should().BeNull();
            accountLimitException!.IsVIPUser.Should().BeNull();
            accountLimitException!.AccountLimit.Should().BeNull();
        }
    }
}
