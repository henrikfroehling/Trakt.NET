namespace TraktApiSharp.Tests.Exceptions
{
    using FluentAssertions;
    using System.Net;
    using Traits;
    using TraktApiSharp.Exceptions;
    using Xunit;

    [Category("Exceptions")]
    public class TraktBadRequestException_Tests
    {
        [Fact]
        public void Test_TraktBadRequestException_DefaultConstructor()
        {
            var exception = new TraktBadRequestException();

            exception.Message.Should().Be("Bad Request - request couldn't be parsed");
            exception.StatusCode.Should().Be(HttpStatusCode.BadRequest);
            exception.RequestUrl.Should().BeNullOrEmpty();
            exception.RequestBody.Should().BeNullOrEmpty();
            exception.Response.Should().BeNullOrEmpty();
        }

        [Fact]
        public void Test_TraktBadRequestException_Constructor()
        {
            const string message = "exception message";

            var exception = new TraktBadRequestException(message);

            exception.Message.Should().Be(message);
            exception.StatusCode.Should().Be(HttpStatusCode.BadRequest);
            exception.RequestUrl.Should().BeNullOrEmpty();
            exception.RequestBody.Should().BeNullOrEmpty();
            exception.Response.Should().BeNullOrEmpty();
        }
    }
}
