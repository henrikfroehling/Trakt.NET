namespace TraktApiSharp.Tests.Exceptions
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using TraktApiSharp.Exceptions;

    [TestClass]
    public class TraktSeasonNotFoundExceptionTests
    {
        [TestMethod]
        public void TestTraktSeasonNotFoundExceptionBaseClass()
        {
            var exception = new TraktSeasonNotFoundException("", "");

            exception.Should().BeAssignableTo<TraktException>();
            exception.Should().BeAssignableTo<TraktObjectNotFoundException>();
        }

        [TestMethod]
        public void TestTraktSeasonNotFoundExceptionConstructor()
        {
            var message = "exception message";
            var seasonId = "season id";

            var exception = new TraktSeasonNotFoundException(message, seasonId);

            exception.Message.Should().Be(message);
            exception.ObjectId.Should().Be(seasonId);
            exception.StatusCode.Should().Be(System.Net.HttpStatusCode.NotFound);
            exception.RequestUrl.Should().BeNullOrEmpty();
            exception.RequestBody.Should().BeNullOrEmpty();
        }
    }
}
