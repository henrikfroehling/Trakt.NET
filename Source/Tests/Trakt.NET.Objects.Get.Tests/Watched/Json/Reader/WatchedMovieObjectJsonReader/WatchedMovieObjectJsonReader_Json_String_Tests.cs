namespace TraktNet.Objects.Get.Tests.Watched.Json.Reader
{
    using FluentAssertions;
    using System;
    using System.Threading.Tasks;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Objects.Get.Watched.Json.Reader;
    using Xunit;

    [Category("Objects.Get.Watched.JsonReader")]
    public partial class WatchedMovieObjectJsonReader_Tests
    {
        [Fact]
        public async Task Test_WatchedMovieObjectJsonReader_ReadObject_From_Json_String_Complete()
        {
            var jsonReader = new WatchedMovieObjectJsonReader();

            var traktWatchedMovie = await jsonReader.ReadObjectAsync(JSON_COMPLETE);

            traktWatchedMovie.Should().NotBeNull();
            traktWatchedMovie.Plays.Should().Be(1);
            traktWatchedMovie.LastWatchedAt.Should().Be(DateTime.Parse("2014-09-01T09:10:11.000Z").ToUniversalTime());

            traktWatchedMovie.Movie.Should().NotBeNull();
            traktWatchedMovie.Movie.Title.Should().Be("Star Wars: The Force Awakens");
            traktWatchedMovie.Movie.Year.Should().Be(2015);
            traktWatchedMovie.Movie.Ids.Should().NotBeNull();
            traktWatchedMovie.Movie.Ids.Trakt.Should().Be(94024U);
            traktWatchedMovie.Movie.Ids.Slug.Should().Be("star-wars-the-force-awakens-2015");
            traktWatchedMovie.Movie.Ids.Imdb.Should().Be("tt2488496");
            traktWatchedMovie.Movie.Ids.Tmdb.Should().Be(140607U);
        }

        [Fact]
        public async Task Test_WatchedMovieObjectJsonReader_ReadObject_From_Json_String_Incomplete_1()
        {
            var jsonReader = new WatchedMovieObjectJsonReader();

            var traktWatchedMovie = await jsonReader.ReadObjectAsync(JSON_INCOMPLETE_1);

            traktWatchedMovie.Should().NotBeNull();
            traktWatchedMovie.Plays.Should().BeNull();
            traktWatchedMovie.LastWatchedAt.Should().Be(DateTime.Parse("2014-09-01T09:10:11.000Z").ToUniversalTime());

            traktWatchedMovie.Movie.Should().NotBeNull();
            traktWatchedMovie.Movie.Title.Should().Be("Star Wars: The Force Awakens");
            traktWatchedMovie.Movie.Year.Should().Be(2015);
            traktWatchedMovie.Movie.Ids.Should().NotBeNull();
            traktWatchedMovie.Movie.Ids.Trakt.Should().Be(94024U);
            traktWatchedMovie.Movie.Ids.Slug.Should().Be("star-wars-the-force-awakens-2015");
            traktWatchedMovie.Movie.Ids.Imdb.Should().Be("tt2488496");
            traktWatchedMovie.Movie.Ids.Tmdb.Should().Be(140607U);
        }

        [Fact]
        public async Task Test_WatchedMovieObjectJsonReader_ReadObject_From_Json_String_Incomplete_2()
        {
            var jsonReader = new WatchedMovieObjectJsonReader();

            var traktWatchedMovie = await jsonReader.ReadObjectAsync(JSON_INCOMPLETE_2);

            traktWatchedMovie.Should().NotBeNull();
            traktWatchedMovie.Plays.Should().Be(1);
            traktWatchedMovie.LastWatchedAt.Should().BeNull();

            traktWatchedMovie.Movie.Should().NotBeNull();
            traktWatchedMovie.Movie.Title.Should().Be("Star Wars: The Force Awakens");
            traktWatchedMovie.Movie.Year.Should().Be(2015);
            traktWatchedMovie.Movie.Ids.Should().NotBeNull();
            traktWatchedMovie.Movie.Ids.Trakt.Should().Be(94024U);
            traktWatchedMovie.Movie.Ids.Slug.Should().Be("star-wars-the-force-awakens-2015");
            traktWatchedMovie.Movie.Ids.Imdb.Should().Be("tt2488496");
            traktWatchedMovie.Movie.Ids.Tmdb.Should().Be(140607U);
        }

        [Fact]
        public async Task Test_WatchedMovieObjectJsonReader_ReadObject_From_Json_String_Incomplete_3()
        {
            var jsonReader = new WatchedMovieObjectJsonReader();

            var traktWatchedMovie = await jsonReader.ReadObjectAsync(JSON_INCOMPLETE_3);

            traktWatchedMovie.Should().NotBeNull();
            traktWatchedMovie.Plays.Should().Be(1);
            traktWatchedMovie.LastWatchedAt.Should().Be(DateTime.Parse("2014-09-01T09:10:11.000Z").ToUniversalTime());
            traktWatchedMovie.Movie.Should().BeNull();
        }

        [Fact]
        public async Task Test_WatchedMovieObjectJsonReader_ReadObject_From_Json_String_Incomplete_4()
        {
            var jsonReader = new WatchedMovieObjectJsonReader();

            var traktWatchedMovie = await jsonReader.ReadObjectAsync(JSON_INCOMPLETE_4);

            traktWatchedMovie.Should().NotBeNull();
            traktWatchedMovie.Plays.Should().Be(1);
            traktWatchedMovie.LastWatchedAt.Should().BeNull();
            traktWatchedMovie.Movie.Should().BeNull();
        }

        [Fact]
        public async Task Test_WatchedMovieObjectJsonReader_ReadObject_From_Json_String_Incomplete_5()
        {
            var jsonReader = new WatchedMovieObjectJsonReader();

            var traktWatchedMovie = await jsonReader.ReadObjectAsync(JSON_INCOMPLETE_5);

            traktWatchedMovie.Should().NotBeNull();
            traktWatchedMovie.Plays.Should().BeNull();
            traktWatchedMovie.LastWatchedAt.Should().Be(DateTime.Parse("2014-09-01T09:10:11.000Z").ToUniversalTime());
            traktWatchedMovie.Movie.Should().BeNull();
        }

        [Fact]
        public async Task Test_WatchedMovieObjectJsonReader_ReadObject_From_Json_String_Incomplete_6()
        {
            var jsonReader = new WatchedMovieObjectJsonReader();

            var traktWatchedMovie = await jsonReader.ReadObjectAsync(JSON_INCOMPLETE_6);

            traktWatchedMovie.Should().NotBeNull();
            traktWatchedMovie.Plays.Should().BeNull();
            traktWatchedMovie.LastWatchedAt.Should().BeNull();

            traktWatchedMovie.Movie.Should().NotBeNull();
            traktWatchedMovie.Movie.Title.Should().Be("Star Wars: The Force Awakens");
            traktWatchedMovie.Movie.Year.Should().Be(2015);
            traktWatchedMovie.Movie.Ids.Should().NotBeNull();
            traktWatchedMovie.Movie.Ids.Trakt.Should().Be(94024U);
            traktWatchedMovie.Movie.Ids.Slug.Should().Be("star-wars-the-force-awakens-2015");
            traktWatchedMovie.Movie.Ids.Imdb.Should().Be("tt2488496");
            traktWatchedMovie.Movie.Ids.Tmdb.Should().Be(140607U);
        }

        [Fact]
        public async Task Test_WatchedMovieObjectJsonReader_ReadObject_From_Json_String_Not_Valid_1()
        {
            var jsonReader = new WatchedMovieObjectJsonReader();

            var traktWatchedMovie = await jsonReader.ReadObjectAsync(JSON_NOT_VALID_1);

            traktWatchedMovie.Should().NotBeNull();
            traktWatchedMovie.Plays.Should().BeNull();
            traktWatchedMovie.LastWatchedAt.Should().Be(DateTime.Parse("2014-09-01T09:10:11.000Z").ToUniversalTime());

            traktWatchedMovie.Movie.Should().NotBeNull();
            traktWatchedMovie.Movie.Title.Should().Be("Star Wars: The Force Awakens");
            traktWatchedMovie.Movie.Year.Should().Be(2015);
            traktWatchedMovie.Movie.Ids.Should().NotBeNull();
            traktWatchedMovie.Movie.Ids.Trakt.Should().Be(94024U);
            traktWatchedMovie.Movie.Ids.Slug.Should().Be("star-wars-the-force-awakens-2015");
            traktWatchedMovie.Movie.Ids.Imdb.Should().Be("tt2488496");
            traktWatchedMovie.Movie.Ids.Tmdb.Should().Be(140607U);
        }

        [Fact]
        public async Task Test_WatchedMovieObjectJsonReader_ReadObject_From_Json_String_Not_Valid_2()
        {
            var jsonReader = new WatchedMovieObjectJsonReader();

            var traktWatchedMovie = await jsonReader.ReadObjectAsync(JSON_NOT_VALID_2);

            traktWatchedMovie.Should().NotBeNull();
            traktWatchedMovie.Plays.Should().Be(1);
            traktWatchedMovie.LastWatchedAt.Should().BeNull();

            traktWatchedMovie.Movie.Should().NotBeNull();
            traktWatchedMovie.Movie.Title.Should().Be("Star Wars: The Force Awakens");
            traktWatchedMovie.Movie.Year.Should().Be(2015);
            traktWatchedMovie.Movie.Ids.Should().NotBeNull();
            traktWatchedMovie.Movie.Ids.Trakt.Should().Be(94024U);
            traktWatchedMovie.Movie.Ids.Slug.Should().Be("star-wars-the-force-awakens-2015");
            traktWatchedMovie.Movie.Ids.Imdb.Should().Be("tt2488496");
            traktWatchedMovie.Movie.Ids.Tmdb.Should().Be(140607U);
        }

        [Fact]
        public async Task Test_WatchedMovieObjectJsonReader_ReadObject_From_Json_String_Not_Valid_3()
        {
            var jsonReader = new WatchedMovieObjectJsonReader();

            var traktWatchedMovie = await jsonReader.ReadObjectAsync(JSON_NOT_VALID_3);

            traktWatchedMovie.Should().NotBeNull();
            traktWatchedMovie.Plays.Should().Be(1);
            traktWatchedMovie.LastWatchedAt.Should().Be(DateTime.Parse("2014-09-01T09:10:11.000Z").ToUniversalTime());
            traktWatchedMovie.Movie.Should().BeNull();
        }

        [Fact]
        public async Task Test_WatchedMovieObjectJsonReader_ReadObject_From_Json_String_Not_Valid_4()
        {
            var jsonReader = new WatchedMovieObjectJsonReader();

            var traktWatchedMovie = await jsonReader.ReadObjectAsync(JSON_NOT_VALID_4);

            traktWatchedMovie.Should().NotBeNull();
            traktWatchedMovie.Plays.Should().BeNull();
            traktWatchedMovie.LastWatchedAt.Should().BeNull();
            traktWatchedMovie.Movie.Should().BeNull();
        }

        [Fact]
        public async Task Test_WatchedMovieObjectJsonReader_ReadObject_From_Json_String_Null()
        {
            var jsonReader = new WatchedMovieObjectJsonReader();

            var traktWatchedMovie = await jsonReader.ReadObjectAsync(default(string));
            traktWatchedMovie.Should().BeNull();
        }

        [Fact]
        public async Task Test_WatchedMovieObjectJsonReader_ReadObject_From_Json_String_Empty()
        {
            var jsonReader = new WatchedMovieObjectJsonReader();

            var traktWatchedMovie = await jsonReader.ReadObjectAsync(string.Empty);
            traktWatchedMovie.Should().BeNull();
        }
    }
}
