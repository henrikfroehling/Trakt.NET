namespace TraktApiSharp.Tests.Exceptions
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System.Net;
    using TraktApiSharp.Exceptions;

    [TestClass]
    public class TraktAuthenticationDeviceExceptionTests
    {
        [TestMethod]
        public void TestTraktAuthenticationDeviceExceptionBaseClass()
        {
            var exception = new TraktAuthenticationDeviceException("");

            exception.Should().BeAssignableTo<TraktException>();
        }

        [TestMethod]
        public void TestTraktAuthenticationDeviceExceptionDefaultConstructor()
        {
            var message = "exception message";

            var exception = new TraktAuthenticationDeviceException(message);

            exception.Message.Should().Be(message);
            exception.StatusCode.Should().Be(default(HttpStatusCode));
            exception.RequestUrl.Should().BeNullOrEmpty();
            exception.RequestBody.Should().BeNullOrEmpty();
            exception.Response.Should().BeNullOrEmpty();
        }
    }
}
