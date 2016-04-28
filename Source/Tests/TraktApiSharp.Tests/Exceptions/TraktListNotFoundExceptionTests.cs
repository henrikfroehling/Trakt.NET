namespace TraktApiSharp.Tests.Exceptions
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using TraktApiSharp.Exceptions;

    [TestClass]
    public class TraktListNotFoundExceptionTests
    {
        [TestMethod]
        public void TestTraktListNotFoundExceptionBaseClass()
        {
            var exception = new TraktListNotFoundException("");

            exception.Should().BeAssignableTo<TraktException>();
            exception.Should().BeAssignableTo<TraktObjectNotFoundException>();
        }

        [TestMethod]
        public void TestTraktListNotFoundExceptionDefaultConstructor()
        {
            var listId = "list id";

            var exception = new TraktListNotFoundException(listId);

            exception.Message.Should().Be("List Not Found - method exists, but no record found");
            exception.ObjectId.Should().Be(listId);
            exception.StatusCode.Should().Be(System.Net.HttpStatusCode.NotFound);
            exception.RequestUrl.Should().BeNullOrEmpty();
            exception.RequestBody.Should().BeNullOrEmpty();
            exception.Response.Should().BeNullOrEmpty();
        }

        [TestMethod]
        public void TestTraktListNotFoundExceptionConstructor()
        {
            var message = "exception message";
            var listId = "list id";

            var exception = new TraktListNotFoundException(message, listId);

            exception.Message.Should().Be(message);
            exception.ObjectId.Should().Be(listId);
            exception.StatusCode.Should().Be(System.Net.HttpStatusCode.NotFound);
            exception.RequestUrl.Should().BeNullOrEmpty();
            exception.RequestBody.Should().BeNullOrEmpty();
            exception.Response.Should().BeNullOrEmpty();
        }
    }
}
