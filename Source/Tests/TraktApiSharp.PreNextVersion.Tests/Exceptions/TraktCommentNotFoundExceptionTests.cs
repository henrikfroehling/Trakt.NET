namespace TraktApiSharp.Tests.Exceptions
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using TraktApiSharp.Exceptions;

    [TestClass]
    public class TraktCommentNotFoundExceptionTests
    {
        [TestMethod]
        public void TestTraktCommentNotFoundExceptionBaseClass()
        {
            var exception = new TraktCommentNotFoundException("");

            exception.Should().BeAssignableTo<TraktException>();
            exception.Should().BeAssignableTo<TraktObjectNotFoundException>();
        }

        [TestMethod]
        public void TestTraktCommentNotFoundExceptionDefaultConstructor()
        {
            var commentId = "person id";

            var exception = new TraktCommentNotFoundException(commentId);

            exception.Message.Should().Be("Comment Not Found - method exists, but no record found");
            exception.ObjectId.Should().Be(commentId);
            exception.StatusCode.Should().Be(System.Net.HttpStatusCode.NotFound);
            exception.RequestUrl.Should().BeNullOrEmpty();
            exception.RequestBody.Should().BeNullOrEmpty();
            exception.Response.Should().BeNullOrEmpty();
        }

        [TestMethod]
        public void TestTraktCommentNotFoundExceptionConstructor()
        {
            var message = "exception message";
            var commentId = "person id";

            var exception = new TraktCommentNotFoundException(message, commentId);

            exception.Message.Should().Be(message);
            exception.ObjectId.Should().Be(commentId);
            exception.StatusCode.Should().Be(System.Net.HttpStatusCode.NotFound);
            exception.RequestUrl.Should().BeNullOrEmpty();
            exception.RequestBody.Should().BeNullOrEmpty();
            exception.Response.Should().BeNullOrEmpty();
        }
    }
}
