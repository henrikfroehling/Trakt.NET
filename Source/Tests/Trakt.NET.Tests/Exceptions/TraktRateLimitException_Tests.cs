namespace TraktNet.Tests.Exceptions
{
    using FluentAssertions;
    using System.Net;
    using Traits;
    using TraktNet.Exceptions;
    using Xunit;

    [Category("Exceptions")]
    public class TraktRateLimitException_Tests
    {
        [Fact]
        public void Test_TraktRateLimitException_DefaultConstructor()
        {
            var exception = new TraktRateLimitException();

            exception.Message.Should().Be("Slow Down - your app is polling too quickly");
            exception.StatusCode.Should().Be(default(HttpStatusCode));
            exception.RequestUrl.Should().BeNullOrEmpty();
            exception.RequestBody.Should().BeNullOrEmpty();
            exception.Response.Should().BeNullOrEmpty();
        }

        [Fact]
        public void Test_TraktRateLimitException_Constructor()
        {
            const string message = "exception message";

            var exception = new TraktRateLimitException(message);

            exception.Message.Should().Be(message);
            exception.StatusCode.Should().Be(default(HttpStatusCode));
            exception.RequestUrl.Should().BeNullOrEmpty();
            exception.RequestBody.Should().BeNullOrEmpty();
            exception.Response.Should().BeNullOrEmpty();
        }
    }
}
