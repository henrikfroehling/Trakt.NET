namespace TraktApiSharp.Tests.Exceptions
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using TraktApiSharp.Exceptions;

    [TestClass]
    public class TraktBadGatewayExceptionTests
    {
        [TestMethod]
        public void TestTraktBadGatewayExceptionBaseClass()
        {
            var exception = new TraktBadGatewayException();

            exception.Should().BeAssignableTo<TraktException>();
        }

        [TestMethod]
        public void TestTraktBadGatewayExceptionDefaultConstructor()
        {
            var exception = new TraktBadGatewayException();

            exception.Message.Should().Be("Bad Gateway");
            exception.StatusCode.Should().Be(System.Net.HttpStatusCode.BadGateway);
            exception.RequestUrl.Should().BeNullOrEmpty();
            exception.RequestBody.Should().BeNullOrEmpty();
            exception.Response.Should().BeNullOrEmpty();
        }

        [TestMethod]
        public void TestTraktBadGatewayExceptionConstructor()
        {
            var message = "exception message";

            var exception = new TraktBadGatewayException(message);

            exception.Message.Should().Be(message);
            exception.StatusCode.Should().Be(System.Net.HttpStatusCode.BadGateway);
            exception.RequestUrl.Should().BeNullOrEmpty();
            exception.RequestBody.Should().BeNullOrEmpty();
            exception.Response.Should().BeNullOrEmpty();
        }
    }
}
