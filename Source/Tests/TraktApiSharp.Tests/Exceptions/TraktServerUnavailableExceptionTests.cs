namespace TraktApiSharp.Tests.Exceptions
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using TraktApiSharp.Exceptions;

    [TestClass]
    public class TraktServerUnavailableExceptionTests
    {
        [TestMethod]
        public void TestTraktServerUnavailableExceptionBaseClass()
        {
            var exception = new TraktServerUnavailableException("");

            exception.Should().BeAssignableTo<TraktException>();
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
        }
    }
}
