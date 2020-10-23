namespace TraktNet.Objects.Get.Tests.Calendars.Json.Reader
{
    using FluentAssertions;
    using System;
    using System.IO;
    using System.Threading.Tasks;
    using Trakt.NET.Tests.Utility;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Objects.Get.Calendars;
    using TraktNet.Objects.Get.Calendars.Json.Reader;
    using Xunit;

    [Category("Objects.Get.Calendars.JsonReader")]
    public partial class CalendarMovieObjectJsonReader_Tests
    {
        [Fact]
        public async Task Test_CalendarMovieObjectJsonReader_ReadObject_From_Stream_Complete()
        {
            var jsonReader = new CalendarMovieObjectJsonReader();

            using (var stream = JSON_COMPLETE.ToStream())
            {
                var traktCalendarMovie = await jsonReader.ReadObjectAsync(stream);

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
        public async Task Test_CalendarMovieObjectJsonReader_ReadObject_From_Stream_Incomplete_1()
        {
            var jsonReader = new CalendarMovieObjectJsonReader();

            using (var stream = JSON_INCOMPLETE_1.ToStream())
            {
                var traktCalendarMovie = await jsonReader.ReadObjectAsync(stream);

                traktCalendarMovie.Should().NotBeNull();
                traktCalendarMovie.CalendarRelease.Should().Be(DateTime.Parse("2014-08-01"));
                traktCalendarMovie.Movie.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_CalendarMovieObjectJsonReader_ReadObject_From_Stream_Incomplete_2()
        {
            var jsonReader = new CalendarMovieObjectJsonReader();

            using (var stream = JSON_INCOMPLETE_2.ToStream())
            {
                var traktCalendarMovie = await jsonReader.ReadObjectAsync(stream);

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
        public async Task Test_CalendarMovieObjectJsonReader_ReadObject_From_Stream_Not_Valid_1()
        {
            var jsonReader = new CalendarMovieObjectJsonReader();

            using (var stream = JSON_NOT_VALID_1.ToStream())
            {
                var traktCalendarMovie = await jsonReader.ReadObjectAsync(stream);

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
        public async Task Test_CalendarMovieObjectJsonReader_ReadObject_From_Stream_Not_Valid_2()
        {
            var jsonReader = new CalendarMovieObjectJsonReader();

            using (var stream = JSON_NOT_VALID_2.ToStream())
            {
                var traktCalendarMovie = await jsonReader.ReadObjectAsync(stream);

                traktCalendarMovie.Should().NotBeNull();
                traktCalendarMovie.CalendarRelease.Should().Be(DateTime.Parse("2014-08-01"));
                traktCalendarMovie.Movie.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_CalendarMovieObjectJsonReader_ReadObject_From_Stream_Not_Valid_3()
        {
            var jsonReader = new CalendarMovieObjectJsonReader();

            using (var stream = JSON_NOT_VALID_3.ToStream())
            {
                var traktCalendarMovie = await jsonReader.ReadObjectAsync(stream);

                traktCalendarMovie.Should().NotBeNull();
                traktCalendarMovie.CalendarRelease.Should().BeNull();
                traktCalendarMovie.Movie.Should().BeNull();
            }
        }

        [Fact]
        public void Test_CalendarMovieObjectJsonReader_ReadObject_From_Stream_Null()
        {
            var jsonReader = new CalendarMovieObjectJsonReader();
            Func<Task<ITraktCalendarMovie>> traktCalendarMovie = () => jsonReader.ReadObjectAsync(default(Stream));
            traktCalendarMovie.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public async Task Test_CalendarMovieObjectJsonReader_ReadObject_From_Stream_Empty()
        {
            var jsonReader = new CalendarMovieObjectJsonReader();

            using (var stream = string.Empty.ToStream())
            {
                var traktCalendarMovie = await jsonReader.ReadObjectAsync(stream);
                traktCalendarMovie.Should().BeNull();
            }
        }
    }
}
