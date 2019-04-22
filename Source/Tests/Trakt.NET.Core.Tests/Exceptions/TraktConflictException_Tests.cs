namespace TraktNet.Core.Tests.Exceptions
{
    using FluentAssertions;
    using System.Net;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Exceptions;
    using Xunit;

    [Category("Exceptions")]
    public class TraktConflictException_Tests
    {
        [Fact]
        public void Test_TraktConflictException_DefaultConstructor()
        {
            var exception = new TraktConflictException();

            exception.Message.Should().Be("Conflict - resource already created");
            exception.StatusCode.Should().Be(HttpStatusCode.Conflict);
            exception.RequestUrl.Should().BeNullOrEmpty();
            exception.RequestBody.Should().BeNullOrEmpty();
            exception.Response.Should().BeNullOrEmpty();
        }

        [Fact]
        public void Test_TraktConflictException_Constructor()
        {
            const string message = "exception message";

            var exception = new TraktConflictException(message);

            exception.Message.Should().Be(message);
            exception.StatusCode.Should().Be(HttpStatusCode.Conflict);
            exception.RequestUrl.Should().BeNullOrEmpty();
            exception.RequestBody.Should().BeNullOrEmpty();
            exception.Response.Should().BeNullOrEmpty();
        }
    }
}
