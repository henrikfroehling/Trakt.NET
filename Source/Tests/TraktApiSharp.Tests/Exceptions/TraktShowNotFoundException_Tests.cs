namespace TraktApiSharp.Tests.Exceptions
{
    using FluentAssertions;
    using System.Net;
    using Traits;
    using TraktApiSharp.Exceptions;
    using Xunit;

    [Category("Exceptions")]
    public class TraktShowNotFoundException_Tests
    {
        [Fact]
        public void Test_TraktShowNotFoundException_DefaultConstructor()
        {
            const string showId = "show id";

            var exception = new TraktShowNotFoundException(showId);

            exception.Message.Should().Be("Show Not Found - method exists, but no record found");
            exception.ObjectId.Should().Be(showId);
            exception.StatusCode.Should().Be(HttpStatusCode.NotFound);
            exception.RequestUrl.Should().BeNullOrEmpty();
            exception.RequestBody.Should().BeNullOrEmpty();
            exception.Response.Should().BeNullOrEmpty();
        }

        [Fact]
        public void Test_TraktShowNotFoundException_Constructor()
        {
            const string message = "exception message";
            const string showId = "show id";

            var exception = new TraktShowNotFoundException(message, showId);

            exception.Message.Should().Be(message);
            exception.ObjectId.Should().Be(showId);
            exception.StatusCode.Should().Be(HttpStatusCode.NotFound);
            exception.RequestUrl.Should().BeNullOrEmpty();
            exception.RequestBody.Should().BeNullOrEmpty();
            exception.Response.Should().BeNullOrEmpty();
        }
    }
}
