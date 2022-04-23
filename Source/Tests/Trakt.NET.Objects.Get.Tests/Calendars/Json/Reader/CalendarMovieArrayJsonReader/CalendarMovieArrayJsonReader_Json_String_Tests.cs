namespace TraktNet.Objects.Get.Tests.Calendars.Json.Reader
{
    using FluentAssertions;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Objects.Get.Calendars;
    using TraktNet.Objects.Json;
    using Xunit;

    [Category("Objects.Get.Calendars.JsonReader")]
    public partial class CalendarMovieArrayJsonReader_Tests
    {
        [Fact]
        public async Task Test_CalendarMovieArrayJsonReader_ReadArray_From_Json_String_Empty_Array()
        {
            var jsonReader = new ArrayJsonReader<ITraktCalendarMovie>();
            IEnumerable<ITraktCalendarMovie> traktCalendarMovies = await jsonReader.ReadArrayAsync(JSON_EMPTY_ARRAY);
            traktCalendarMovies.Should().NotBeNull().And.BeEmpty();
        }

        [Fact]
        public async Task Test_CalendarMovieArrayJsonReader_ReadArray_From_Json_String_Complete()
        {
            var jsonReader = new ArrayJsonReader<ITraktCalendarMovie>();
            IEnumerable<ITraktCalendarMovie> traktCalendarMovies = await jsonReader.ReadArrayAsync(JSON_COMPLETE);

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

        [Fact]
        public async Task Test_CalendarMovieArrayJsonReader_ReadArray_From_Json_String_Incomplete_1()
        {
            var jsonReader = new ArrayJsonReader<ITraktCalendarMovie>();
            IEnumerable<ITraktCalendarMovie> traktCalendarMovies = await jsonReader.ReadArrayAsync(JSON_INCOMPLETE_1);

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

        [Fact]
        public async Task Test_CalendarMovieArrayJsonReader_ReadArray_From_Json_String_Incomplete_2()
        {
            var jsonReader = new ArrayJsonReader<ITraktCalendarMovie>();
            IEnumerable<ITraktCalendarMovie> traktCalendarMovies = await jsonReader.ReadArrayAsync(JSON_INCOMPLETE_2);

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

        [Fact]
        public async Task Test_CalendarMovieArrayJsonReader_ReadArray_From_Json_String_Not_Valid_1()
        {
            var jsonReader = new ArrayJsonReader<ITraktCalendarMovie>();
            IEnumerable<ITraktCalendarMovie> traktCalendarMovies = await jsonReader.ReadArrayAsync(JSON_NOT_VALID_1);

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

        [Fact]
        public async Task Test_CalendarMovieArrayJsonReader_ReadArray_From_Json_String_Not_Valid_2()
        {
            var jsonReader = new ArrayJsonReader<ITraktCalendarMovie>();
            IEnumerable<ITraktCalendarMovie> traktCalendarMovies = await jsonReader.ReadArrayAsync(JSON_NOT_VALID_2);

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

        [Fact]
        public async Task Test_CalendarMovieArrayJsonReader_ReadArray_From_Json_String_Not_Valid_3()
        {
            var jsonReader = new ArrayJsonReader<ITraktCalendarMovie>();
            IEnumerable<ITraktCalendarMovie> traktCalendarMovies = await jsonReader.ReadArrayAsync(JSON_NOT_VALID_3);

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

        [Fact]
        public async Task Test_CalendarMovieArrayJsonReader_ReadArray_From_Json_String_Null()
        {
            var jsonReader = new ArrayJsonReader<ITraktCalendarMovie>();
            Func<Task<IEnumerable<ITraktCalendarMovie>>> traktCalendarMovies = () => jsonReader.ReadArrayAsync(default(string));
            await traktCalendarMovies.Should().ThrowAsync<ArgumentNullException>();
        }

        [Fact]
        public async Task Test_CalendarMovieArrayJsonReader_ReadArray_From_Json_String_Empty()
        {
            var jsonReader = new ArrayJsonReader<ITraktCalendarMovie>();
            IEnumerable<ITraktCalendarMovie> traktCalendarMovies = await jsonReader.ReadArrayAsync(string.Empty);
            traktCalendarMovies.Should().BeNull();
        }
    }
}
