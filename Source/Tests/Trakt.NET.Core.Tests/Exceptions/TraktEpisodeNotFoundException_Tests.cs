namespace TraktNet.Core.Tests.Exceptions
{
    using FluentAssertions;
    using System.Net;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Exceptions;
    using Xunit;

    [TestCategory("Exceptions")]
    public class TraktEpisodeNotFoundException_Tests
    {
        [Fact]
        public void Test_TraktEpisodeNotFoundException_DefaultConstructor()
        {
            const string showId = "show id";
            const uint seasonNr = 1U;
            const uint episodeNr = 2U;

            var exception = new TraktEpisodeNotFoundException(showId, seasonNr, episodeNr);

            exception.Message.Should().Be("Episode Not Found - method exists, but no record found");
            exception.ObjectId.Should().Be(showId);
            exception.Season.Should().Be(seasonNr);
            exception.Episode.Should().Be(episodeNr);
            exception.StatusCode.Should().Be(HttpStatusCode.NotFound);
            exception.RequestUrl.Should().BeNullOrEmpty();
            exception.RequestBody.Should().BeNullOrEmpty();
            exception.Response.Should().BeNullOrEmpty();
        }

        [Fact]
        public void Test_TraktEpisodeNotFoundException_Constructor()
        {
            const string message = "exception message";
            const string showId = "show id";
            const uint seasonNr = 1U;
            const uint episodeNr = 2U;

            var exception = new TraktEpisodeNotFoundException(message, showId, seasonNr, episodeNr);

            exception.Message.Should().Be(message);
            exception.ObjectId.Should().Be(showId);
            exception.Season.Should().Be(seasonNr);
            exception.Episode.Should().Be(episodeNr);
            exception.StatusCode.Should().Be(HttpStatusCode.NotFound);
            exception.RequestUrl.Should().BeNullOrEmpty();
            exception.RequestBody.Should().BeNullOrEmpty();
            exception.Response.Should().BeNullOrEmpty();
        }
    }
}
