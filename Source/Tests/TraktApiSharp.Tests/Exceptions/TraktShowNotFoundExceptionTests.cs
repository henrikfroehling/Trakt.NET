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
            var exception = new TraktShowNotFoundException("", "");

            exception.Should().BeAssignableTo<TraktException>();
            exception.Should().BeAssignableTo<TraktObjectNotFoundException>();
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
        }
    }
}
