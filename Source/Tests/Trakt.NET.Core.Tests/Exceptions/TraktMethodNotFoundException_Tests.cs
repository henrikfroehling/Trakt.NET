namespace TraktNet.Core.Tests.Exceptions
{
    using FluentAssertions;
    using System.Net;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Exceptions;
    using Xunit;

    [TestCategory("Exceptions")]
    public class TraktMethodNotFoundException_Tests
    {
        [Fact]
        public void Test_TraktMethodNotFoundException_DefaultConstructor()
        {
            var exception = new TraktMethodNotFoundException();

            exception.Message.Should().Be("Method Not Found - method doesn't exist");
            exception.StatusCode.Should().Be(HttpStatusCode.MethodNotAllowed);
            exception.RequestUrl.Should().BeNullOrEmpty();
            exception.RequestBody.Should().BeNullOrEmpty();
            exception.Response.Should().BeNullOrEmpty();
        }

        [Fact]
        public void Test_TraktMethodNotFoundException_Constructor()
        {
            const string message = "exception message";

            var exception = new TraktMethodNotFoundException(message);

            exception.Message.Should().Be(message);
            exception.StatusCode.Should().Be(HttpStatusCode.MethodNotAllowed);
            exception.RequestUrl.Should().BeNullOrEmpty();
            exception.RequestBody.Should().BeNullOrEmpty();
            exception.Response.Should().BeNullOrEmpty();
        }
    }
}
