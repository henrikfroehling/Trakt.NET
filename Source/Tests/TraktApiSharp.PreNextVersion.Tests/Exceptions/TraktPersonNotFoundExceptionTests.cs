namespace TraktApiSharp.Tests.Exceptions
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using TraktApiSharp.Exceptions;

    [TestClass]
    public class TraktPersonNotFoundExceptionTests
    {
        [TestMethod]
        public void TestTraktPersonNotFoundExceptionBaseClass()
        {
            var exception = new TraktPersonNotFoundException("");

            exception.Should().BeAssignableTo<TraktException>();
            exception.Should().BeAssignableTo<TraktObjectNotFoundException>();
        }

        [TestMethod]
        public void TestTraktPersonNotFoundExceptionDefaultConstructor()
        {
            var personId = "person id";

            var exception = new TraktPersonNotFoundException(personId);

            exception.Message.Should().Be("Person Not Found - method exists, but no record found");
            exception.ObjectId.Should().Be(personId);
            exception.StatusCode.Should().Be(System.Net.HttpStatusCode.NotFound);
            exception.RequestUrl.Should().BeNullOrEmpty();
            exception.RequestBody.Should().BeNullOrEmpty();
            exception.Response.Should().BeNullOrEmpty();
        }

        [TestMethod]
        public void TestTraktPersonNotFoundExceptionConstructor()
        {
            var message = "exception message";
            var personId = "person id";

            var exception = new TraktPersonNotFoundException(message, personId);

            exception.Message.Should().Be(message);
            exception.ObjectId.Should().Be(personId);
            exception.StatusCode.Should().Be(System.Net.HttpStatusCode.NotFound);
            exception.RequestUrl.Should().BeNullOrEmpty();
            exception.RequestBody.Should().BeNullOrEmpty();
            exception.Response.Should().BeNullOrEmpty();
        }
    }
}
