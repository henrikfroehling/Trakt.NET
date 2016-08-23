namespace TraktApiSharp.Tests.Objects.Get.Syncs.Watchlist
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using TraktApiSharp.Enums;
    using TraktApiSharp.Objects.Get.Watchlist;
    using Utils;

    [TestClass]
    public class TraktWatchlistItemTests
    {
        [TestMethod]
        public void TestTraktWatchlistItemDefaultConstructor()
        {
            var watchlistItem = new TraktWatchlistItem();

            watchlistItem.ListedAt.Should().NotHaveValue();
            watchlistItem.Type.Should().BeNull();
            watchlistItem.Movie.Should().BeNull();
            watchlistItem.Show.Should().BeNull();
            watchlistItem.Season.Should().BeNull();
            watchlistItem.Episode.Should().BeNull();
        }

        [TestMethod]
        public void TestTraktWatchlistItemReadFromJsonMovies()
        {
            var jsonFile = TestUtility.ReadFileContents(@"Objects\Get\Watchlist\WatchlistMovies.json");

            jsonFile.Should().NotBeNullOrEmpty();

            var movieItems = JsonConvert.DeserializeObject<IEnumerable<TraktWatchlistItem>>(jsonFile);

            movieItems.Should().NotBeNull();
            movieItems.Should().HaveCount(2);

            var movies = movieItems.ToArray();

            movies[0].ListedAt.Should().Be(DateTime.Parse("2014-09-01T09:10:11.000Z").ToUniversalTime());
            movies[0].Type.Should().Be(TraktSyncItemType.Movie);
            movies[0].Movie.Should().NotBeNull();
            movies[0].Movie.Title.Should().Be("TRON: Legacy");
            movies[0].Movie.Year.Should().Be(2010);
            movies[0].Movie.Ids.Should().NotBeNull();
            movies[0].Movie.Ids.Trakt.Should().Be(1U);
            movies[0].Movie.Ids.Slug.Should().Be("tron-legacy-2010");
            movies[0].Movie.Ids.Imdb.Should().Be("tt1104001");
            movies[0].Movie.Ids.Tmdb.Should().Be(20526U);
            movies[0].Show.Should().BeNull();
            movies[0].Season.Should().BeNull();
            movies[0].Episode.Should().BeNull();

            movies[1].ListedAt.Should().Be(DateTime.Parse("2014-09-02T09:10:11.000Z").ToUniversalTime());
            movies[1].Type.Should().Be(TraktSyncItemType.Movie);
            movies[1].Movie.Should().NotBeNull();
            movies[1].Movie.Title.Should().Be("The Dark Knight");
            movies[1].Movie.Year.Should().Be(2008);
            movies[1].Movie.Ids.Should().NotBeNull();
            movies[1].Movie.Ids.Trakt.Should().Be(6U);
            movies[1].Movie.Ids.Slug.Should().Be("the-dark-knight-2008");
            movies[1].Movie.Ids.Imdb.Should().Be("tt0468569");
            movies[1].Movie.Ids.Tmdb.Should().Be(155U);
            movies[1].Show.Should().BeNull();
            movies[1].Season.Should().BeNull();
            movies[1].Episode.Should().BeNull();
        }

        [TestMethod]
        public void TestTraktWatchlistItemReadFromJsonShows()
        {
            var jsonFile = TestUtility.ReadFileContents(@"Objects\Get\Watchlist\WatchlistShows.json");

            jsonFile.Should().NotBeNullOrEmpty();

            var showItems = JsonConvert.DeserializeObject<IEnumerable<TraktWatchlistItem>>(jsonFile);

            showItems.Should().NotBeNull();
            showItems.Should().HaveCount(2);

            var shows = showItems.ToArray();

            shows[0].ListedAt.Should().Be(DateTime.Parse("2014-09-01T09:10:11.000Z").ToUniversalTime());
            shows[0].Type.Should().Be(TraktSyncItemType.Show);
            shows[0].Movie.Should().BeNull();
            shows[0].Show.Should().NotBeNull();
            shows[0].Show.Title.Should().Be("Breaking Bad");
            shows[0].Show.Year.Should().Be(2008);
            shows[0].Show.Ids.Should().NotBeNull();
            shows[0].Show.Ids.Trakt.Should().Be(1U);
            shows[0].Show.Ids.Slug.Should().Be("breaking-bad");
            shows[0].Show.Ids.Tvdb.Should().Be(81189U);
            shows[0].Show.Ids.Imdb.Should().Be("tt0903747");
            shows[0].Show.Ids.Tmdb.Should().Be(1396U);
            shows[0].Show.Ids.TvRage.Should().Be(18164U);
            shows[0].Season.Should().BeNull();
            shows[0].Episode.Should().BeNull();

            shows[1].ListedAt.Should().Be(DateTime.Parse("2014-09-02T09:10:11.000Z").ToUniversalTime());
            shows[1].Type.Should().Be(TraktSyncItemType.Show);
            shows[1].Movie.Should().BeNull();
            shows[1].Show.Should().NotBeNull();
            shows[1].Show.Title.Should().Be("The Walking Dead");
            shows[1].Show.Year.Should().Be(2010);
            shows[1].Show.Ids.Should().NotBeNull();
            shows[1].Show.Ids.Trakt.Should().Be(2U);
            shows[1].Show.Ids.Slug.Should().Be("the-walking-dead");
            shows[1].Show.Ids.Tvdb.Should().Be(153021U);
            shows[1].Show.Ids.Imdb.Should().Be("tt1520211");
            shows[1].Show.Ids.Tmdb.Should().Be(1402U);
            shows[1].Show.Ids.TvRage.Should().BeNull();
            shows[1].Season.Should().BeNull();
            shows[1].Episode.Should().BeNull();
        }

        [TestMethod]
        public void TestTraktWatchlistItemReadFromJsonSeasons()
        {
            var jsonFile = TestUtility.ReadFileContents(@"Objects\Get\Watchlist\WatchlistSeasons.json");

            jsonFile.Should().NotBeNullOrEmpty();

            var seasonItems = JsonConvert.DeserializeObject<IEnumerable<TraktWatchlistItem>>(jsonFile);

            seasonItems.Should().NotBeNull();
            seasonItems.Should().HaveCount(2);

            var seasons = seasonItems.ToArray();

            seasons[0].ListedAt.Should().Be(DateTime.Parse("2014-09-01T09:10:11.000Z").ToUniversalTime());
            seasons[0].Type.Should().Be(TraktSyncItemType.Season);
            seasons[0].Movie.Should().BeNull();
            seasons[0].Show.Should().NotBeNull();
            seasons[0].Show.Title.Should().Be("Breaking Bad");
            seasons[0].Show.Year.Should().Be(2008);
            seasons[0].Show.Ids.Should().NotBeNull();
            seasons[0].Show.Ids.Trakt.Should().Be(1U);
            seasons[0].Show.Ids.Slug.Should().Be("breaking-bad");
            seasons[0].Show.Ids.Tvdb.Should().Be(81189U);
            seasons[0].Show.Ids.Imdb.Should().Be("tt0903747");
            seasons[0].Show.Ids.Tmdb.Should().Be(1396U);
            seasons[0].Show.Ids.TvRage.Should().Be(18164U);
            seasons[0].Season.Should().NotBeNull();
            seasons[0].Season.Number.Should().Be(3);
            seasons[0].Season.Ids.Should().NotBeNull();
            seasons[0].Season.Ids.Trakt.Should().Be(0U);
            seasons[0].Season.Ids.Tvdb.Should().Be(171641U);
            seasons[0].Season.Ids.Tmdb.Should().Be(3575U);
            seasons[0].Season.Ids.TvRage.Should().BeNull();
            seasons[0].Episode.Should().BeNull();

            seasons[1].ListedAt.Should().Be(DateTime.Parse("2014-09-02T09:10:11.000Z").ToUniversalTime());
            seasons[1].Type.Should().Be(TraktSyncItemType.Season);
            seasons[1].Movie.Should().BeNull();
            seasons[1].Show.Should().NotBeNull();
            seasons[1].Show.Title.Should().Be("Breaking Bad");
            seasons[1].Show.Year.Should().Be(2008);
            seasons[1].Show.Ids.Should().NotBeNull();
            seasons[1].Show.Ids.Trakt.Should().Be(1U);
            seasons[1].Show.Ids.Slug.Should().Be("breaking-bad");
            seasons[1].Show.Ids.Tvdb.Should().Be(81189U);
            seasons[1].Show.Ids.Imdb.Should().Be("tt0903747");
            seasons[1].Show.Ids.Tmdb.Should().Be(1396U);
            seasons[1].Show.Ids.TvRage.Should().Be(18164U);
            seasons[1].Season.Should().NotBeNull();
            seasons[1].Season.Number.Should().Be(1);
            seasons[1].Season.Ids.Should().NotBeNull();
            seasons[1].Season.Ids.Trakt.Should().Be(0U);
            seasons[1].Season.Ids.Tvdb.Should().Be(30272U);
            seasons[1].Season.Ids.Tmdb.Should().Be(3572U);
            seasons[1].Season.Ids.TvRage.Should().BeNull();
            seasons[1].Episode.Should().BeNull();
        }

        [TestMethod]
        public void TestTraktWatchlistItemReadFromJsonEpisodes()
        {
            var jsonFile = TestUtility.ReadFileContents(@"Objects\Get\Watchlist\WatchlistEpisodes.json");

            jsonFile.Should().NotBeNullOrEmpty();

            var episodeItems = JsonConvert.DeserializeObject<IEnumerable<TraktWatchlistItem>>(jsonFile);

            episodeItems.Should().NotBeNull();
            episodeItems.Should().HaveCount(2);

            var episodes = episodeItems.ToArray();

            episodes[0].ListedAt.Should().Be(DateTime.Parse("2014-09-01T09:10:11.000Z").ToUniversalTime());
            episodes[0].Type.Should().Be(TraktSyncItemType.Episode);
            episodes[0].Movie.Should().BeNull();
            episodes[0].Show.Should().NotBeNull();
            episodes[0].Show.Title.Should().Be("Breaking Bad");
            episodes[0].Show.Year.Should().Be(2008);
            episodes[0].Show.Ids.Should().NotBeNull();
            episodes[0].Show.Ids.Trakt.Should().Be(1U);
            episodes[0].Show.Ids.Slug.Should().Be("breaking-bad");
            episodes[0].Show.Ids.Tvdb.Should().Be(81189U);
            episodes[0].Show.Ids.Imdb.Should().Be("tt0903747");
            episodes[0].Show.Ids.Tmdb.Should().Be(1396U);
            episodes[0].Show.Ids.TvRage.Should().Be(18164U);
            episodes[0].Season.Should().BeNull();
            episodes[0].Episode.Should().NotBeNull();
            episodes[0].Episode.SeasonNumber.Should().Be(4);
            episodes[0].Episode.Number.Should().Be(1);
            episodes[0].Episode.Title.Should().Be("Box Cutter");
            episodes[0].Episode.Ids.Should().NotBeNull();
            episodes[0].Episode.Ids.Trakt.Should().Be(49U);
            episodes[0].Episode.Ids.Tvdb.Should().Be(2639411U);
            episodes[0].Episode.Ids.Imdb.Should().Be("tt1683084");
            episodes[0].Episode.Ids.Tmdb.Should().Be(62118U);
            episodes[0].Episode.Ids.TvRage.Should().BeNull();

            episodes[1].ListedAt.Should().Be(DateTime.Parse("2014-09-02T09:10:11.000Z").ToUniversalTime());
            episodes[1].Type.Should().Be(TraktSyncItemType.Episode);
            episodes[1].Movie.Should().BeNull();
            episodes[1].Show.Should().NotBeNull();
            episodes[1].Show.Title.Should().Be("Breaking Bad");
            episodes[1].Show.Year.Should().Be(2008);
            episodes[1].Show.Ids.Should().NotBeNull();
            episodes[1].Show.Ids.Trakt.Should().Be(1U);
            episodes[1].Show.Ids.Slug.Should().Be("breaking-bad");
            episodes[1].Show.Ids.Tvdb.Should().Be(81189U);
            episodes[1].Show.Ids.Imdb.Should().Be("tt0903747");
            episodes[1].Show.Ids.Tmdb.Should().Be(1396U);
            episodes[1].Show.Ids.TvRage.Should().Be(18164U);
            episodes[1].Season.Should().BeNull();
            episodes[1].Episode.Should().NotBeNull();
            episodes[1].Episode.SeasonNumber.Should().Be(4);
            episodes[1].Episode.Number.Should().Be(8);
            episodes[1].Episode.Title.Should().Be("Hermanos");
            episodes[1].Episode.Ids.Should().NotBeNull();
            episodes[1].Episode.Ids.Trakt.Should().Be(56U);
            episodes[1].Episode.Ids.Tvdb.Should().Be(4127161U);
            episodes[1].Episode.Ids.Imdb.Should().Be("tt1683095");
            episodes[1].Episode.Ids.Tmdb.Should().Be(62127U);
            episodes[1].Episode.Ids.TvRage.Should().BeNull();
        }
    }
}
