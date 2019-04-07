namespace TraktNet.Core.Tests.Exceptions
{
    using FluentAssertions;
    using System.Net;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Exceptions;
    using Xunit;

    [Category("Exceptions")]
    public class TraktAuthenticationOAuthExcepton_Tests
    {
        [Fact]
        public void Test_TraktAuthenticationOAuthException_DefaultConstructor()
        {
            const string message = "exception message";

            var exception = new TraktAuthenticationOAuthException(message);

            exception.Message.Should().Be(message);
            exception.StatusCode.Should().Be(default(HttpStatusCode));
            exception.RequestUrl.Should().BeNullOrEmpty();
            exception.RequestBody.Should().BeNullOrEmpty();
            exception.Response.Should().BeNullOrEmpty();
        }
    }
}
