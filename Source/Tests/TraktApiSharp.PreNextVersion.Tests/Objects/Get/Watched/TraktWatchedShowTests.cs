namespace TraktApiSharp.Tests.Objects.Get.Syncs.Watched
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using TraktApiSharp.Objects.Get.Watched;
    using Utils;

    [TestClass]
    public class TraktWatchedShowTests
    {
        [TestMethod]
        public void TestTraktWatchedShowDefaultConstructor()
        {
            var showItem = new TraktWatchedShow();

            showItem.Plays.Should().NotHaveValue();
            showItem.LastWatchedAt.Should().NotHaveValue();
            showItem.Show.Should().BeNull();
            showItem.Seasons.Should().BeNull();
        }

        [TestMethod]
        public void TestTraktWatchedShowReadFromJson()
        {
            var jsonFile = TestUtility.ReadFileContents(@"Objects\Get\Watched\WatchedShows.json");

            jsonFile.Should().NotBeNullOrEmpty();

            var showItems = JsonConvert.DeserializeObject<IEnumerable<TraktWatchedShow>>(jsonFile);

            showItems.Should().NotBeNull();
            showItems.Should().HaveCount(2);

            var shows = showItems.ToArray();

            shows[0].Plays.Should().Be(56);
            shows[0].LastWatchedAt.Should().Be(DateTime.Parse("2014-10-13T17:00:54.000Z").ToUniversalTime());
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
            shows[0].Seasons.Should().NotBeNull();
            shows[0].Seasons.Should().HaveCount(2);

            var show1Seasons = shows[0].Seasons.ToArray();

            show1Seasons[0].Number.Should().Be(1);
            show1Seasons[0].Episodes.Should().NotBeNull();
            show1Seasons[0].Episodes.Should().HaveCount(2);

            show1Seasons[1].Number.Should().Be(2);
            show1Seasons[1].Episodes.Should().NotBeNull();
            show1Seasons[1].Episodes.Should().HaveCount(2);

            var show1Season1Episodes = show1Seasons[0].Episodes.ToArray();

            show1Season1Episodes[0].Number.Should().Be(1);
            show1Season1Episodes[0].Plays.Should().Be(1);
            show1Season1Episodes[0].LastWatchedAt.Should().Be(DateTime.Parse("2014-10-12T17:00:54.000Z").ToUniversalTime());

            show1Season1Episodes[1].Number.Should().Be(2);
            show1Season1Episodes[1].Plays.Should().Be(1);
            show1Season1Episodes[1].LastWatchedAt.Should().Be(DateTime.Parse("2014-10-13T17:00:54.000Z").ToUniversalTime());

            var show1Season2Episodes = show1Seasons[1].Episodes.ToArray();

            show1Season2Episodes[0].Number.Should().Be(1);
            show1Season2Episodes[0].Plays.Should().Be(1);
            show1Season2Episodes[0].LastWatchedAt.Should().Be(DateTime.Parse("2014-10-11T17:00:54.000Z").ToUniversalTime());

            show1Season2Episodes[1].Number.Should().Be(2);
            show1Season2Episodes[1].Plays.Should().Be(1);
            show1Season2Episodes[1].LastWatchedAt.Should().Be(DateTime.Parse("2014-10-12T17:00:54.000Z").ToUniversalTime());

            shows[1].Plays.Should().Be(23);
            shows[1].LastWatchedAt.Should().Be(DateTime.Parse("2014-10-14T17:00:54.000Z").ToUniversalTime());
            shows[1].Show.Should().NotBeNull();
            shows[1].Show.Title.Should().Be("Parks and Recreation");
            shows[1].Show.Year.Should().Be(2009);
            shows[1].Show.Ids.Should().NotBeNull();
            shows[1].Show.Ids.Trakt.Should().Be(4U);
            shows[1].Show.Ids.Slug.Should().Be("parks-and-recreation");
            shows[1].Show.Ids.Tvdb.Should().Be(84912U);
            shows[1].Show.Ids.Imdb.Should().Be("tt1266020");
            shows[1].Show.Ids.Tmdb.Should().Be(8592U);
            shows[1].Show.Ids.TvRage.Should().Be(21686U);
            shows[1].Seasons.Should().NotBeNull();
            shows[1].Seasons.Should().HaveCount(2);

            var show2Seasons = shows[1].Seasons.ToArray();

            show2Seasons[0].Number.Should().Be(1);
            show2Seasons[0].Episodes.Should().NotBeNull();
            show2Seasons[0].Episodes.Should().HaveCount(2);

            show2Seasons[1].Number.Should().Be(2);
            show2Seasons[1].Episodes.Should().NotBeNull();
            show2Seasons[1].Episodes.Should().HaveCount(2);

            var show2Season1Episodes = show2Seasons[0].Episodes.ToArray();

            show2Season1Episodes[0].Number.Should().Be(1);
            show2Season1Episodes[0].Plays.Should().Be(1);
            show2Season1Episodes[0].LastWatchedAt.Should().Be(DateTime.Parse("2014-10-11T17:00:54.000Z").ToUniversalTime());

            show2Season1Episodes[1].Number.Should().Be(2);
            show2Season1Episodes[1].Plays.Should().Be(1);
            show2Season1Episodes[1].LastWatchedAt.Should().Be(DateTime.Parse("2014-10-14T17:00:54.000Z").ToUniversalTime());

            var show2Season2Episodes = show2Seasons[1].Episodes.ToArray();

            show2Season2Episodes[0].Number.Should().Be(1);
            show2Season2Episodes[0].Plays.Should().Be(1);
            show2Season2Episodes[0].LastWatchedAt.Should().Be(DateTime.Parse("2014-10-11T17:00:54.000Z").ToUniversalTime());

            show2Season2Episodes[1].Number.Should().Be(2);
            show2Season2Episodes[1].Plays.Should().Be(1);
            show2Season2Episodes[1].LastWatchedAt.Should().Be(DateTime.Parse("2014-10-14T17:00:54.000Z").ToUniversalTime());
        }

        [TestMethod]
        public void TestTraktWatchedShowReadFromJsonNoSeasons()
        {
            var jsonFile = TestUtility.ReadFileContents(@"Objects\Get\Watched\WatchedShowsNoSeasons.json");

            jsonFile.Should().NotBeNullOrEmpty();

            var showItems = JsonConvert.DeserializeObject<IEnumerable<TraktWatchedShow>>(jsonFile);

            showItems.Should().NotBeNull();
            showItems.Should().HaveCount(2);

            var shows = showItems.ToArray();

            shows[0].Plays.Should().Be(56);
            shows[0].LastWatchedAt.Should().Be(DateTime.Parse("2014-10-11T17:00:54.000Z").ToUniversalTime());
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
            shows[0].Seasons.Should().BeNull();

            shows[1].Plays.Should().Be(23);
            shows[1].LastWatchedAt.Should().Be(DateTime.Parse("2014-10-12T17:00:54.000Z").ToUniversalTime());
            shows[1].Show.Should().NotBeNull();
            shows[1].Show.Title.Should().Be("Parks and Recreation");
            shows[1].Show.Year.Should().Be(2009);
            shows[1].Show.Ids.Should().NotBeNull();
            shows[1].Show.Ids.Trakt.Should().Be(4U);
            shows[1].Show.Ids.Slug.Should().Be("parks-and-recreation");
            shows[1].Show.Ids.Tvdb.Should().Be(84912U);
            shows[1].Show.Ids.Imdb.Should().Be("tt1266020");
            shows[1].Show.Ids.Tmdb.Should().Be(8592U);
            shows[1].Show.Ids.TvRage.Should().Be(21686U);
            shows[1].Seasons.Should().BeNull();
        }
    }
}
