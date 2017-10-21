namespace TraktApiSharp.Tests.Exceptions
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using TraktApiSharp.Exceptions;

    [TestClass]
    public class TraktForbiddenExceptionTests
    {
        [TestMethod]
        public void TestTraktForbiddenExceptionDefaultConstructor()
        {
            var exception = new TraktForbiddenException();

            exception.Message.Should().Be("Forbidden - invalid API key or unapproved app");
            exception.StatusCode.Should().Be(System.Net.HttpStatusCode.Forbidden);
            exception.RequestUrl.Should().BeNullOrEmpty();
            exception.RequestBody.Should().BeNullOrEmpty();
            exception.Response.Should().BeNullOrEmpty();
        }

        [TestMethod]
        public void TestTraktForbiddenExceptionConstructor()
        {
            var message = "exception message";

            var exception = new TraktForbiddenException(message);

            exception.Message.Should().Be(message);
            exception.StatusCode.Should().Be(System.Net.HttpStatusCode.Forbidden);
            exception.RequestUrl.Should().BeNullOrEmpty();
            exception.RequestBody.Should().BeNullOrEmpty();
            exception.Response.Should().BeNullOrEmpty();
        }
    }
}
