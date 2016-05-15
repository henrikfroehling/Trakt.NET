namespace TraktApiSharp.Tests.Exceptions
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System.Net;
    using TraktApiSharp.Exceptions;

    [TestClass]
    public class TraktAuthenticationOAuthExceptonTests
    {
        [TestMethod]
        public void TestTraktAuthenticationOAuthExceptionBaseClass()
        {
            var exception = new TraktAuthenticationOAuthException("");

            exception.Should().BeAssignableTo<TraktException>();
        }

        [TestMethod]
        public void TestTraktAuthenticationOAuthExceptionDefaultConstructor()
        {
            var message = "exception message";

            var exception = new TraktAuthenticationOAuthException(message);

            exception.Message.Should().Be(message);
            exception.StatusCode.Should().Be(default(HttpStatusCode));
            exception.RequestUrl.Should().BeNullOrEmpty();
            exception.RequestBody.Should().BeNullOrEmpty();
            exception.Response.Should().BeNullOrEmpty();
        }
    }
}
