namespace TraktApiSharp.Tests.Objects.Get.Users
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using TraktApiSharp.Enums;
    using TraktApiSharp.Objects.Get.Users;
    using Utils;

    [TestClass]
    public class TraktUserWatchlistItemTests
    {
        [TestMethod]
        public void TestTraktSyncWatchlistItemDefaultConstructor()
        {
            var userWatchlistItem = new TraktUserWatchlistItem();

            userWatchlistItem.ListedAt.Should().Be(DateTime.MinValue);
            userWatchlistItem.Type.Should().Be(TraktSyncItemType.Unspecified);
            userWatchlistItem.Movie.Should().BeNull();
            userWatchlistItem.Show.Should().BeNull();
            userWatchlistItem.Season.Should().BeNull();
            userWatchlistItem.Episode.Should().BeNull();
        }

        [TestMethod]
        public void TestTraktSyncWatchlistItemReadFromJsonMovies()
        {
            var jsonFile = TestUtility.ReadFileContents(@"Objects\Get\Users\Watchlist\UserWatchlistMovies.json");

            jsonFile.Should().NotBeNullOrEmpty();

            var userWatchlistItems = JsonConvert.DeserializeObject<IEnumerable<TraktUserWatchlistItem>>(jsonFile);

            userWatchlistItems.Should().NotBeNull();
            userWatchlistItems.Should().HaveCount(2);

            var watchlistItems = userWatchlistItems.ToArray();

            watchlistItems[0].ListedAt.Should().Be(DateTime.Parse("2014-09-01T09:10:11.000Z").ToUniversalTime());
            watchlistItems[0].Type.Should().Be(TraktSyncItemType.Movie);
            watchlistItems[0].Movie.Should().NotBeNull();
            watchlistItems[0].Movie.Title.Should().Be("TRON: Legacy");
            watchlistItems[0].Movie.Year.Should().Be(2010);
            watchlistItems[0].Movie.Ids.Should().NotBeNull();
            watchlistItems[0].Movie.Ids.Trakt.Should().Be(1);
            watchlistItems[0].Movie.Ids.Slug.Should().Be("tron-legacy-2010");
            watchlistItems[0].Movie.Ids.Imdb.Should().Be("tt1104001");
            watchlistItems[0].Movie.Ids.Tmdb.Should().Be(20526);
            watchlistItems[0].Show.Should().BeNull();
            watchlistItems[0].Season.Should().BeNull();
            watchlistItems[0].Episode.Should().BeNull();

            watchlistItems[1].ListedAt.Should().Be(DateTime.Parse("2014-09-02T09:10:11.000Z").ToUniversalTime());
            watchlistItems[1].Type.Should().Be(TraktSyncItemType.Movie);
            watchlistItems[1].Movie.Should().NotBeNull();
            watchlistItems[1].Movie.Title.Should().Be("The Dark Knight");
            watchlistItems[1].Movie.Year.Should().Be(2008);
            watchlistItems[1].Movie.Ids.Should().NotBeNull();
            watchlistItems[1].Movie.Ids.Trakt.Should().Be(6);
            watchlistItems[1].Movie.Ids.Slug.Should().Be("the-dark-knight-2008");
            watchlistItems[1].Movie.Ids.Imdb.Should().Be("tt0468569");
            watchlistItems[1].Movie.Ids.Tmdb.Should().Be(155);
            watchlistItems[1].Show.Should().BeNull();
            watchlistItems[1].Season.Should().BeNull();
            watchlistItems[1].Episode.Should().BeNull();
        }

        [TestMethod]
        public void TestTraktSyncWatchlistItemReadFromJsonShows()
        {
            var jsonFile = TestUtility.ReadFileContents(@"Objects\Get\Users\Watchlist\UserWatchlistShows.json");

            jsonFile.Should().NotBeNullOrEmpty();

            var userWatchlistItems = JsonConvert.DeserializeObject<IEnumerable<TraktUserWatchlistItem>>(jsonFile);

            userWatchlistItems.Should().NotBeNull();
            userWatchlistItems.Should().HaveCount(2);

            var watchlistItems = userWatchlistItems.ToArray();

            watchlistItems[0].ListedAt.Should().Be(DateTime.Parse("2014-09-01T09:10:11.000Z").ToUniversalTime());
            watchlistItems[0].Type.Should().Be(TraktSyncItemType.Show);
            watchlistItems[0].Movie.Should().BeNull();
            watchlistItems[0].Show.Should().NotBeNull();
            watchlistItems[0].Show.Title.Should().Be("Breaking Bad");
            watchlistItems[0].Show.Year.Should().Be(2008);
            watchlistItems[0].Show.Ids.Should().NotBeNull();
            watchlistItems[0].Show.Ids.Trakt.Should().Be(1);
            watchlistItems[0].Show.Ids.Slug.Should().Be("breaking-bad");
            watchlistItems[0].Show.Ids.Tvdb.Should().Be(81189);
            watchlistItems[0].Show.Ids.Imdb.Should().Be("tt0903747");
            watchlistItems[0].Show.Ids.Tmdb.Should().Be(1396);
            watchlistItems[0].Show.Ids.TvRage.Should().Be(18164);
            watchlistItems[0].Season.Should().BeNull();
            watchlistItems[0].Episode.Should().BeNull();

            watchlistItems[1].ListedAt.Should().Be(DateTime.Parse("2014-09-02T09:10:11.000Z").ToUniversalTime());
            watchlistItems[1].Type.Should().Be(TraktSyncItemType.Show);
            watchlistItems[1].Movie.Should().BeNull();
            watchlistItems[1].Show.Should().NotBeNull();
            watchlistItems[1].Show.Title.Should().Be("The Walking Dead");
            watchlistItems[1].Show.Year.Should().Be(2010);
            watchlistItems[1].Show.Ids.Should().NotBeNull();
            watchlistItems[1].Show.Ids.Trakt.Should().Be(2);
            watchlistItems[1].Show.Ids.Slug.Should().Be("the-walking-dead");
            watchlistItems[1].Show.Ids.Tvdb.Should().Be(153021);
            watchlistItems[1].Show.Ids.Imdb.Should().Be("tt1520211");
            watchlistItems[1].Show.Ids.Tmdb.Should().Be(1402);
            watchlistItems[1].Show.Ids.TvRage.Should().NotHaveValue();
            watchlistItems[1].Season.Should().BeNull();
            watchlistItems[1].Episode.Should().BeNull();
        }

        [TestMethod]
        public void TestTraktSyncWatchlistItemReadFromJsonSeasons()
        {
            var jsonFile = TestUtility.ReadFileContents(@"Objects\Get\Users\Watchlist\UserWatchlistSeasons.json");

            jsonFile.Should().NotBeNullOrEmpty();

            var userWatchlistItems = JsonConvert.DeserializeObject<IEnumerable<TraktUserWatchlistItem>>(jsonFile);

            userWatchlistItems.Should().NotBeNull();
            userWatchlistItems.Should().HaveCount(2);

            var watchlistItems = userWatchlistItems.ToArray();

            watchlistItems[0].ListedAt.Should().Be(DateTime.Parse("2014-09-01T09:10:11.000Z").ToUniversalTime());
            watchlistItems[0].Type.Should().Be(TraktSyncItemType.Season);
            watchlistItems[0].Movie.Should().BeNull();
            watchlistItems[0].Show.Should().NotBeNull();
            watchlistItems[0].Show.Title.Should().Be("Breaking Bad");
            watchlistItems[0].Show.Year.Should().Be(2008);
            watchlistItems[0].Show.Ids.Should().NotBeNull();
            watchlistItems[0].Show.Ids.Trakt.Should().Be(1);
            watchlistItems[0].Show.Ids.Slug.Should().Be("breaking-bad");
            watchlistItems[0].Show.Ids.Tvdb.Should().Be(81189);
            watchlistItems[0].Show.Ids.Imdb.Should().Be("tt0903747");
            watchlistItems[0].Show.Ids.Tmdb.Should().Be(1396);
            watchlistItems[0].Show.Ids.TvRage.Should().Be(18164);
            watchlistItems[0].Season.Should().NotBeNull();
            watchlistItems[0].Season.Number.Should().Be(3);
            watchlistItems[0].Season.Ids.Should().NotBeNull();
            watchlistItems[0].Season.Ids.Trakt.Should().Be(0);
            watchlistItems[0].Season.Ids.Tvdb.Should().Be(171641);
            watchlistItems[0].Season.Ids.Tmdb.Should().Be(3575);
            watchlistItems[0].Season.Ids.TvRage.Should().NotHaveValue();
            watchlistItems[0].Episode.Should().BeNull();

            watchlistItems[1].ListedAt.Should().Be(DateTime.Parse("2014-09-02T09:10:11.000Z").ToUniversalTime());
            watchlistItems[1].Type.Should().Be(TraktSyncItemType.Season);
            watchlistItems[1].Movie.Should().BeNull();
            watchlistItems[1].Show.Should().NotBeNull();
            watchlistItems[1].Show.Title.Should().Be("Breaking Bad");
            watchlistItems[1].Show.Year.Should().Be(2008);
            watchlistItems[1].Show.Ids.Should().NotBeNull();
            watchlistItems[1].Show.Ids.Trakt.Should().Be(1);
            watchlistItems[1].Show.Ids.Slug.Should().Be("breaking-bad");
            watchlistItems[1].Show.Ids.Tvdb.Should().Be(81189);
            watchlistItems[1].Show.Ids.Imdb.Should().Be("tt0903747");
            watchlistItems[1].Show.Ids.Tmdb.Should().Be(1396);
            watchlistItems[1].Show.Ids.TvRage.Should().Be(18164);
            watchlistItems[1].Season.Should().NotBeNull();
            watchlistItems[1].Season.Number.Should().Be(1);
            watchlistItems[1].Season.Ids.Should().NotBeNull();
            watchlistItems[1].Season.Ids.Trakt.Should().Be(0);
            watchlistItems[1].Season.Ids.Tvdb.Should().Be(30272);
            watchlistItems[1].Season.Ids.Tmdb.Should().Be(3572);
            watchlistItems[1].Season.Ids.TvRage.Should().NotHaveValue();
            watchlistItems[1].Episode.Should().BeNull();
        }

        [TestMethod]
        public void TestTraktSyncWatchlistItemReadFromJsonEpisodes()
        {
            var jsonFile = TestUtility.ReadFileContents(@"Objects\Get\Users\Watchlist\UserWatchlistEpisodes.json");

            jsonFile.Should().NotBeNullOrEmpty();

            var userWatchlistItems = JsonConvert.DeserializeObject<IEnumerable<TraktUserWatchlistItem>>(jsonFile);

            userWatchlistItems.Should().NotBeNull();
            userWatchlistItems.Should().HaveCount(2);

            var watchlistItems = userWatchlistItems.ToArray();

            watchlistItems[0].ListedAt.Should().Be(DateTime.Parse("2014-09-01T09:10:11.000Z").ToUniversalTime());
            watchlistItems[0].Type.Should().Be(TraktSyncItemType.Episode);
            watchlistItems[0].Movie.Should().BeNull();
            watchlistItems[0].Show.Should().NotBeNull();
            watchlistItems[0].Show.Title.Should().Be("Breaking Bad");
            watchlistItems[0].Show.Year.Should().Be(2008);
            watchlistItems[0].Show.Ids.Should().NotBeNull();
            watchlistItems[0].Show.Ids.Trakt.Should().Be(1);
            watchlistItems[0].Show.Ids.Slug.Should().Be("breaking-bad");
            watchlistItems[0].Show.Ids.Tvdb.Should().Be(81189);
            watchlistItems[0].Show.Ids.Imdb.Should().Be("tt0903747");
            watchlistItems[0].Show.Ids.Tmdb.Should().Be(1396);
            watchlistItems[0].Show.Ids.TvRage.Should().Be(18164);
            watchlistItems[0].Season.Should().BeNull();
            watchlistItems[0].Episode.Should().NotBeNull();
            watchlistItems[0].Episode.SeasonNumber.Should().Be(4);
            watchlistItems[0].Episode.Number.Should().Be(1);
            watchlistItems[0].Episode.Title.Should().Be("Box Cutter");
            watchlistItems[0].Episode.Ids.Should().NotBeNull();
            watchlistItems[0].Episode.Ids.Trakt.Should().Be(49);
            watchlistItems[0].Episode.Ids.Slug.Should().BeNull();
            watchlistItems[0].Episode.Ids.Tvdb.Should().Be(2639411);
            watchlistItems[0].Episode.Ids.Imdb.Should().Be("tt1683084");
            watchlistItems[0].Episode.Ids.Tmdb.Should().Be(62118);
            watchlistItems[0].Episode.Ids.TvRage.Should().NotHaveValue();

            watchlistItems[1].ListedAt.Should().Be(DateTime.Parse("2014-09-02T09:10:11.000Z").ToUniversalTime());
            watchlistItems[1].Type.Should().Be(TraktSyncItemType.Episode);
            watchlistItems[1].Movie.Should().BeNull();
            watchlistItems[1].Show.Should().NotBeNull();
            watchlistItems[1].Show.Title.Should().Be("Breaking Bad");
            watchlistItems[1].Show.Year.Should().Be(2008);
            watchlistItems[1].Show.Ids.Should().NotBeNull();
            watchlistItems[1].Show.Ids.Trakt.Should().Be(1);
            watchlistItems[1].Show.Ids.Slug.Should().Be("breaking-bad");
            watchlistItems[1].Show.Ids.Tvdb.Should().Be(81189);
            watchlistItems[1].Show.Ids.Imdb.Should().Be("tt0903747");
            watchlistItems[1].Show.Ids.Tmdb.Should().Be(1396);
            watchlistItems[1].Show.Ids.TvRage.Should().Be(18164);
            watchlistItems[1].Season.Should().BeNull();
            watchlistItems[1].Episode.Should().NotBeNull();
            watchlistItems[1].Episode.SeasonNumber.Should().Be(4);
            watchlistItems[1].Episode.Number.Should().Be(8);
            watchlistItems[1].Episode.Title.Should().Be("Hermanos");
            watchlistItems[1].Episode.Ids.Should().NotBeNull();
            watchlistItems[1].Episode.Ids.Trakt.Should().Be(56);
            watchlistItems[1].Episode.Ids.Slug.Should().BeNull();
            watchlistItems[1].Episode.Ids.Tvdb.Should().Be(4127161);
            watchlistItems[1].Episode.Ids.Imdb.Should().Be("tt1683095");
            watchlistItems[1].Episode.Ids.Tmdb.Should().Be(62127);
            watchlistItems[1].Episode.Ids.TvRage.Should().NotHaveValue();
        }
    }
}
