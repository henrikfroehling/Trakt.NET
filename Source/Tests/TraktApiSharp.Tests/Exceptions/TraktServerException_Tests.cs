namespace TraktNet.Tests.Exceptions
{
    using FluentAssertions;
    using System.Net;
    using Traits;
    using TraktNet.Exceptions;
    using Xunit;

    [Category("Exceptions")]
    public class TraktServerException_Tests
    {
        [Fact]
        public void Test_TraktServerException_DefaultConstructor()
        {
            var exception = new TraktServerException();

            exception.Message.Should().Be("Server Error");
            exception.StatusCode.Should().Be(HttpStatusCode.InternalServerError);
            exception.RequestUrl.Should().BeNullOrEmpty();
            exception.RequestBody.Should().BeNullOrEmpty();
            exception.Response.Should().BeNullOrEmpty();
        }

        [Fact]
        public void Test_TraktServerException_Constructor()
        {
            const string message = "exception message";

            var exception = new TraktServerException(message);

            exception.Message.Should().Be(message);
            exception.StatusCode.Should().Be(HttpStatusCode.InternalServerError);
            exception.RequestUrl.Should().BeNullOrEmpty();
            exception.RequestBody.Should().BeNullOrEmpty();
            exception.Response.Should().BeNullOrEmpty();
        }
    }
}
