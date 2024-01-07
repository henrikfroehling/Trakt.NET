namespace TraktNET.Exceptions
{
    public class TraktApiVIPValidationExceptionTests
    {
        [Fact]
        public void TestCreateTraktApiVIPValidationException()
        {
            var exception = TraktApiException.Create(Constants.StatusCodes.VIPOnly, HttpMethod.Get,
                                                     new HttpRequestMessage(), "response content");

            exception.Should().NotBeNull();
            exception.StatusCode.Should().Be(Constants.StatusCodes.VIPOnly);
            exception.ReasonPhrase.Should().Be("VIP Only - user must upgrade to VIP");
            exception.HttpMethod.Should().Be(HttpMethod.Get);
            exception.RequestMessage.Should().NotBeNull();
            exception.ResponseContent.Should().Be("response content");
            exception.Message.Should().Be("Trakt API request failed. VIP Only - user must upgrade to VIP");

            var vipValidationException = exception as TraktApiVIPValidationException;

            vipValidationException.Should().NotBeNull();
            vipValidationException!.UpgradeURL.Should().BeNull();
        }
    }
}
