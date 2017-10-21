namespace TraktApiSharp.Tests.Exceptions
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using TraktApiSharp.Exceptions;

    [TestClass]
    public class TraktMethodNotFoundExceptionTests
    {
        [TestMethod]
        public void TestTraktMethodNotFoundExceptionDefaultConstructor()
        {
            var exception = new TraktMethodNotFoundException();

            exception.Message.Should().Be("Method Not Found - method doesn't exist");
            exception.StatusCode.Should().Be(System.Net.HttpStatusCode.MethodNotAllowed);
            exception.RequestUrl.Should().BeNullOrEmpty();
            exception.RequestBody.Should().BeNullOrEmpty();
            exception.Response.Should().BeNullOrEmpty();
        }

        [TestMethod]
        public void TestTraktMethodNotFoundExceptionConstructor()
        {
            var message = "exception message";

            var exception = new TraktMethodNotFoundException(message);

            exception.Message.Should().Be(message);
            exception.StatusCode.Should().Be(System.Net.HttpStatusCode.MethodNotAllowed);
            exception.RequestUrl.Should().BeNullOrEmpty();
            exception.RequestBody.Should().BeNullOrEmpty();
            exception.Response.Should().BeNullOrEmpty();
        }
    }
}
