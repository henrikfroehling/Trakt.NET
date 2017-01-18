namespace TraktApiSharp.Tests.Exceptions
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System.Net;
    using TraktApiSharp.Exceptions;

    [TestClass]
    public class TraktAuthenticationExceptionTests
    {
        [TestMethod]
        public void TestTraktAuthenticationExceptionBaseClass()
        {
            var exception = new TraktAuthenticationException("");

            exception.Should().BeAssignableTo<TraktException>();
        }

        [TestMethod]
        public void TestTraktAuthenticationExceptionDefaultConstructor()
        {
            var message = "exception message";

            var exception = new TraktAuthenticationException(message);

            exception.Message.Should().Be(message);
            exception.StatusCode.Should().Be(default(HttpStatusCode));
            exception.RequestUrl.Should().BeNullOrEmpty();
            exception.RequestBody.Should().BeNullOrEmpty();
            exception.Response.Should().BeNullOrEmpty();
        }
    }
}
