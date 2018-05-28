namespace TraktApiSharp.Tests.Exceptions
{
    using FluentAssertions;
    using System.Net;
    using Traits;
    using TraktApiSharp.Exceptions;
    using Xunit;

    [Category("Exceptions")]
    public class TraktPreconditionFailedException_Tests
    {
        [Fact]
        public void Test_TraktPreconditionFailedException_DefaultConstructor()
        {
            var exception = new TraktPreconditionFailedException();

            exception.Message.Should().Be("Precondition Failed - use application/json content type");
            exception.StatusCode.Should().Be(HttpStatusCode.PreconditionFailed);
            exception.RequestUrl.Should().BeNullOrEmpty();
            exception.RequestBody.Should().BeNullOrEmpty();
            exception.Response.Should().BeNullOrEmpty();
        }

        [Fact]
        public void Test_TraktPreconditionFailedException_Constructor()
        {
            const string message = "exception message";

            var exception = new TraktPreconditionFailedException(message);

            exception.Message.Should().Be(message);
            exception.StatusCode.Should().Be(HttpStatusCode.PreconditionFailed);
            exception.RequestUrl.Should().BeNullOrEmpty();
            exception.RequestBody.Should().BeNullOrEmpty();
            exception.Response.Should().BeNullOrEmpty();
        }
    }
}
