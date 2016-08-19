namespace TraktApiSharp.Tests.Objects.Get.Users
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Newtonsoft.Json;
    using System;
    using TraktApiSharp.Enums;
    using TraktApiSharp.Objects.Get.Users;
    using Utils;

    [TestClass]
    public class TraktUserWatchingItemTests
    {
        [TestMethod]
        public void TestTraktUserWatchingItemDefaultConstructor()
        {
            var watchingItem = new TraktUserWatchingItem();

            watchingItem.ExpiresAt.Should().NotHaveValue();
            watchingItem.StartedAt.Should().NotHaveValue();
            watchingItem.Action.Should().BeNull();
            watchingItem.Type.Should().BeNull();
            watchingItem.Movie.Should().BeNull();
            watchingItem.Show.Should().BeNull();
            watchingItem.Episode.Should().BeNull();
        }

        [TestMethod]
        public void TestTraktUserWatchingItemReadFromJsonMovie()
        {
            var jsonFile = TestUtility.ReadFileContents(@"Objects\Get\Users\Watching\UserWatchingItemMovie.json");

            jsonFile.Should().NotBeNullOrEmpty();

            var userWatchlistItemMovie = JsonConvert.DeserializeObject<TraktUserWatchingItem>(jsonFile);

            userWatchlistItemMovie.Should().NotBeNull();

            userWatchlistItemMovie.ExpiresAt.Should().Be(DateTime.Parse("2014-10-23T08:36:02.000Z").ToUniversalTime());
            userWatchlistItemMovie.StartedAt.Should().Be(DateTime.Parse("2014-10-23T06:44:02.000Z").ToUniversalTime());
            userWatchlistItemMovie.Action.Should().Be(TraktHistoryActionType.Checkin);
            userWatchlistItemMovie.Type.Should().Be(TraktSyncType.Movie);
            userWatchlistItemMovie.Movie.Should().NotBeNull();
            userWatchlistItemMovie.Movie.Title.Should().Be("Super 8");
            userWatchlistItemMovie.Movie.Year.Should().Be(2011);
            userWatchlistItemMovie.Movie.Ids.Should().NotBeNull();
            userWatchlistItemMovie.Movie.Ids.Trakt.Should().Be(2U);
            userWatchlistItemMovie.Movie.Ids.Slug.Should().Be("super-8-2011");
            userWatchlistItemMovie.Movie.Ids.Imdb.Should().Be("tt1650062");
            userWatchlistItemMovie.Movie.Ids.Tmdb.Should().Be(37686U);
            userWatchlistItemMovie.Show.Should().BeNull();
            userWatchlistItemMovie.Episode.Should().BeNull();
        }

        [TestMethod]
        public void TestTraktUserWatchingItemReadFromJsonEpisode()
        {
            var jsonFile = TestUtility.ReadFileContents(@"Objects\Get\Users\Watching\UserWatchingItemEpisode.json");

            jsonFile.Should().NotBeNullOrEmpty();

            var userWatchlistItemEpisode = JsonConvert.DeserializeObject<TraktUserWatchingItem>(jsonFile);

            userWatchlistItemEpisode.Should().NotBeNull();

            userWatchlistItemEpisode.ExpiresAt.Should().Be(DateTime.Parse("2014-10-23T07:09:12.000Z").ToUniversalTime());
            userWatchlistItemEpisode.StartedAt.Should().Be(DateTime.Parse("2014-10-23T06:24:12.000Z").ToUniversalTime());
            userWatchlistItemEpisode.Action.Should().Be(TraktHistoryActionType.Scrobble);
            userWatchlistItemEpisode.Type.Should().Be(TraktSyncType.Episode);
            userWatchlistItemEpisode.Movie.Should().BeNull();
            userWatchlistItemEpisode.Show.Should().NotBeNull();
            userWatchlistItemEpisode.Show.Title.Should().Be("Breaking Bad");
            userWatchlistItemEpisode.Show.Year.Should().Be(2008);
            userWatchlistItemEpisode.Show.Ids.Should().NotBeNull();
            userWatchlistItemEpisode.Show.Ids.Trakt.Should().Be(1U);
            userWatchlistItemEpisode.Show.Ids.Slug.Should().Be("breaking-bad");
            userWatchlistItemEpisode.Show.Ids.Tvdb.Should().Be(81189U);
            userWatchlistItemEpisode.Show.Ids.Imdb.Should().Be("tt0903747");
            userWatchlistItemEpisode.Show.Ids.Tmdb.Should().Be(1396U);
            userWatchlistItemEpisode.Show.Ids.TvRage.Should().Be(18164U);
            userWatchlistItemEpisode.Episode.Should().NotBeNull();
            userWatchlistItemEpisode.Episode.SeasonNumber.Should().Be(0);
            userWatchlistItemEpisode.Episode.Number.Should().Be(2);
            userWatchlistItemEpisode.Episode.Title.Should().Be("Wedding Day");
            userWatchlistItemEpisode.Episode.Ids.Should().NotBeNull();
            userWatchlistItemEpisode.Episode.Ids.Trakt.Should().Be(2U);
            userWatchlistItemEpisode.Episode.Ids.Tvdb.Should().Be(3859791U);
            userWatchlistItemEpisode.Episode.Ids.Imdb.Should().BeEmpty();
            userWatchlistItemEpisode.Episode.Ids.Tmdb.Should().Be(62133U);
            userWatchlistItemEpisode.Episode.Ids.TvRage.Should().BeNull();
        }
    }
}
