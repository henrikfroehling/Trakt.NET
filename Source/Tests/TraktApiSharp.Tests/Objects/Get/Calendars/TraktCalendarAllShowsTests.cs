namespace TraktApiSharp.Tests.Objects.Get.Calendars
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using TraktApiSharp.Objects.Get.Calendars;
    using Utils;

    [TestClass]
    public class TraktCalendarAllShowsTests
    {
        [TestMethod]
        public void TestTraktCalendarAllShowsDefaultConstructor()
        {
            var allShowsItem = new TraktCalendarShow();

            allShowsItem.FirstAired.Should().NotHaveValue();
            allShowsItem.Episode.Should().BeNull();
            allShowsItem.Show.Should().BeNull();
        }

        [TestMethod]
        public void TestTraktCalendarAllShowsReadFromJson()
        {
            var jsonFile = TestUtility.ReadFileContents(@"Objects\Get\Calendars\CalendarAllShows.json");

            jsonFile.Should().NotBeNullOrEmpty();

            var allShows = JsonConvert.DeserializeObject<IEnumerable<TraktCalendarShow>>(jsonFile);

            allShows.Should().NotBeNull().And.HaveCount(2);

            var calendarShows = allShows.ToArray();

            calendarShows[0].FirstAired.Should().Be(DateTime.Parse("2014-07-14T01:00:00.000Z").ToUniversalTime());
            calendarShows[0].Episode.Should().NotBeNull();
            calendarShows[0].Episode.SeasonNumber.Should().Be(7);
            calendarShows[0].Episode.Number.Should().Be(4);
            calendarShows[0].Episode.Title.Should().Be("Death is Not the End");
            calendarShows[0].Episode.Ids.Should().NotBeNull();
            calendarShows[0].Episode.Ids.Trakt.Should().Be(443U);
            calendarShows[0].Episode.Ids.Tvdb.Should().Be(4851180U);
            calendarShows[0].Episode.Ids.Imdb.Should().Be("tt3500614");
            calendarShows[0].Episode.Ids.Tmdb.Should().Be(988123U);
            calendarShows[0].Episode.Ids.TvRage.Should().BeNull();
            calendarShows[0].Show.Should().NotBeNull();
            calendarShows[0].Show.Title.Should().Be("True Blood");
            calendarShows[0].Show.Year.Should().Be(2008);
            calendarShows[0].Show.Ids.Should().NotBeNull();
            calendarShows[0].Show.Ids.Trakt.Should().Be(5);
            calendarShows[0].Show.Ids.Slug.Should().Be("true-blood");
            calendarShows[0].Show.Ids.Tvdb.Should().Be(82283U);
            calendarShows[0].Show.Ids.Imdb.Should().Be("tt0844441");
            calendarShows[0].Show.Ids.Tmdb.Should().Be(10545U);
            calendarShows[0].Show.Ids.TvRage.Should().Be(12662U);

            calendarShows[1].FirstAired.Should().Be(DateTime.Parse("2014-07-14T02:00:00.000Z").ToUniversalTime());
            calendarShows[1].Episode.Should().NotBeNull();
            calendarShows[1].Episode.SeasonNumber.Should().Be(1);
            calendarShows[1].Episode.Number.Should().Be(3);
            calendarShows[1].Episode.Title.Should().Be("Two Boats and a Helicopter");
            calendarShows[1].Episode.Ids.Should().NotBeNull();
            calendarShows[1].Episode.Ids.Trakt.Should().Be(499U);
            calendarShows[1].Episode.Ids.Tvdb.Should().Be(4854797U);
            calendarShows[1].Episode.Ids.Imdb.Should().Be("tt3631218");
            calendarShows[1].Episode.Ids.Tmdb.Should().Be(988346U);
            calendarShows[1].Episode.Ids.TvRage.Should().BeNull();
            calendarShows[1].Show.Should().NotBeNull();
            calendarShows[1].Show.Title.Should().Be("The Leftovers");
            calendarShows[1].Show.Year.Should().Be(2014);
            calendarShows[1].Show.Ids.Should().NotBeNull();
            calendarShows[1].Show.Ids.Trakt.Should().Be(7);
            calendarShows[1].Show.Ids.Slug.Should().Be("the-leftovers");
            calendarShows[1].Show.Ids.Tvdb.Should().Be(269689U);
            calendarShows[1].Show.Ids.Imdb.Should().Be("tt2699128");
            calendarShows[1].Show.Ids.Tmdb.Should().Be(54344U);
            calendarShows[1].Show.Ids.TvRage.Should().BeNull();
        }
    }
}
