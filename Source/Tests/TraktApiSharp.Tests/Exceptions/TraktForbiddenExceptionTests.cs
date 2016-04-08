namespace TraktApiSharp.Tests.Exceptions
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using TraktApiSharp.Exceptions;

    [TestClass]
    public class TraktForbiddenExceptionTests
    {
        [TestMethod]
        public void TestTraktForbiddenExceptionBaseClass()
        {
            var exception = new TraktForbiddenException("");

            exception.Should().BeAssignableTo<TraktException>();
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
        }
    }
}
