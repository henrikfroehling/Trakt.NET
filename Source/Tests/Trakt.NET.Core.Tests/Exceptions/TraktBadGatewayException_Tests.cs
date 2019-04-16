namespace TraktNet.Core.Tests.Exceptions
{
    using FluentAssertions;
    using System.Net;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Exceptions;
    using Xunit;

    [Category("Exceptions")]
    public class TraktBadGatewayException_Tests
    {
        [Fact]
        public void Test_TraktBadGatewayException_DefaultConstructor()
        {
            var exception = new TraktBadGatewayException();

            exception.Message.Should().Be("Bad Gateway");
            exception.StatusCode.Should().Be(HttpStatusCode.BadGateway);
            exception.RequestUrl.Should().BeNullOrEmpty();
            exception.RequestBody.Should().BeNullOrEmpty();
            exception.Response.Should().BeNullOrEmpty();
        }

        [Fact]
        public void Test_TraktBadGatewayException_Constructor()
        {
            const string message = "exception message";

            var exception = new TraktBadGatewayException(message);

            exception.Message.Should().Be(message);
            exception.StatusCode.Should().Be(HttpStatusCode.BadGateway);
            exception.RequestUrl.Should().BeNullOrEmpty();
            exception.RequestBody.Should().BeNullOrEmpty();
            exception.Response.Should().BeNullOrEmpty();
        }
    }
}
