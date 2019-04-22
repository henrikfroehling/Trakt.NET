namespace TraktNet.Core.Tests.Exceptions
{
    using FluentAssertions;
    using System.Net;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Exceptions;
    using Xunit;

    [Category("Exceptions")]
    public class TraktServerUnavailableException_Tests
    {
        [Fact]
        public void Test_TraktServerUnavailableException_DefaultConstructor()
        {
            var exception = new TraktServerUnavailableException();

            exception.Message.Should().Be("Service Unavailable - server overloaded (try again in 30s)");
            exception.StatusCode.Should().Be(HttpStatusCode.ServiceUnavailable);
            exception.RequestUrl.Should().BeNullOrEmpty();
            exception.RequestBody.Should().BeNullOrEmpty();
            exception.Response.Should().BeNullOrEmpty();
        }

        [Fact]
        public void Test_TraktServerUnavailableException_Constructor()
        {
            const string message = "exception message";

            var exception = new TraktServerUnavailableException(message);

            exception.Message.Should().Be(message);
            exception.StatusCode.Should().Be(HttpStatusCode.ServiceUnavailable);
            exception.RequestUrl.Should().BeNullOrEmpty();
            exception.RequestBody.Should().BeNullOrEmpty();
            exception.Response.Should().BeNullOrEmpty();
        }
    }
}
