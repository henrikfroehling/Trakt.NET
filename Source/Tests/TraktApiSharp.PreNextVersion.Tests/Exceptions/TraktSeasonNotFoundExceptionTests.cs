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
            var exception = new TraktSeasonNotFoundException("", 1);

            exception.Should().BeAssignableTo<TraktShowNotFoundException>();
            exception.Should().BeAssignableTo<TraktObjectNotFoundException>();
            exception.Should().BeAssignableTo<TraktException>();
        }

        [TestMethod]
        public void TestTraktSeasonNotFoundExceptionDefaultConstructor()
        {
            var showId = "show id";
            var seasonNr = 1U;

            var exception = new TraktSeasonNotFoundException(showId, seasonNr);

            exception.Message.Should().Be("Season Not Found - method exists, but no record found");
            exception.ObjectId.Should().Be(showId);
            exception.Season.Should().Be(seasonNr);
            exception.StatusCode.Should().Be(System.Net.HttpStatusCode.NotFound);
            exception.RequestUrl.Should().BeNullOrEmpty();
            exception.RequestBody.Should().BeNullOrEmpty();
            exception.Response.Should().BeNullOrEmpty();
        }

        [TestMethod]
        public void TestTraktSeasonNotFoundExceptionConstructor()
        {
            var message = "exception message";
            var showId = "show id";
            var seasonNr = 1U;

            var exception = new TraktSeasonNotFoundException(message, showId, seasonNr);

            exception.Message.Should().Be(message);
            exception.ObjectId.Should().Be(showId);
            exception.Season.Should().Be(seasonNr);
            exception.StatusCode.Should().Be(System.Net.HttpStatusCode.NotFound);
            exception.RequestUrl.Should().BeNullOrEmpty();
            exception.RequestBody.Should().BeNullOrEmpty();
            exception.Response.Should().BeNullOrEmpty();
        }
    }
}
