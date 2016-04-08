namespace TraktApiSharp.Tests.Exceptions
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using TraktApiSharp.Exceptions;

    [TestClass]
    public class TraktBadRequestExceptionTests
    {
        [TestMethod]
        public void TestTraktBadRequestExceptionBaseClass()
        {
            var exception = new TraktBadRequestException();

            exception.Should().BeAssignableTo<TraktException>();
        }

        [TestMethod]
        public void TestTraktBadRequestExceptionDefaultConstructor()
        {
            var exception = new TraktBadRequestException();

            exception.Message.Should().Be("Bad Request - request couldn't be parsed");
            exception.StatusCode.Should().Be(System.Net.HttpStatusCode.BadRequest);
            exception.RequestUrl.Should().BeNullOrEmpty();
            exception.RequestBody.Should().BeNullOrEmpty();
            exception.Response.Should().BeNullOrEmpty();
        }

        [TestMethod]
        public void TestTraktBadRequestExceptionConstructor()
        {
            var message = "exception message";

            var exception = new TraktBadRequestException(message);

            exception.Message.Should().Be(message);
            exception.StatusCode.Should().Be(System.Net.HttpStatusCode.BadRequest);
            exception.RequestUrl.Should().BeNullOrEmpty();
            exception.RequestBody.Should().BeNullOrEmpty();
            exception.Response.Should().BeNullOrEmpty();
        }
    }
}
