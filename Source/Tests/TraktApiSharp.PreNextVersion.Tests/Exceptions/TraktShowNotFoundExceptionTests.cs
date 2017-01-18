namespace TraktApiSharp.Tests.Exceptions
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using TraktApiSharp.Exceptions;

    [TestClass]
    public class TraktShowNotFoundExceptionTests
    {
        [TestMethod]
        public void TestTraktShowNotFoundExceptionBaseClass()
        {
            var exception = new TraktShowNotFoundException("");

            exception.Should().BeAssignableTo<TraktObjectNotFoundException>();
            exception.Should().BeAssignableTo<TraktException>();
        }

        [TestMethod]
        public void TestTraktShowNotFoundExceptionDefaultConstructor()
        {
            var showId = "show id";

            var exception = new TraktShowNotFoundException(showId);

            exception.Message.Should().Be("Show Not Found - method exists, but no record found");
            exception.ObjectId.Should().Be(showId);
            exception.StatusCode.Should().Be(System.Net.HttpStatusCode.NotFound);
            exception.RequestUrl.Should().BeNullOrEmpty();
            exception.RequestBody.Should().BeNullOrEmpty();
            exception.Response.Should().BeNullOrEmpty();
        }

        [TestMethod]
        public void TestTraktShowNotFoundExceptionConstructor()
        {
            var message = "exception message";
            var showId = "show id";

            var exception = new TraktShowNotFoundException(message, showId);

            exception.Message.Should().Be(message);
            exception.ObjectId.Should().Be(showId);
            exception.StatusCode.Should().Be(System.Net.HttpStatusCode.NotFound);
            exception.RequestUrl.Should().BeNullOrEmpty();
            exception.RequestBody.Should().BeNullOrEmpty();
            exception.Response.Should().BeNullOrEmpty();
        }
    }
}
