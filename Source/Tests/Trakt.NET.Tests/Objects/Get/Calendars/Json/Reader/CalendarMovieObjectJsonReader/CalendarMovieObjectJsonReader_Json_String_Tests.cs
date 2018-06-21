namespace TraktNet.Tests.Objects.Get.Calendars.Json.Reader
{
    using FluentAssertions;
    using System;
    using System.Threading.Tasks;
    using Traits;
    using TraktNet.Objects.Get.Calendars.Json.Reader;
    using Xunit;

    [Category("Objects.Get.Calendars.JsonReader")]
    public partial class CalendarMovieObjectJsonReader_Tests
    {
        [Fact]
        public async Task Test_CalendarMovieObjectJsonReader_ReadObject_From_Json_String_Complete()
        {
            var jsonReader = new CalendarMovieObjectJsonReader();

            var traktCalendarMovie = await jsonReader.ReadObjectAsync(JSON_COMPLETE);

            traktCalendarMovie.Should().NotBeNull();
            traktCalendarMovie.CalendarRelease.Should().Be(DateTime.Parse("2014-08-01"));
            traktCalendarMovie.Movie.Should().NotBeNull();
            traktCalendarMovie.Movie.Title.Should().Be("Star Wars: The Force Awakens");
            traktCalendarMovie.Movie.Year.Should().Be(2015);
            traktCalendarMovie.Movie.Ids.Should().NotBeNull();
            traktCalendarMovie.Movie.Ids.Trakt.Should().Be(94024U);
            traktCalendarMovie.Movie.Ids.Slug.Should().Be("star-wars-the-force-awakens-2015");
            traktCalendarMovie.Movie.Ids.Imdb.Should().Be("tt2488496");
            traktCalendarMovie.Movie.Ids.Tmdb.Should().Be(140607U);
        }

        [Fact]
        public async Task Test_CalendarMovieObjectJsonReader_ReadObject_From_Json_String_Incomplete_1()
        {
            var jsonReader = new CalendarMovieObjectJsonReader();

            var traktCalendarMovie = await jsonReader.ReadObjectAsync(JSON_INCOMPLETE_1);

            traktCalendarMovie.Should().NotBeNull();
            traktCalendarMovie.CalendarRelease.Should().Be(DateTime.Parse("2014-08-01"));
            traktCalendarMovie.Movie.Should().BeNull();
        }

        [Fact]
        public async Task Test_CalendarMovieObjectJsonReader_ReadObject_From_Json_String_Incomplete_2()
        {
            var jsonReader = new CalendarMovieObjectJsonReader();

            var traktCalendarMovie = await jsonReader.ReadObjectAsync(JSON_INCOMPLETE_2);

            traktCalendarMovie.Should().NotBeNull();
            traktCalendarMovie.CalendarRelease.Should().BeNull();
            traktCalendarMovie.Movie.Should().NotBeNull();
            traktCalendarMovie.Movie.Title.Should().Be("Star Wars: The Force Awakens");
            traktCalendarMovie.Movie.Year.Should().Be(2015);
            traktCalendarMovie.Movie.Ids.Should().NotBeNull();
            traktCalendarMovie.Movie.Ids.Trakt.Should().Be(94024U);
            traktCalendarMovie.Movie.Ids.Slug.Should().Be("star-wars-the-force-awakens-2015");
            traktCalendarMovie.Movie.Ids.Imdb.Should().Be("tt2488496");
            traktCalendarMovie.Movie.Ids.Tmdb.Should().Be(140607U);
        }

        [Fact]
        public async Task Test_CalendarMovieObjectJsonReader_ReadObject_From_Json_String_Not_Valid_1()
        {
            var jsonReader = new CalendarMovieObjectJsonReader();

            var traktCalendarMovie = await jsonReader.ReadObjectAsync(JSON_NOT_VALID_1);

            traktCalendarMovie.Should().NotBeNull();
            traktCalendarMovie.CalendarRelease.Should().BeNull();
            traktCalendarMovie.Movie.Should().NotBeNull();
            traktCalendarMovie.Movie.Title.Should().Be("Star Wars: The Force Awakens");
            traktCalendarMovie.Movie.Year.Should().Be(2015);
            traktCalendarMovie.Movie.Ids.Should().NotBeNull();
            traktCalendarMovie.Movie.Ids.Trakt.Should().Be(94024U);
            traktCalendarMovie.Movie.Ids.Slug.Should().Be("star-wars-the-force-awakens-2015");
            traktCalendarMovie.Movie.Ids.Imdb.Should().Be("tt2488496");
            traktCalendarMovie.Movie.Ids.Tmdb.Should().Be(140607U);
        }

        [Fact]
        public async Task Test_CalendarMovieObjectJsonReader_ReadObject_From_Json_String_Not_Valid_2()
        {
            var jsonReader = new CalendarMovieObjectJsonReader();

            var traktCalendarMovie = await jsonReader.ReadObjectAsync(JSON_NOT_VALID_2);

            traktCalendarMovie.Should().NotBeNull();
            traktCalendarMovie.CalendarRelease.Should().Be(DateTime.Parse("2014-08-01"));
            traktCalendarMovie.Movie.Should().BeNull();
        }

        [Fact]
        public async Task Test_CalendarMovieObjectJsonReader_ReadObject_From_Json_String_Not_Valid_3()
        {
            var jsonReader = new CalendarMovieObjectJsonReader();

            var traktCalendarMovie = await jsonReader.ReadObjectAsync(JSON_NOT_VALID_3);

            traktCalendarMovie.Should().NotBeNull();
            traktCalendarMovie.CalendarRelease.Should().BeNull();
            traktCalendarMovie.Movie.Should().BeNull();
        }

        [Fact]
        public async Task Test_CalendarMovieObjectJsonReader_ReadObject_From_Json_String_Null()
        {
            var jsonReader = new CalendarMovieObjectJsonReader();

            var traktCalendarMovie = await jsonReader.ReadObjectAsync(default(string));
            traktCalendarMovie.Should().BeNull();
        }

        [Fact]
        public async Task Test_CalendarMovieObjectJsonReader_ReadObject_From_Json_String_Empty()
        {
            var jsonReader = new CalendarMovieObjectJsonReader();

            var traktCalendarMovie = await jsonReader.ReadObjectAsync(string.Empty);
            traktCalendarMovie.Should().BeNull();
        }
    }
}
