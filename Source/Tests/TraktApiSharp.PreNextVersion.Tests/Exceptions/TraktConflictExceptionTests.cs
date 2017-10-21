namespace TraktApiSharp.Tests.Exceptions
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using TraktApiSharp.Exceptions;

    [TestClass]
    public class TraktConflictExceptionTests
    {
        [TestMethod]
        public void TestTraktConflictExceptionDefaultConstructor()
        {
            var exception = new TraktConflictException();

            exception.Message.Should().Be("Conflict - resource already created");
            exception.StatusCode.Should().Be(System.Net.HttpStatusCode.Conflict);
            exception.RequestUrl.Should().BeNullOrEmpty();
            exception.RequestBody.Should().BeNullOrEmpty();
            exception.Response.Should().BeNullOrEmpty();
        }

        [TestMethod]
        public void TestTraktConflictExceptionConstructor()
        {
            var message = "exception message";

            var exception = new TraktConflictException(message);

            exception.Message.Should().Be(message);
            exception.StatusCode.Should().Be(System.Net.HttpStatusCode.Conflict);
            exception.RequestUrl.Should().BeNullOrEmpty();
            exception.RequestBody.Should().BeNullOrEmpty();
            exception.Response.Should().BeNullOrEmpty();
        }
    }
}
