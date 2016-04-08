namespace TraktApiSharp.Tests.Exceptions
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using TraktApiSharp.Exceptions;

    [TestClass]
    public class TraktExpiredExceptionTests
    {
        [TestMethod]
        public void TestTraktExpiredEExceptionBaseClass()
        {
            var exception = new TraktExpiredException();

            exception.Should().BeAssignableTo<TraktException>();
        }

        [TestMethod]
        public void TestTraktExpiredEExceptionDefaultConstructor()
        {
            var exception = new TraktExpiredException();

            exception.Message.Should().Be("Expired - the tokens have expired, restart the process");
            exception.StatusCode.Should().Be(default(System.Net.HttpStatusCode));
            exception.RequestUrl.Should().BeNullOrEmpty();
            exception.RequestBody.Should().BeNullOrEmpty();
            exception.Response.Should().BeNullOrEmpty();
        }

        [TestMethod]
        public void TestTraktExpiredEExceptionConstructor()
        {
            var message = "exception message";

            var exception = new TraktExpiredException(message);

            exception.Message.Should().Be(message);
            exception.StatusCode.Should().Be(default(System.Net.HttpStatusCode));
            exception.RequestUrl.Should().BeNullOrEmpty();
            exception.RequestBody.Should().BeNullOrEmpty();
            exception.Response.Should().BeNullOrEmpty();
        }
    }
}
