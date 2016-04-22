namespace TraktApiSharp.Tests.Objects.Post.Checkins.Responses
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Newtonsoft.Json;
    using System;
    using TraktApiSharp.Objects.Post.Checkins.Responses;
    using Utils;

    [TestClass]
    public class TraktEpisodeCheckinPostResponseTests
    {
        [TestMethod]
        public void TestTraktEpisodeCheckinPostResponseDefaultConstructor()
        {
            var episodeCheckinResponse = new TraktEpisodeCheckinPostResponse();

            episodeCheckinResponse.WatchedAt.Should().Be(DateTime.MinValue);
            episodeCheckinResponse.Sharing.Should().BeNull();
            episodeCheckinResponse.Episode.Should().BeNull();
            episodeCheckinResponse.Show.Should().BeNull();
        }

        [TestMethod]
        public void TestTraktEpisodeCheckinPostResponseReadFromJson()
        {
            var jsonFile = TestUtility.ReadFileContents(@"Objects\Post\Checkins\Responses\EpisodeCheckinPostResponse.json");

            jsonFile.Should().NotBeNullOrEmpty();

            var episodeCheckinResponse = JsonConvert.DeserializeObject<TraktEpisodeCheckinPostResponse>(jsonFile);

            episodeCheckinResponse.Should().NotBeNull();
            episodeCheckinResponse.WatchedAt.Should().Be(DateTime.Parse("2014-08-06T06:54:36.859Z").ToUniversalTime());
            episodeCheckinResponse.Sharing.Should().NotBeNull();
            episodeCheckinResponse.Sharing.Facebook.Should().BeTrue();
            episodeCheckinResponse.Sharing.Twitter.Should().BeTrue();
            episodeCheckinResponse.Sharing.Tumblr.Should().BeFalse();
            episodeCheckinResponse.Episode.Should().NotBeNull();
            episodeCheckinResponse.Episode.SeasonNumber.Should().Be(1);
            episodeCheckinResponse.Episode.Number.Should().Be(1);
            episodeCheckinResponse.Episode.Title.Should().Be("Pilot");
            episodeCheckinResponse.Episode.Ids.Should().NotBeNull();
            episodeCheckinResponse.Episode.Ids.Trakt.Should().Be(16);
            episodeCheckinResponse.Episode.Ids.Tvdb.Should().Be(349232);
            episodeCheckinResponse.Episode.Ids.Imdb.Should().Be("tt0959621");
            episodeCheckinResponse.Episode.Ids.Tmdb.Should().Be(62085);
            episodeCheckinResponse.Episode.Ids.TvRage.Should().Be(637041);
            episodeCheckinResponse.Show.Should().NotBeNull();
            episodeCheckinResponse.Show.Title.Should().Be("Breaking Bad");
            episodeCheckinResponse.Show.Year.Should().Be(2008);
            episodeCheckinResponse.Show.Ids.Should().NotBeNull();
            episodeCheckinResponse.Show.Ids.Trakt.Should().Be(1);
            episodeCheckinResponse.Show.Ids.Slug.Should().Be("breaking-bad");
            episodeCheckinResponse.Show.Ids.Tvdb.Should().Be(81189);
            episodeCheckinResponse.Show.Ids.Imdb.Should().Be("tt0903747");
            episodeCheckinResponse.Show.Ids.Tmdb.Should().Be(1396);
            episodeCheckinResponse.Show.Ids.TvRage.Should().Be(18164);
        }
    }
}
