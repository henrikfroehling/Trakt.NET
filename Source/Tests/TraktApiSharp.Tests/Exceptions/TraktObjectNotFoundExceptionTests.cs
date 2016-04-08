namespace TraktApiSharp.Tests.Exceptions
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using TraktApiSharp.Exceptions;

    [TestClass]
    public class TraktObjectNotFoundExceptionTests
    {
        [TestMethod]
        public void TestTraktObjectNotFoundExceptionBaseClass()
        {
            var exception = new TraktObjectNotFoundException("");

            exception.Should().BeAssignableTo<TraktException>();
        }

        [TestMethod]
        public void TestTraktObjectNotFoundExceptionDefaultConstructor()
        {
            var objectId = "object id";

            var exception = new TraktObjectNotFoundException(objectId);

            exception.Message.Should().Be("Object Not Found - method exists, but no record found");
            exception.ObjectId.Should().Be(objectId);
            exception.StatusCode.Should().Be(System.Net.HttpStatusCode.NotFound);
            exception.RequestUrl.Should().BeNullOrEmpty();
            exception.RequestBody.Should().BeNullOrEmpty();
            exception.Response.Should().BeNullOrEmpty();
        }

        [TestMethod]
        public void TestTraktObjectNotFoundExceptionConstructor()
        {
            var message = "exception message";
            var objectId = "object id";

            var exception = new TraktObjectNotFoundException(message, objectId);

            exception.Message.Should().Be(message);
            exception.ObjectId.Should().Be(objectId);
            exception.StatusCode.Should().Be(System.Net.HttpStatusCode.NotFound);
            exception.RequestUrl.Should().BeNullOrEmpty();
            exception.RequestBody.Should().BeNullOrEmpty();
            exception.Response.Should().BeNullOrEmpty();
        }
    }
}
