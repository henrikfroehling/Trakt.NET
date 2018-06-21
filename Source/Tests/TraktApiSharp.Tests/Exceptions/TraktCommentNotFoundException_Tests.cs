namespace TraktNet.Tests.Exceptions
{
    using FluentAssertions;
    using System.Net;
    using Traits;
    using TraktNet.Exceptions;
    using Xunit;

    [Category("Exceptions")]
    public class TraktCommentNotFoundException_Tests
    {
        [Fact]
        public void Test_TraktCommentNotFoundException_DefaultConstructor()
        {
            const string commentId = "person id";

            var exception = new TraktCommentNotFoundException(commentId);

            exception.Message.Should().Be("Comment Not Found - method exists, but no record found");
            exception.ObjectId.Should().Be(commentId);
            exception.StatusCode.Should().Be(HttpStatusCode.NotFound);
            exception.RequestUrl.Should().BeNullOrEmpty();
            exception.RequestBody.Should().BeNullOrEmpty();
            exception.Response.Should().BeNullOrEmpty();
        }

        [Fact]
        public void Test_TraktCommentNotFoundException_Constructor()
        {
            const string message = "exception message";
            const string commentId = "person id";

            var exception = new TraktCommentNotFoundException(message, commentId);

            exception.Message.Should().Be(message);
            exception.ObjectId.Should().Be(commentId);
            exception.StatusCode.Should().Be(HttpStatusCode.NotFound);
            exception.RequestUrl.Should().BeNullOrEmpty();
            exception.RequestBody.Should().BeNullOrEmpty();
            exception.Response.Should().BeNullOrEmpty();
        }
    }
}
