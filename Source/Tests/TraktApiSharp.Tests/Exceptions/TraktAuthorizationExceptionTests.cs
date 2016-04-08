namespace TraktApiSharp.Tests.Exceptions
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using TraktApiSharp.Exceptions;

    [TestClass]
    public class TraktAuthorizationExceptionTests
    {
        [TestMethod]
        public void TestTraktAuthorizationExceptionBaseClass()
        {
            var exception = new TraktAuthorizationException("");

            exception.Should().BeAssignableTo<TraktException>();
        }

        [TestMethod]
        public void TestTraktAuthorizationExceptionConstructor()
        {
            var message = "exception message";

            var exception = new TraktAuthorizationException(message);

            exception.Message.Should().Be(message);
            exception.StatusCode.Should().Be(System.Net.HttpStatusCode.Unauthorized);
            exception.RequestUrl.Should().BeNullOrEmpty();
            exception.RequestBody.Should().BeNullOrEmpty();
        }
    }
}
