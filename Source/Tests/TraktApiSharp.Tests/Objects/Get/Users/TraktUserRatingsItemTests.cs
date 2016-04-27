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
    public class TraktUserRatingsItemTests
    {
        [TestMethod]
        public void TestTraktUserRatingsItemDefaultConstructor()
        {
            var userRatingsItem = new TraktUserRatingsItem();

            userRatingsItem.RatedAt.Should().Be(DateTime.MinValue);
            userRatingsItem.Rating.Should().Be(0);
            userRatingsItem.Type.Should().Be(TraktSyncRatingsItemType.Unspecified);
            userRatingsItem.Movie.Should().BeNull();
            userRatingsItem.Show.Should().BeNull();
            userRatingsItem.Season.Should().BeNull();
            userRatingsItem.Episode.Should().BeNull();
        }

        [TestMethod]
        public void TestTraktUserRatingsItemReadFromJsonMovies()
        {
            var jsonFile = TestUtility.ReadFileContents(@"Objects\Get\Users\Ratings\UserRatingsMovies.json");

            jsonFile.Should().NotBeNullOrEmpty();

            var userRatingsItem = JsonConvert.DeserializeObject<IEnumerable<TraktUserRatingsItem>>(jsonFile);

            userRatingsItem.Should().NotBeNull();
            userRatingsItem.Should().HaveCount(2);

            var userRatings = userRatingsItem.ToArray();

            userRatings[0].RatedAt.Should().Be(DateTime.Parse("2014-09-01T09:10:11.000Z").ToUniversalTime());
            userRatings[0].Rating.Should().Be(10);
            userRatings[0].Type.Should().Be(TraktSyncRatingsItemType.Movie);
            userRatings[0].Movie.Should().NotBeNull();
            userRatings[0].Movie.Title.Should().Be("TRON: Legacy");
            userRatings[0].Movie.Year.Should().Be(2010);
            userRatings[0].Movie.Ids.Should().NotBeNull();
            userRatings[0].Movie.Ids.Trakt.Should().Be(1);
            userRatings[0].Movie.Ids.Slug.Should().Be("tron-legacy-2010");
            userRatings[0].Movie.Ids.Imdb.Should().Be("tt1104001");
            userRatings[0].Movie.Ids.Tmdb.Should().Be(20526);
            userRatings[0].Show.Should().BeNull();
            userRatings[0].Season.Should().BeNull();
            userRatings[0].Episode.Should().BeNull();

            userRatings[1].RatedAt.Should().Be(DateTime.Parse("2014-09-02T09:10:11.000Z").ToUniversalTime());
            userRatings[1].Rating.Should().Be(8);
            userRatings[1].Type.Should().Be(TraktSyncRatingsItemType.Movie);
            userRatings[1].Movie.Should().NotBeNull();
            userRatings[1].Movie.Title.Should().Be("The Dark Knight");
            userRatings[1].Movie.Year.Should().Be(2008);
            userRatings[1].Movie.Ids.Should().NotBeNull();
            userRatings[1].Movie.Ids.Trakt.Should().Be(6);
            userRatings[1].Movie.Ids.Slug.Should().Be("the-dark-knight-2008");
            userRatings[1].Movie.Ids.Imdb.Should().Be("tt0468569");
            userRatings[1].Movie.Ids.Tmdb.Should().Be(155);
            userRatings[1].Show.Should().BeNull();
            userRatings[1].Season.Should().BeNull();
            userRatings[1].Episode.Should().BeNull();
        }

        [TestMethod]
        public void TestTraktUserRatingsItemReadFromJsonShows()
        {
            var jsonFile = TestUtility.ReadFileContents(@"Objects\Get\Users\Ratings\UserRatingsShows.json");

            jsonFile.Should().NotBeNullOrEmpty();

            var userRatingsItem = JsonConvert.DeserializeObject<IEnumerable<TraktUserRatingsItem>>(jsonFile);

            userRatingsItem.Should().NotBeNull();
            userRatingsItem.Should().HaveCount(2);

            var userRatings = userRatingsItem.ToArray();

            userRatings[0].RatedAt.Should().Be(DateTime.Parse("2014-09-01T09:10:11.000Z").ToUniversalTime());
            userRatings[0].Rating.Should().Be(10);
            userRatings[0].Type.Should().Be(TraktSyncRatingsItemType.Show);
            userRatings[0].Movie.Should().BeNull();
            userRatings[0].Show.Should().NotBeNull();
            userRatings[0].Show.Title.Should().Be("Breaking Bad");
            userRatings[0].Show.Year.Should().Be(2008);
            userRatings[0].Show.Ids.Should().NotBeNull();
            userRatings[0].Show.Ids.Trakt.Should().Be(1);
            userRatings[0].Show.Ids.Slug.Should().Be("breaking-bad");
            userRatings[0].Show.Ids.Tvdb.Should().Be(81189);
            userRatings[0].Show.Ids.Imdb.Should().Be("tt0903747");
            userRatings[0].Show.Ids.Tmdb.Should().Be(1396);
            userRatings[0].Show.Ids.TvRage.Should().Be(18164);
            userRatings[0].Season.Should().BeNull();
            userRatings[0].Episode.Should().BeNull();

            userRatings[1].RatedAt.Should().Be(DateTime.Parse("2014-09-03T09:10:11.000Z").ToUniversalTime());
            userRatings[1].Rating.Should().Be(9);
            userRatings[1].Type.Should().Be(TraktSyncRatingsItemType.Show);
            userRatings[1].Movie.Should().BeNull();
            userRatings[1].Show.Should().NotBeNull();
            userRatings[1].Show.Title.Should().Be("The Walking Dead");
            userRatings[1].Show.Year.Should().Be(2010);
            userRatings[1].Show.Ids.Should().NotBeNull();
            userRatings[1].Show.Ids.Trakt.Should().Be(2);
            userRatings[1].Show.Ids.Slug.Should().Be("the-walking-dead");
            userRatings[1].Show.Ids.Tvdb.Should().Be(153021);
            userRatings[1].Show.Ids.Imdb.Should().Be("tt1520211");
            userRatings[1].Show.Ids.Tmdb.Should().Be(1402);
            userRatings[1].Show.Ids.TvRage.Should().NotHaveValue();
            userRatings[1].Season.Should().BeNull();
            userRatings[1].Episode.Should().BeNull();
        }

        [TestMethod]
        public void TestTraktUserRatingsItemReadFromJsonSeasons()
        {
            var jsonFile = TestUtility.ReadFileContents(@"Objects\Get\Users\Ratings\UserRatingsSeasons.json");

            jsonFile.Should().NotBeNullOrEmpty();

            var userRatingsItem = JsonConvert.DeserializeObject<IEnumerable<TraktUserRatingsItem>>(jsonFile);

            userRatingsItem.Should().NotBeNull();
            userRatingsItem.Should().HaveCount(2);

            var userRatings = userRatingsItem.ToArray();

            userRatings[0].RatedAt.Should().Be(DateTime.Parse("2014-09-01T09:10:11.000Z").ToUniversalTime());
            userRatings[0].Rating.Should().Be(8);
            userRatings[0].Type.Should().Be(TraktSyncRatingsItemType.Season);
            userRatings[0].Movie.Should().BeNull();
            userRatings[0].Show.Should().NotBeNull();
            userRatings[0].Show.Title.Should().Be("Breaking Bad");
            userRatings[0].Show.Year.Should().Be(2008);
            userRatings[0].Show.Ids.Should().NotBeNull();
            userRatings[0].Show.Ids.Trakt.Should().Be(1);
            userRatings[0].Show.Ids.Slug.Should().Be("breaking-bad");
            userRatings[0].Show.Ids.Tvdb.Should().Be(81189);
            userRatings[0].Show.Ids.Imdb.Should().Be("tt0903747");
            userRatings[0].Show.Ids.Tmdb.Should().Be(1396);
            userRatings[0].Show.Ids.TvRage.Should().Be(18164);
            userRatings[0].Season.Should().NotBeNull();
            userRatings[0].Season.Number.Should().Be(0);
            userRatings[0].Season.Ids.Should().NotBeNull();
            userRatings[0].Season.Ids.Trakt.Should().Be(0);
            userRatings[0].Season.Ids.Tvdb.Should().Be(439371);
            userRatings[0].Season.Ids.Tmdb.Should().Be(3577);
            userRatings[0].Season.Ids.TvRage.Should().NotHaveValue();
            userRatings[0].Episode.Should().BeNull();

            userRatings[1].RatedAt.Should().Be(DateTime.Parse("2014-09-04T09:10:11.000Z").ToUniversalTime());
            userRatings[1].Rating.Should().Be(9);
            userRatings[1].Type.Should().Be(TraktSyncRatingsItemType.Season);
            userRatings[1].Movie.Should().BeNull();
            userRatings[1].Show.Should().NotBeNull();
            userRatings[1].Show.Title.Should().Be("Breaking Bad");
            userRatings[1].Show.Year.Should().Be(2008);
            userRatings[1].Show.Ids.Should().NotBeNull();
            userRatings[1].Show.Ids.Trakt.Should().Be(1);
            userRatings[1].Show.Ids.Slug.Should().Be("breaking-bad");
            userRatings[1].Show.Ids.Tvdb.Should().Be(81189);
            userRatings[1].Show.Ids.Imdb.Should().Be("tt0903747");
            userRatings[1].Show.Ids.Tmdb.Should().Be(1396);
            userRatings[1].Show.Ids.TvRage.Should().Be(18164);
            userRatings[1].Season.Should().NotBeNull();
            userRatings[1].Season.Number.Should().Be(1);
            userRatings[1].Season.Ids.Should().NotBeNull();
            userRatings[1].Season.Ids.Trakt.Should().Be(0);
            userRatings[1].Season.Ids.Tvdb.Should().Be(30272);
            userRatings[1].Season.Ids.Tmdb.Should().Be(3572);
            userRatings[1].Season.Ids.TvRage.Should().NotHaveValue();
            userRatings[1].Episode.Should().BeNull();
        }

        [TestMethod]
        public void TestTraktUserRatingsItemReadFromJsonEpisodes()
        {
            var jsonFile = TestUtility.ReadFileContents(@"Objects\Get\Users\Ratings\UserRatingsEpisodes.json");

            jsonFile.Should().NotBeNullOrEmpty();

            var userRatingsItem = JsonConvert.DeserializeObject<IEnumerable<TraktUserRatingsItem>>(jsonFile);

            userRatingsItem.Should().NotBeNull();
            userRatingsItem.Should().HaveCount(2);

            var userRatings = userRatingsItem.ToArray();

            userRatings[0].RatedAt.Should().Be(DateTime.Parse("2014-09-01T09:10:11.000Z").ToUniversalTime());
            userRatings[0].Rating.Should().Be(5);
            userRatings[0].Type.Should().Be(TraktSyncRatingsItemType.Episode);
            userRatings[0].Movie.Should().BeNull();
            userRatings[0].Show.Should().NotBeNull();
            userRatings[0].Show.Title.Should().Be("Breaking Bad");
            userRatings[0].Show.Year.Should().Be(2008);
            userRatings[0].Show.Ids.Should().NotBeNull();
            userRatings[0].Show.Ids.Trakt.Should().Be(1);
            userRatings[0].Show.Ids.Slug.Should().Be("breaking-bad");
            userRatings[0].Show.Ids.Tvdb.Should().Be(81189);
            userRatings[0].Show.Ids.Imdb.Should().Be("tt0903747");
            userRatings[0].Show.Ids.Tmdb.Should().Be(1396);
            userRatings[0].Show.Ids.TvRage.Should().Be(18164);
            userRatings[0].Season.Should().BeNull();
            userRatings[0].Episode.Should().NotBeNull();
            userRatings[0].Episode.SeasonNumber.Should().Be(4);
            userRatings[0].Episode.Number.Should().Be(1);
            userRatings[0].Episode.Title.Should().Be("Box Cutter");
            userRatings[0].Episode.Ids.Should().NotBeNull();
            userRatings[0].Episode.Ids.Trakt.Should().Be(49);
            userRatings[0].Episode.Ids.Slug.Should().BeNull();
            userRatings[0].Episode.Ids.Tvdb.Should().Be(2639411);
            userRatings[0].Episode.Ids.Imdb.Should().Be("tt1683084");
            userRatings[0].Episode.Ids.Tmdb.Should().Be(62118);
            userRatings[0].Episode.Ids.TvRage.Should().NotHaveValue();

            userRatings[1].RatedAt.Should().Be(DateTime.Parse("2014-09-06T09:10:11.000Z").ToUniversalTime());
            userRatings[1].Rating.Should().Be(9);
            userRatings[1].Type.Should().Be(TraktSyncRatingsItemType.Episode);
            userRatings[1].Movie.Should().BeNull();
            userRatings[1].Show.Should().NotBeNull();
            userRatings[1].Show.Title.Should().Be("Breaking Bad");
            userRatings[1].Show.Year.Should().Be(2008);
            userRatings[1].Show.Ids.Should().NotBeNull();
            userRatings[1].Show.Ids.Trakt.Should().Be(1);
            userRatings[1].Show.Ids.Slug.Should().Be("breaking-bad");
            userRatings[1].Show.Ids.Tvdb.Should().Be(81189);
            userRatings[1].Show.Ids.Imdb.Should().Be("tt0903747");
            userRatings[1].Show.Ids.Tmdb.Should().Be(1396);
            userRatings[1].Show.Ids.TvRage.Should().Be(18164);
            userRatings[1].Season.Should().BeNull();
            userRatings[1].Episode.Should().NotBeNull();
            userRatings[1].Episode.SeasonNumber.Should().Be(4);
            userRatings[1].Episode.Number.Should().Be(8);
            userRatings[1].Episode.Title.Should().Be("Hermanos");
            userRatings[1].Episode.Ids.Should().NotBeNull();
            userRatings[1].Episode.Ids.Trakt.Should().Be(56);
            userRatings[1].Episode.Ids.Slug.Should().BeNull();
            userRatings[1].Episode.Ids.Tvdb.Should().Be(4127161);
            userRatings[1].Episode.Ids.Imdb.Should().Be("tt1683095");
            userRatings[1].Episode.Ids.Tmdb.Should().Be(62127);
            userRatings[1].Episode.Ids.TvRage.Should().NotHaveValue();
        }
    }
}
