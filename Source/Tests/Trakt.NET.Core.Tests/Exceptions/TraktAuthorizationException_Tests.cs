namespace TraktNet.Core.Tests.Exceptions
{
    using FluentAssertions;
    using System.Net;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Exceptions;
    using Xunit;

    [Category("Exceptions")]
    public class TraktAuthorizationException_Tests
    {
        [Fact]
        public void Test_TraktAuthorizationException_DefaultConstructor()
        {
            var exception = new TraktAuthorizationException();

            exception.Message.Should().Be("Unauthorized - OAuth must be provided");
            exception.StatusCode.Should().Be(HttpStatusCode.Unauthorized);
            exception.RequestUrl.Should().BeNullOrEmpty();
            exception.RequestBody.Should().BeNullOrEmpty();
            exception.Response.Should().BeNullOrEmpty();
        }

        [Fact]
        public void Test_TraktAuthorizationException_Constructor()
        {
            const string message = "exception message";

            var exception = new TraktAuthorizationException(message);

            exception.Message.Should().Be(message);
            exception.StatusCode.Should().Be(HttpStatusCode.Unauthorized);
            exception.RequestUrl.Should().BeNullOrEmpty();
            exception.RequestBody.Should().BeNullOrEmpty();
            exception.Response.Should().BeNullOrEmpty();
        }
    }
}
