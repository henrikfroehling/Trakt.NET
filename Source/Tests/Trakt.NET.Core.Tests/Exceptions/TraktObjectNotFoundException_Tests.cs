namespace TraktNet.Core.Tests.Exceptions
{
    using FluentAssertions;
    using System.Net;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Exceptions;
    using Xunit;

    [TestCategory("Exceptions")]
    public class TraktObjectNotFoundException_Tests
    {
        [Fact]
        public void Test_TraktObjectNotFoundException_DefaultConstructor()
        {
            const string objectId = "object id";

            var exception = new TraktObjectNotFoundException(objectId);

            exception.Message.Should().Be("Object Not Found - method exists, but no record found");
            exception.ObjectId.Should().Be(objectId);
            exception.StatusCode.Should().Be(HttpStatusCode.NotFound);
            exception.RequestUrl.Should().BeNullOrEmpty();
            exception.RequestBody.Should().BeNullOrEmpty();
            exception.Response.Should().BeNullOrEmpty();
        }

        [Fact]
        public void Test_TraktObjectNotFoundException_Constructor()
        {
            const string message = "exception message";
            const string objectId = "object id";

            var exception = new TraktObjectNotFoundException(message, objectId);

            exception.Message.Should().Be(message);
            exception.ObjectId.Should().Be(objectId);
            exception.StatusCode.Should().Be(HttpStatusCode.NotFound);
            exception.RequestUrl.Should().BeNullOrEmpty();
            exception.RequestBody.Should().BeNullOrEmpty();
            exception.Response.Should().BeNullOrEmpty();
        }
    }
}
