namespace TraktNet.Objects.Get.Tests.Calendars.Json.Reader
{
    using FluentAssertions;
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Threading.Tasks;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Objects.Get.Calendars;
    using TraktNet.Objects.Get.Calendars.Json.Reader;
    using Xunit;

    [Category("Objects.Get.Calendars.JsonReader")]
    public partial class CalendarMovieArrayJsonReader_Tests
    {
        [Fact]
        public async Task Test_CalendarMovieArrayJsonReader_ReadArray_From_JsonReader_Empty_Array()
        {
            var traktJsonReader = new CalendarMovieArrayJsonReader();

            using (var reader = new StringReader(JSON_EMPTY_ARRAY))
            using (var jsonReader = new JsonTextReader(reader))
            {
                IEnumerable<ITraktCalendarMovie> traktCalendarMovies = await traktJsonReader.ReadArrayAsync(jsonReader);
                traktCalendarMovies.Should().NotBeNull().And.BeEmpty();
            }
        }

        [Fact]
        public async Task Test_CalendarMovieArrayJsonReader_ReadArray_From_JsonReader_Complete()
        {
            var traktJsonReader = new CalendarMovieArrayJsonReader();

            using (var reader = new StringReader(JSON_COMPLETE))
            using (var jsonReader = new JsonTextReader(reader))
            {
                IEnumerable<ITraktCalendarMovie> traktCalendarMovies = await traktJsonReader.ReadArrayAsync(jsonReader);

                traktCalendarMovies.Should().NotBeNull();
                ITraktCalendarMovie[] calendarMovies = traktCalendarMovies.ToArray();

                calendarMovies[0].Should().NotBeNull();
                calendarMovies[0].CalendarRelease.Should().Be(DateTime.Parse("2014-08-01"));
                calendarMovies[0].Movie.Should().NotBeNull();
                calendarMovies[0].Movie.Title.Should().Be("Star Wars: The Force Awakens");
                calendarMovies[0].Movie.Year.Should().Be(2015);
                calendarMovies[0].Movie.Ids.Should().NotBeNull();
                calendarMovies[0].Movie.Ids.Trakt.Should().Be(94024U);
                calendarMovies[0].Movie.Ids.Slug.Should().Be("star-wars-the-force-awakens-2015");
                calendarMovies[0].Movie.Ids.Imdb.Should().Be("tt2488496");
                calendarMovies[0].Movie.Ids.Tmdb.Should().Be(140607U);

                calendarMovies[1].Should().NotBeNull();
                calendarMovies[1].CalendarRelease.Should().Be(DateTime.Parse("2014-08-01"));
                calendarMovies[1].Movie.Should().NotBeNull();
                calendarMovies[1].Movie.Title.Should().Be("Star Wars: The Force Awakens");
                calendarMovies[1].Movie.Year.Should().Be(2015);
                calendarMovies[1].Movie.Ids.Should().NotBeNull();
                calendarMovies[1].Movie.Ids.Trakt.Should().Be(94024U);
                calendarMovies[1].Movie.Ids.Slug.Should().Be("star-wars-the-force-awakens-2015");
                calendarMovies[1].Movie.Ids.Imdb.Should().Be("tt2488496");
                calendarMovies[1].Movie.Ids.Tmdb.Should().Be(140607U);
            }
        }

        [Fact]
        public async Task Test_CalendarMovieArrayJsonReader_ReadArray_From_JsonReader_Incomplete_1()
        {
            var traktJsonReader = new CalendarMovieArrayJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_1))
            using (var jsonReader = new JsonTextReader(reader))
            {
                IEnumerable<ITraktCalendarMovie> traktCalendarMovies = await traktJsonReader.ReadArrayAsync(jsonReader);

                traktCalendarMovies.Should().NotBeNull();
                ITraktCalendarMovie[] calendarMovies = traktCalendarMovies.ToArray();

                calendarMovies[0].Should().NotBeNull();
                calendarMovies[0].CalendarRelease.Should().Be(DateTime.Parse("2014-08-01"));
                calendarMovies[0].Movie.Should().NotBeNull();
                calendarMovies[0].Movie.Title.Should().Be("Star Wars: The Force Awakens");
                calendarMovies[0].Movie.Year.Should().Be(2015);
                calendarMovies[0].Movie.Ids.Should().NotBeNull();
                calendarMovies[0].Movie.Ids.Trakt.Should().Be(94024U);
                calendarMovies[0].Movie.Ids.Slug.Should().Be("star-wars-the-force-awakens-2015");
                calendarMovies[0].Movie.Ids.Imdb.Should().Be("tt2488496");
                calendarMovies[0].Movie.Ids.Tmdb.Should().Be(140607U);

                calendarMovies[1].Should().NotBeNull();
                calendarMovies[1].CalendarRelease.Should().BeNull();
                calendarMovies[1].Movie.Should().NotBeNull();
                calendarMovies[1].Movie.Title.Should().Be("Star Wars: The Force Awakens");
                calendarMovies[1].Movie.Year.Should().Be(2015);
                calendarMovies[1].Movie.Ids.Should().NotBeNull();
                calendarMovies[1].Movie.Ids.Trakt.Should().Be(94024U);
                calendarMovies[1].Movie.Ids.Slug.Should().Be("star-wars-the-force-awakens-2015");
                calendarMovies[1].Movie.Ids.Imdb.Should().Be("tt2488496");
                calendarMovies[1].Movie.Ids.Tmdb.Should().Be(140607U);
            }
        }

        [Fact]
        public async Task Test_CalendarMovieArrayJsonReader_ReadArray_From_JsonReader_Incomplete_2()
        {
            var traktJsonReader = new CalendarMovieArrayJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_2))
            using (var jsonReader = new JsonTextReader(reader))
            {
                IEnumerable<ITraktCalendarMovie> traktCalendarMovies = await traktJsonReader.ReadArrayAsync(jsonReader);

                traktCalendarMovies.Should().NotBeNull();
                ITraktCalendarMovie[] calendarMovies = traktCalendarMovies.ToArray();

                calendarMovies[0].Should().NotBeNull();
                calendarMovies[0].CalendarRelease.Should().BeNull();
                calendarMovies[0].Movie.Should().NotBeNull();
                calendarMovies[0].Movie.Title.Should().Be("Star Wars: The Force Awakens");
                calendarMovies[0].Movie.Year.Should().Be(2015);
                calendarMovies[0].Movie.Ids.Should().NotBeNull();
                calendarMovies[0].Movie.Ids.Trakt.Should().Be(94024U);
                calendarMovies[0].Movie.Ids.Slug.Should().Be("star-wars-the-force-awakens-2015");
                calendarMovies[0].Movie.Ids.Imdb.Should().Be("tt2488496");
                calendarMovies[0].Movie.Ids.Tmdb.Should().Be(140607U);

                calendarMovies[1].Should().NotBeNull();
                calendarMovies[1].CalendarRelease.Should().Be(DateTime.Parse("2014-08-01"));
                calendarMovies[1].Movie.Should().NotBeNull();
                calendarMovies[1].Movie.Title.Should().Be("Star Wars: The Force Awakens");
                calendarMovies[1].Movie.Year.Should().Be(2015);
                calendarMovies[1].Movie.Ids.Should().NotBeNull();
                calendarMovies[1].Movie.Ids.Trakt.Should().Be(94024U);
                calendarMovies[1].Movie.Ids.Slug.Should().Be("star-wars-the-force-awakens-2015");
                calendarMovies[1].Movie.Ids.Imdb.Should().Be("tt2488496");
                calendarMovies[1].Movie.Ids.Tmdb.Should().Be(140607U);
            }
        }

        [Fact]
        public async Task Test_CalendarMovieArrayJsonReader_ReadArray_From_JsonReader_Not_Valid_1()
        {
            var traktJsonReader = new CalendarMovieArrayJsonReader();

            using (var reader = new StringReader(JSON_NOT_VALID_1))
            using (var jsonReader = new JsonTextReader(reader))
            {
                IEnumerable<ITraktCalendarMovie> traktCalendarMovies = await traktJsonReader.ReadArrayAsync(jsonReader);

                traktCalendarMovies.Should().NotBeNull();
                ITraktCalendarMovie[] calendarMovies = traktCalendarMovies.ToArray();

                calendarMovies[0].Should().NotBeNull();
                calendarMovies[0].CalendarRelease.Should().Be(DateTime.Parse("2014-08-01"));
                calendarMovies[0].Movie.Should().NotBeNull();
                calendarMovies[0].Movie.Title.Should().Be("Star Wars: The Force Awakens");
                calendarMovies[0].Movie.Year.Should().Be(2015);
                calendarMovies[0].Movie.Ids.Should().NotBeNull();
                calendarMovies[0].Movie.Ids.Trakt.Should().Be(94024U);
                calendarMovies[0].Movie.Ids.Slug.Should().Be("star-wars-the-force-awakens-2015");
                calendarMovies[0].Movie.Ids.Imdb.Should().Be("tt2488496");
                calendarMovies[0].Movie.Ids.Tmdb.Should().Be(140607U);

                calendarMovies[1].Should().NotBeNull();
                calendarMovies[1].CalendarRelease.Should().BeNull();
                calendarMovies[1].Movie.Should().NotBeNull();
                calendarMovies[1].Movie.Title.Should().Be("Star Wars: The Force Awakens");
                calendarMovies[1].Movie.Year.Should().Be(2015);
                calendarMovies[1].Movie.Ids.Should().NotBeNull();
                calendarMovies[1].Movie.Ids.Trakt.Should().Be(94024U);
                calendarMovies[1].Movie.Ids.Slug.Should().Be("star-wars-the-force-awakens-2015");
                calendarMovies[1].Movie.Ids.Imdb.Should().Be("tt2488496");
                calendarMovies[1].Movie.Ids.Tmdb.Should().Be(140607U);
            }
        }

        [Fact]
        public async Task Test_CalendarMovieArrayJsonReader_ReadArray_From_JsonReader_Not_Valid_2()
        {
            var traktJsonReader = new CalendarMovieArrayJsonReader();

            using (var reader = new StringReader(JSON_NOT_VALID_2))
            using (var jsonReader = new JsonTextReader(reader))
            {
                IEnumerable<ITraktCalendarMovie> traktCalendarMovies = await traktJsonReader.ReadArrayAsync(jsonReader);

                traktCalendarMovies.Should().NotBeNull();
                ITraktCalendarMovie[] calendarMovies = traktCalendarMovies.ToArray();

                calendarMovies[0].Should().NotBeNull();
                calendarMovies[0].CalendarRelease.Should().BeNull();
                calendarMovies[0].Movie.Should().NotBeNull();
                calendarMovies[0].Movie.Title.Should().Be("Star Wars: The Force Awakens");
                calendarMovies[0].Movie.Year.Should().Be(2015);
                calendarMovies[0].Movie.Ids.Should().NotBeNull();
                calendarMovies[0].Movie.Ids.Trakt.Should().Be(94024U);
                calendarMovies[0].Movie.Ids.Slug.Should().Be("star-wars-the-force-awakens-2015");
                calendarMovies[0].Movie.Ids.Imdb.Should().Be("tt2488496");
                calendarMovies[0].Movie.Ids.Tmdb.Should().Be(140607U);

                calendarMovies[1].Should().NotBeNull();
                calendarMovies[1].CalendarRelease.Should().Be(DateTime.Parse("2014-08-01"));
                calendarMovies[1].Movie.Should().NotBeNull();
                calendarMovies[1].Movie.Title.Should().Be("Star Wars: The Force Awakens");
                calendarMovies[1].Movie.Year.Should().Be(2015);
                calendarMovies[1].Movie.Ids.Should().NotBeNull();
                calendarMovies[1].Movie.Ids.Trakt.Should().Be(94024U);
                calendarMovies[1].Movie.Ids.Slug.Should().Be("star-wars-the-force-awakens-2015");
                calendarMovies[1].Movie.Ids.Imdb.Should().Be("tt2488496");
                calendarMovies[1].Movie.Ids.Tmdb.Should().Be(140607U);
            }
        }

        [Fact]
        public async Task Test_CalendarMovieArrayJsonReader_ReadArray_From_JsonReader_Not_Valid_3()
        {
            var traktJsonReader = new CalendarMovieArrayJsonReader();

            using (var reader = new StringReader(JSON_NOT_VALID_3))
            using (var jsonReader = new JsonTextReader(reader))
            {
                IEnumerable<ITraktCalendarMovie> traktCalendarMovies = await traktJsonReader.ReadArrayAsync(jsonReader);

                traktCalendarMovies.Should().NotBeNull();
                ITraktCalendarMovie[] calendarMovies = traktCalendarMovies.ToArray();

                calendarMovies[0].Should().NotBeNull();
                calendarMovies[0].CalendarRelease.Should().BeNull();
                calendarMovies[0].Movie.Should().NotBeNull();
                calendarMovies[0].Movie.Title.Should().Be("Star Wars: The Force Awakens");
                calendarMovies[0].Movie.Year.Should().Be(2015);
                calendarMovies[0].Movie.Ids.Should().NotBeNull();
                calendarMovies[0].Movie.Ids.Trakt.Should().Be(94024U);
                calendarMovies[0].Movie.Ids.Slug.Should().Be("star-wars-the-force-awakens-2015");
                calendarMovies[0].Movie.Ids.Imdb.Should().Be("tt2488496");
                calendarMovies[0].Movie.Ids.Tmdb.Should().Be(140607U);

                calendarMovies[1].Should().NotBeNull();
                calendarMovies[1].CalendarRelease.Should().BeNull();
                calendarMovies[1].Movie.Should().NotBeNull();
                calendarMovies[1].Movie.Title.Should().Be("Star Wars: The Force Awakens");
                calendarMovies[1].Movie.Year.Should().Be(2015);
                calendarMovies[1].Movie.Ids.Should().NotBeNull();
                calendarMovies[1].Movie.Ids.Trakt.Should().Be(94024U);
                calendarMovies[1].Movie.Ids.Slug.Should().Be("star-wars-the-force-awakens-2015");
                calendarMovies[1].Movie.Ids.Imdb.Should().Be("tt2488496");
                calendarMovies[1].Movie.Ids.Tmdb.Should().Be(140607U);
            }
        }

        [Fact]
        public async Task Test_CalendarMovieArrayJsonReader_ReadArray_From_JsonReader_Null()
        {
            var traktJsonReader = new CalendarMovieArrayJsonReader();
            IEnumerable<ITraktCalendarMovie> traktCalendarMovies = await traktJsonReader.ReadArrayAsync(default(JsonTextReader));
            traktCalendarMovies.Should().BeNull();
        }

        [Fact]
        public async Task Test_CalendarMovieArrayJsonReader_ReadArray_From_JsonReader_Empty()
        {
            var traktJsonReader = new CalendarMovieArrayJsonReader();

            using (var reader = new StringReader(string.Empty))
            using (var jsonReader = new JsonTextReader(reader))
            {
                IEnumerable<ITraktCalendarMovie> traktCalendarMovies = await traktJsonReader.ReadArrayAsync(jsonReader);
                traktCalendarMovies.Should().BeNull();
            }
        }
    }
}
