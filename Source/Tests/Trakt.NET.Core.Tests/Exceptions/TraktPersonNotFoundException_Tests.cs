namespace TraktNet.Core.Tests.Exceptions
{
    using FluentAssertions;
    using System.Net;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Exceptions;
    using Xunit;

    [Category("Exceptions")]
    public class TraktPersonNotFoundException_Tests
    {
        [Fact]
        public void Test_TraktPersonNotFoundException_DefaultConstructor()
        {
            const string personId = "person id";

            var exception = new TraktPersonNotFoundException(personId);

            exception.Message.Should().Be("Person Not Found - method exists, but no record found");
            exception.ObjectId.Should().Be(personId);
            exception.StatusCode.Should().Be(HttpStatusCode.NotFound);
            exception.RequestUrl.Should().BeNullOrEmpty();
            exception.RequestBody.Should().BeNullOrEmpty();
            exception.Response.Should().BeNullOrEmpty();
        }

        [Fact]
        public void Test_TraktPersonNotFoundException_Constructor()
        {
            const string message = "exception message";
            const string personId = "person id";

            var exception = new TraktPersonNotFoundException(message, personId);

            exception.Message.Should().Be(message);
            exception.ObjectId.Should().Be(personId);
            exception.StatusCode.Should().Be(HttpStatusCode.NotFound);
            exception.RequestUrl.Should().BeNullOrEmpty();
            exception.RequestBody.Should().BeNullOrEmpty();
            exception.Response.Should().BeNullOrEmpty();
        }
    }
}
