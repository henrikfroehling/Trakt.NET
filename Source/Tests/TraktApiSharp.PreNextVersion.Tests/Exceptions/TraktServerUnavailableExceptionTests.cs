namespace TraktApiSharp.Tests.Exceptions
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using TraktApiSharp.Exceptions;

    [TestClass]
    public class TraktServerUnavailableExceptionTests
    {
        [TestMethod]
        public void TestTraktServerUnavailableExceptionDefaultConstructor()
        {
            var exception = new TraktServerUnavailableException();

            exception.Message.Should().Be("Service Unavailable - server overloaded (try again in 30s)");
            exception.StatusCode.Should().Be(System.Net.HttpStatusCode.ServiceUnavailable);
            exception.RequestUrl.Should().BeNullOrEmpty();
            exception.RequestBody.Should().BeNullOrEmpty();
            exception.Response.Should().BeNullOrEmpty();
        }

        [TestMethod]
        public void TestTraktServerUnavailableExceptionConstructor()
        {
            var message = "exception message";

            var exception = new TraktServerUnavailableException(message);

            exception.Message.Should().Be(message);
            exception.StatusCode.Should().Be(System.Net.HttpStatusCode.ServiceUnavailable);
            exception.RequestUrl.Should().BeNullOrEmpty();
            exception.RequestBody.Should().BeNullOrEmpty();
            exception.Response.Should().BeNullOrEmpty();
        }
    }
}
