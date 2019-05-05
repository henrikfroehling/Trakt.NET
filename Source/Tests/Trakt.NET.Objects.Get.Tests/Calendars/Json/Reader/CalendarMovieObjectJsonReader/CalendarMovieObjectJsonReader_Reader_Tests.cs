namespace TraktNet.Objects.Get.Tests.Calendars.Json.Reader
{
    using FluentAssertions;
    using Newtonsoft.Json;
    using System;
    using System.IO;
    using System.Threading.Tasks;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Objects.Get.Calendars.Json.Reader;
    using Xunit;

    [Category("Objects.Get.Calendars.JsonReader")]
    public partial class CalendarMovieObjectJsonReader_Tests
    {
        [Fact]
        public async Task Test_CalendarMovieObjectJsonReader_ReadObject_From_JsonReader_Complete()
        {
            var traktJsonReader = new CalendarMovieObjectJsonReader();

            using (var reader = new StringReader(JSON_COMPLETE))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktCalendarMovie = await traktJsonReader.ReadObjectAsync(jsonReader);

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
        }

        [Fact]
        public async Task Test_CalendarMovieObjectJsonReader_ReadObject_From_JsonReader_Incomplete_1()
        {
            var traktJsonReader = new CalendarMovieObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_1))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktCalendarMovie = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktCalendarMovie.Should().NotBeNull();
                traktCalendarMovie.CalendarRelease.Should().Be(DateTime.Parse("2014-08-01"));
                traktCalendarMovie.Movie.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_CalendarMovieObjectJsonReader_ReadObject_From_JsonReader_Incomplete_2()
        {
            var traktJsonReader = new CalendarMovieObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_2))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktCalendarMovie = await traktJsonReader.ReadObjectAsync(jsonReader);

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
        }

        [Fact]
        public async Task Test_CalendarMovieObjectJsonReader_ReadObject_From_JsonReader_Not_Valid_1()
        {
            var traktJsonReader = new CalendarMovieObjectJsonReader();

            using (var reader = new StringReader(JSON_NOT_VALID_1))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktCalendarMovie = await traktJsonReader.ReadObjectAsync(jsonReader);

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
        }

        [Fact]
        public async Task Test_CalendarMovieObjectJsonReader_ReadObject_From_JsonReader_Not_Valid_2()
        {
            var traktJsonReader = new CalendarMovieObjectJsonReader();

            using (var reader = new StringReader(JSON_NOT_VALID_2))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktCalendarMovie = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktCalendarMovie.Should().NotBeNull();
                traktCalendarMovie.CalendarRelease.Should().Be(DateTime.Parse("2014-08-01"));
                traktCalendarMovie.Movie.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_CalendarMovieObjectJsonReader_ReadObject_From_JsonReader_Not_Valid_3()
        {
            var traktJsonReader = new CalendarMovieObjectJsonReader();

            using (var reader = new StringReader(JSON_NOT_VALID_3))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktCalendarMovie = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktCalendarMovie.Should().NotBeNull();
                traktCalendarMovie.CalendarRelease.Should().BeNull();
                traktCalendarMovie.Movie.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_CalendarMovieObjectJsonReader_ReadObject_From_JsonReader_Null()
        {
            var traktJsonReader = new CalendarMovieObjectJsonReader();

            var traktCalendarMovie = await traktJsonReader.ReadObjectAsync(default(JsonTextReader));
            traktCalendarMovie.Should().BeNull();
        }

        [Fact]
        public async Task Test_CalendarMovieObjectJsonReader_ReadObject_From_JsonReader_Empty()
        {
            var traktJsonReader = new CalendarMovieObjectJsonReader();

            using (var reader = new StringReader(string.Empty))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktCalendarMovie = await traktJsonReader.ReadObjectAsync(jsonReader);
                traktCalendarMovie.Should().BeNull();
            }
        }
    }
}
