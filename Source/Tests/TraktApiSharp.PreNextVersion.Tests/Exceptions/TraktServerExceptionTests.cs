namespace TraktApiSharp.Tests.Exceptions
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using TraktApiSharp.Exceptions;

    [TestClass]
    public class TraktServerExceptionTests
    {
        [TestMethod]
        public void TestTraktServerExceptionBaseClass()
        {
            var exception = new TraktServerException();

            exception.Should().BeAssignableTo<TraktException>();
        }

        [TestMethod]
        public void TestTraktServerExceptionDefaultConstructor()
        {
            var exception = new TraktServerException();

            exception.Message.Should().Be("Server Error");
            exception.StatusCode.Should().Be(System.Net.HttpStatusCode.InternalServerError);
            exception.RequestUrl.Should().BeNullOrEmpty();
            exception.RequestBody.Should().BeNullOrEmpty();
            exception.Response.Should().BeNullOrEmpty();
        }

        [TestMethod]
        public void TestTraktServerExceptionConstructor()
        {
            var message = "exception message";

            var exception = new TraktServerException(message);

            exception.Message.Should().Be(message);
            exception.StatusCode.Should().Be(System.Net.HttpStatusCode.InternalServerError);
            exception.RequestUrl.Should().BeNullOrEmpty();
            exception.RequestBody.Should().BeNullOrEmpty();
            exception.Response.Should().BeNullOrEmpty();
        }
    }
}
