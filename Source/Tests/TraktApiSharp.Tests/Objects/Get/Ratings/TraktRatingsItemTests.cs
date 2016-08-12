namespace TraktApiSharp.Tests.Objects.Get.Syncs.Ratings
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using TraktApiSharp.Enums;
    using TraktApiSharp.Objects.Get.Ratings;
    using Utils;

    [TestClass]
    public class TraktSyncRatingsItemTests
    {
        [TestMethod]
        public void TestTraktSyncRatingsItemDefaultConstructor()
        {
            var ratingsItem = new TraktRatingsItem();

            ratingsItem.RatedAt.Should().NotHaveValue();
            ratingsItem.Rating.Should().NotHaveValue();
            ratingsItem.Type.Should().BeNull();
            ratingsItem.Movie.Should().BeNull();
            ratingsItem.Show.Should().BeNull();
            ratingsItem.Season.Should().BeNull();
            ratingsItem.Episode.Should().BeNull();
        }

        [TestMethod]
        public void TestTraktSyncRatingsItemReadFromJsonMovies()
        {
            var jsonFile = TestUtility.ReadFileContents(@"Objects\Get\Ratings\RatingsMovies.json");

            jsonFile.Should().NotBeNullOrEmpty();

            var ratingsItems = JsonConvert.DeserializeObject<IEnumerable<TraktRatingsItem>>(jsonFile);

            ratingsItems.Should().NotBeNull();
            ratingsItems.Should().HaveCount(2);

            var ratings = ratingsItems.ToArray();

            ratings[0].RatedAt.Should().Be(DateTime.Parse("2014-09-01T09:10:11.000Z").ToUniversalTime());
            ratings[0].Rating.Should().Be(10);
            ratings[0].Type.Should().Be(TraktSyncRatingsItemType.Movie);
            ratings[0].Movie.Should().NotBeNull();
            ratings[0].Movie.Title.Should().Be("TRON: Legacy");
            ratings[0].Movie.Year.Should().Be(2010);
            ratings[0].Movie.Ids.Should().NotBeNull();
            ratings[0].Movie.Ids.Trakt.Should().Be(1);
            ratings[0].Movie.Ids.Slug.Should().Be("tron-legacy-2010");
            ratings[0].Movie.Ids.Imdb.Should().Be("tt1104001");
            ratings[0].Movie.Ids.Tmdb.Should().Be(20526);
            ratings[0].Show.Should().BeNull();
            ratings[0].Season.Should().BeNull();
            ratings[0].Episode.Should().BeNull();

            ratings[1].RatedAt.Should().Be(DateTime.Parse("2014-09-02T09:10:11.000Z").ToUniversalTime());
            ratings[1].Rating.Should().Be(8);
            ratings[1].Type.Should().Be(TraktSyncRatingsItemType.Movie);
            ratings[1].Movie.Should().NotBeNull();
            ratings[1].Movie.Title.Should().Be("The Dark Knight");
            ratings[1].Movie.Year.Should().Be(2008);
            ratings[1].Movie.Ids.Should().NotBeNull();
            ratings[1].Movie.Ids.Trakt.Should().Be(6);
            ratings[1].Movie.Ids.Slug.Should().Be("the-dark-knight-2008");
            ratings[1].Movie.Ids.Imdb.Should().Be("tt0468569");
            ratings[1].Movie.Ids.Tmdb.Should().Be(155);
            ratings[1].Show.Should().BeNull();
            ratings[1].Season.Should().BeNull();
            ratings[1].Episode.Should().BeNull();
        }

        [TestMethod]
        public void TestTraktSyncRatingsItemReadFromJsonShows()
        {
            var jsonFile = TestUtility.ReadFileContents(@"Objects\Get\Ratings\RatingsShows.json");

            jsonFile.Should().NotBeNullOrEmpty();

            var ratingsItems = JsonConvert.DeserializeObject<IEnumerable<TraktRatingsItem>>(jsonFile);

            ratingsItems.Should().NotBeNull();
            ratingsItems.Should().HaveCount(2);

            var ratings = ratingsItems.ToArray();

            ratings[0].RatedAt.Should().Be(DateTime.Parse("2014-09-01T09:10:11.000Z").ToUniversalTime());
            ratings[0].Rating.Should().Be(10);
            ratings[0].Type.Should().Be(TraktSyncRatingsItemType.Show);
            ratings[0].Movie.Should().BeNull();
            ratings[0].Show.Should().NotBeNull();
            ratings[0].Show.Title.Should().Be("Breaking Bad");
            ratings[0].Show.Year.Should().Be(2008);
            ratings[0].Show.Ids.Should().NotBeNull();
            ratings[0].Show.Ids.Trakt.Should().Be(1);
            ratings[0].Show.Ids.Slug.Should().Be("breaking-bad");
            ratings[0].Show.Ids.Tvdb.Should().Be(81189);
            ratings[0].Show.Ids.Imdb.Should().Be("tt0903747");
            ratings[0].Show.Ids.Tmdb.Should().Be(1396);
            ratings[0].Show.Ids.TvRage.Should().Be(18164);
            ratings[0].Season.Should().BeNull();
            ratings[0].Episode.Should().BeNull();

            ratings[1].RatedAt.Should().Be(DateTime.Parse("2014-09-03T09:10:11.000Z").ToUniversalTime());
            ratings[1].Rating.Should().Be(9);
            ratings[1].Type.Should().Be(TraktSyncRatingsItemType.Show);
            ratings[1].Movie.Should().BeNull();
            ratings[1].Show.Should().NotBeNull();
            ratings[1].Show.Title.Should().Be("The Walking Dead");
            ratings[1].Show.Year.Should().Be(2010);
            ratings[1].Show.Ids.Should().NotBeNull();
            ratings[1].Show.Ids.Trakt.Should().Be(2);
            ratings[1].Show.Ids.Slug.Should().Be("the-walking-dead");
            ratings[1].Show.Ids.Tvdb.Should().Be(153021);
            ratings[1].Show.Ids.Imdb.Should().Be("tt1520211");
            ratings[1].Show.Ids.Tmdb.Should().Be(1402);
            ratings[1].Show.Ids.TvRage.Should().NotHaveValue();
            ratings[1].Season.Should().BeNull();
            ratings[1].Episode.Should().BeNull();
        }

        [TestMethod]
        public void TestTraktSyncRatingsItemReadFromJsonSeasons()
        {
            var jsonFile = TestUtility.ReadFileContents(@"Objects\Get\Ratings\RatingsSeasons.json");

            jsonFile.Should().NotBeNullOrEmpty();

            var ratingsItems = JsonConvert.DeserializeObject<IEnumerable<TraktRatingsItem>>(jsonFile);

            ratingsItems.Should().NotBeNull();
            ratingsItems.Should().HaveCount(2);

            var ratings = ratingsItems.ToArray();

            ratings[0].RatedAt.Should().Be(DateTime.Parse("2014-09-01T09:10:11.000Z").ToUniversalTime());
            ratings[0].Rating.Should().Be(8);
            ratings[0].Type.Should().Be(TraktSyncRatingsItemType.Season);
            ratings[0].Movie.Should().BeNull();
            ratings[0].Show.Should().NotBeNull();
            ratings[0].Show.Title.Should().Be("Breaking Bad");
            ratings[0].Show.Year.Should().Be(2008);
            ratings[0].Show.Ids.Should().NotBeNull();
            ratings[0].Show.Ids.Trakt.Should().Be(1);
            ratings[0].Show.Ids.Slug.Should().Be("breaking-bad");
            ratings[0].Show.Ids.Tvdb.Should().Be(81189);
            ratings[0].Show.Ids.Imdb.Should().Be("tt0903747");
            ratings[0].Show.Ids.Tmdb.Should().Be(1396);
            ratings[0].Show.Ids.TvRage.Should().Be(18164);
            ratings[0].Season.Should().NotBeNull();
            ratings[0].Season.Number.Should().Be(0);
            ratings[0].Season.Ids.Should().NotBeNull();
            ratings[0].Season.Ids.Trakt.Should().Be(0);
            ratings[0].Season.Ids.Tvdb.Should().Be(439371);
            ratings[0].Season.Ids.Tmdb.Should().Be(3577);
            ratings[0].Season.Ids.TvRage.Should().NotHaveValue();
            ratings[0].Episode.Should().BeNull();

            ratings[1].RatedAt.Should().Be(DateTime.Parse("2014-09-04T09:10:11.000Z").ToUniversalTime());
            ratings[1].Rating.Should().Be(9);
            ratings[1].Type.Should().Be(TraktSyncRatingsItemType.Season);
            ratings[1].Movie.Should().BeNull();
            ratings[1].Show.Should().NotBeNull();
            ratings[1].Show.Title.Should().Be("Breaking Bad");
            ratings[1].Show.Year.Should().Be(2008);
            ratings[1].Show.Ids.Should().NotBeNull();
            ratings[1].Show.Ids.Trakt.Should().Be(1);
            ratings[1].Show.Ids.Slug.Should().Be("breaking-bad");
            ratings[1].Show.Ids.Tvdb.Should().Be(81189);
            ratings[1].Show.Ids.Imdb.Should().Be("tt0903747");
            ratings[1].Show.Ids.Tmdb.Should().Be(1396);
            ratings[1].Show.Ids.TvRage.Should().Be(18164);
            ratings[1].Season.Should().NotBeNull();
            ratings[1].Season.Number.Should().Be(1);
            ratings[1].Season.Ids.Should().NotBeNull();
            ratings[1].Season.Ids.Trakt.Should().Be(0);
            ratings[1].Season.Ids.Tvdb.Should().Be(30272);
            ratings[1].Season.Ids.Tmdb.Should().Be(3572);
            ratings[1].Season.Ids.TvRage.Should().NotHaveValue();
            ratings[1].Episode.Should().BeNull();
        }

        [TestMethod]
        public void TestTraktSyncRatingsItemReadFromJsonEpisodes()
        {
            var jsonFile = TestUtility.ReadFileContents(@"Objects\Get\Ratings\RatingsEpisodes.json");

            jsonFile.Should().NotBeNullOrEmpty();

            var ratingsItems = JsonConvert.DeserializeObject<IEnumerable<TraktRatingsItem>>(jsonFile);

            ratingsItems.Should().NotBeNull();
            ratingsItems.Should().HaveCount(2);

            var ratings = ratingsItems.ToArray();

            ratings[0].RatedAt.Should().Be(DateTime.Parse("2014-09-01T09:10:11.000Z").ToUniversalTime());
            ratings[0].Rating.Should().Be(5);
            ratings[0].Type.Should().Be(TraktSyncRatingsItemType.Episode);
            ratings[0].Movie.Should().BeNull();
            ratings[0].Show.Should().NotBeNull();
            ratings[0].Show.Title.Should().Be("Breaking Bad");
            ratings[0].Show.Year.Should().Be(2008);
            ratings[0].Show.Ids.Should().NotBeNull();
            ratings[0].Show.Ids.Trakt.Should().Be(1);
            ratings[0].Show.Ids.Slug.Should().Be("breaking-bad");
            ratings[0].Show.Ids.Tvdb.Should().Be(81189);
            ratings[0].Show.Ids.Imdb.Should().Be("tt0903747");
            ratings[0].Show.Ids.Tmdb.Should().Be(1396);
            ratings[0].Show.Ids.TvRage.Should().Be(18164);
            ratings[0].Season.Should().BeNull();
            ratings[0].Episode.Should().NotBeNull();
            ratings[0].Episode.SeasonNumber.Should().Be(4);
            ratings[0].Episode.Number.Should().Be(1);
            ratings[0].Episode.Title.Should().Be("Box Cutter");
            ratings[0].Episode.Ids.Should().NotBeNull();
            ratings[0].Episode.Ids.Trakt.Should().Be(49);
            ratings[0].Episode.Ids.Tvdb.Should().Be(2639411);
            ratings[0].Episode.Ids.Imdb.Should().Be("tt1683084");
            ratings[0].Episode.Ids.Tmdb.Should().Be(62118);
            ratings[0].Episode.Ids.TvRage.Should().NotHaveValue();

            ratings[1].RatedAt.Should().Be(DateTime.Parse("2014-09-06T09:10:11.000Z").ToUniversalTime());
            ratings[1].Rating.Should().Be(9);
            ratings[1].Type.Should().Be(TraktSyncRatingsItemType.Episode);
            ratings[1].Movie.Should().BeNull();
            ratings[1].Show.Should().NotBeNull();
            ratings[1].Show.Title.Should().Be("Breaking Bad");
            ratings[1].Show.Year.Should().Be(2008);
            ratings[1].Show.Ids.Should().NotBeNull();
            ratings[1].Show.Ids.Trakt.Should().Be(1);
            ratings[1].Show.Ids.Slug.Should().Be("breaking-bad");
            ratings[1].Show.Ids.Tvdb.Should().Be(81189);
            ratings[1].Show.Ids.Imdb.Should().Be("tt0903747");
            ratings[1].Show.Ids.Tmdb.Should().Be(1396);
            ratings[1].Show.Ids.TvRage.Should().Be(18164);
            ratings[1].Season.Should().BeNull();
            ratings[1].Episode.Should().NotBeNull();
            ratings[1].Episode.SeasonNumber.Should().Be(4);
            ratings[1].Episode.Number.Should().Be(8);
            ratings[1].Episode.Title.Should().Be("Hermanos");
            ratings[1].Episode.Ids.Should().NotBeNull();
            ratings[1].Episode.Ids.Trakt.Should().Be(56);
            ratings[1].Episode.Ids.Tvdb.Should().Be(4127161);
            ratings[1].Episode.Ids.Imdb.Should().Be("tt1683095");
            ratings[1].Episode.Ids.Tmdb.Should().Be(62127);
            ratings[1].Episode.Ids.TvRage.Should().NotHaveValue();
        }
    }
}
