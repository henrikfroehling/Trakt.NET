namespace TraktApiSharp.Tests.Exceptions
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using TraktApiSharp.Exceptions;

    [TestClass]
    public class TraktEpisodeNotFoundExceptionTests
    {
        [TestMethod]
        public void TestTraktEpisodeNotFoundExceptionDefaultConstructor()
        {
            var showId = "show id";
            var seasonNr = 1U;
            var episodeNr = 2U;

            var exception = new TraktEpisodeNotFoundException(showId, seasonNr, episodeNr);

            exception.Message.Should().Be("Episode Not Found - method exists, but no record found");
            exception.ObjectId.Should().Be(showId);
            exception.Season.Should().Be(seasonNr);
            exception.Episode.Should().Be(episodeNr);
            exception.StatusCode.Should().Be(System.Net.HttpStatusCode.NotFound);
            exception.RequestUrl.Should().BeNullOrEmpty();
            exception.RequestBody.Should().BeNullOrEmpty();
            exception.Response.Should().BeNullOrEmpty();
        }

        [TestMethod]
        public void TestTraktEpisodeNotFoundExceptionConstructor()
        {
            var message = "exception message";
            var showId = "show id";
            var seasonNr = 1U;
            var episodeNr = 2U;

            var exception = new TraktEpisodeNotFoundException(message, showId, seasonNr, episodeNr);

            exception.Message.Should().Be(message);
            exception.ObjectId.Should().Be(showId);
            exception.Season.Should().Be(seasonNr);
            exception.Episode.Should().Be(episodeNr);
            exception.StatusCode.Should().Be(System.Net.HttpStatusCode.NotFound);
            exception.RequestUrl.Should().BeNullOrEmpty();
            exception.RequestBody.Should().BeNullOrEmpty();
            exception.Response.Should().BeNullOrEmpty();
        }
    }
}
