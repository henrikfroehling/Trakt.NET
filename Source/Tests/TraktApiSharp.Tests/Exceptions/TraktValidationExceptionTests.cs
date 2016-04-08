namespace TraktApiSharp.Tests.Exceptions
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using TraktApiSharp.Exceptions;

    [TestClass]
    public class TraktValidationExceptionTests
    {
        [TestMethod]
        public void TestTraktValidationExceptionBaseClass()
        {
            var exception = new TraktValidationException();

            exception.Should().BeAssignableTo<TraktException>();
        }

        [TestMethod]
        public void TestTraktValidationExceptionDefaultConstructor()
        {
            var exception = new TraktValidationException();

            exception.Message.Should().Be("Unprocessible Entity - validation errors");
            exception.StatusCode.Should().Be(default(System.Net.HttpStatusCode));
            exception.RequestUrl.Should().BeNullOrEmpty();
            exception.RequestBody.Should().BeNullOrEmpty();
            exception.Response.Should().BeNullOrEmpty();
        }

        [TestMethod]
        public void TestTraktValidationExceptionConstructor()
        {
            var message = "exception message";

            var exception = new TraktValidationException(message);

            exception.Message.Should().Be(message);
            exception.StatusCode.Should().Be(default(System.Net.HttpStatusCode));
            exception.RequestUrl.Should().BeNullOrEmpty();
            exception.RequestBody.Should().BeNullOrEmpty();
            exception.Response.Should().BeNullOrEmpty();
        }
    }
}
