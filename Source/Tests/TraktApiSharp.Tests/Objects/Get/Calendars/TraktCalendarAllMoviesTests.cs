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
    public class TraktCalendarAllMoviesTests
    {
        [TestMethod]
        public void TestTraktCalendarAllMoviesDefaultConstructor()
        {
            var allMoviesItem = new TraktCalendarMovie();

            allMoviesItem.Released.Should().NotHaveValue();
            allMoviesItem.Movie.Should().BeNull();
        }

        [TestMethod]
        public void TestTraktCalendarAllMoviesReadFromJson()
        {
            var jsonFile = TestUtility.ReadFileContents(@"Objects\Get\Calendars\CalendarAllMovies.json");

            jsonFile.Should().NotBeNullOrEmpty();

            var allMovies = JsonConvert.DeserializeObject<IEnumerable<TraktCalendarMovie>>(jsonFile);

            allMovies.Should().NotBeNull().And.HaveCount(3);

            var calendarMovies = allMovies.ToArray();

            calendarMovies[0].Released.Should().Be(DateTime.Parse("2014-08-01"));
            calendarMovies[0].Movie.Should().NotBeNull();
            calendarMovies[0].Movie.Title.Should().Be("Guardians of the Galaxy");
            calendarMovies[0].Movie.Year.Should().Be(2014);
            calendarMovies[0].Movie.Ids.Should().NotBeNull();
            calendarMovies[0].Movie.Ids.Trakt.Should().Be(28);
            calendarMovies[0].Movie.Ids.Slug.Should().Be("guardians-of-the-galaxy-2014");
            calendarMovies[0].Movie.Ids.Imdb.Should().Be("tt2015381");
            calendarMovies[0].Movie.Ids.Tmdb.Should().Be(118340U);

            calendarMovies[1].Released.Should().Be(DateTime.Parse("2014-08-01"));
            calendarMovies[1].Movie.Should().NotBeNull();
            calendarMovies[1].Movie.Title.Should().Be("Get On Up");
            calendarMovies[1].Movie.Year.Should().Be(2014);
            calendarMovies[1].Movie.Ids.Should().NotBeNull();
            calendarMovies[1].Movie.Ids.Trakt.Should().Be(29);
            calendarMovies[1].Movie.Ids.Slug.Should().Be("get-on-up-2014");
            calendarMovies[1].Movie.Ids.Imdb.Should().Be("tt2473602");
            calendarMovies[1].Movie.Ids.Tmdb.Should().Be(239566U);

            calendarMovies[2].Released.Should().Be(DateTime.Parse("2014-08-08"));
            calendarMovies[2].Movie.Should().NotBeNull();
            calendarMovies[2].Movie.Title.Should().Be("Teenage Mutant Ninja Turtles");
            calendarMovies[2].Movie.Year.Should().Be(2014);
            calendarMovies[2].Movie.Ids.Should().NotBeNull();
            calendarMovies[2].Movie.Ids.Trakt.Should().Be(30);
            calendarMovies[2].Movie.Ids.Slug.Should().Be("teenage-mutant-ninja-turtles-2014");
            calendarMovies[2].Movie.Ids.Imdb.Should().Be("tt1291150");
            calendarMovies[2].Movie.Ids.Tmdb.Should().Be(98566U);
        }
    }
}
