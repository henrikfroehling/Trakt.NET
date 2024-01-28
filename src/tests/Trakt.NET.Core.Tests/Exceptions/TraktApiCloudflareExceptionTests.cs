namespace TraktNET.Exceptions
{
    public class TraktApiCloudflareExceptionTests
    {
        [Fact]
        public void TestTraktApiCloudflareExceptionCode520Create()
        {
            var exception = TraktApiException.Create(Constants.StatusCodes.ServiceUnavailableCloudflareError520, HttpMethod.Get,
                                                     new HttpRequestMessage(), "response content");

            exception.Should().NotBeNull();
            exception.StatusCode.Should().Be(Constants.StatusCodes.ServiceUnavailableCloudflareError520);
            exception.ReasonPhrase.Should().Be("Service Unavailable - Cloudflare error - Status Code 520");
            exception.HttpMethod.Should().Be(HttpMethod.Get);
            exception.RequestMessage.Should().NotBeNull();
            exception.ResponseContent.Should().Be("response content");
            exception.Message.Should().Be("Trakt API request failed. Service Unavailable - Cloudflare error - Status Code 520");
        }

        [Fact]
        public void TestTraktApiCloudflareExceptionCode521Create()
        {
            var exception = TraktApiException.Create(Constants.StatusCodes.ServiceUnavailableCloudflareError521, HttpMethod.Get,
                                                     new HttpRequestMessage(), "response content");

            exception.Should().NotBeNull();
            exception.StatusCode.Should().Be(Constants.StatusCodes.ServiceUnavailableCloudflareError521);
            exception.ReasonPhrase.Should().Be("Service Unavailable - Cloudflare error - Status Code 521");
            exception.HttpMethod.Should().Be(HttpMethod.Get);
            exception.RequestMessage.Should().NotBeNull();
            exception.ResponseContent.Should().Be("response content");
            exception.Message.Should().Be("Trakt API request failed. Service Unavailable - Cloudflare error - Status Code 521");
        }

        [Fact]
        public void TestTraktApiCloudflareExceptionCode522Create()
        {
            var exception = TraktApiException.Create(Constants.StatusCodes.ServiceUnavailableCloudflareError522, HttpMethod.Get,
                                                     new HttpRequestMessage(), "response content");

            exception.Should().NotBeNull();
            exception.StatusCode.Should().Be(Constants.StatusCodes.ServiceUnavailableCloudflareError522);
            exception.ReasonPhrase.Should().Be("Service Unavailable - Cloudflare error - Status Code 522");
            exception.HttpMethod.Should().Be(HttpMethod.Get);
            exception.RequestMessage.Should().NotBeNull();
            exception.ResponseContent.Should().Be("response content");
            exception.Message.Should().Be("Trakt API request failed. Service Unavailable - Cloudflare error - Status Code 522");
        }
    }
}
