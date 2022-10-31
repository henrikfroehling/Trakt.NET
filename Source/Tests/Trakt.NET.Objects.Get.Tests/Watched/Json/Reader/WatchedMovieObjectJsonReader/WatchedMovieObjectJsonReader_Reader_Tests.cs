namespace TraktNet.Objects.Get.Tests.Watched.Json.Reader
{
    using FluentAssertions;
    using Newtonsoft.Json;
    using System;
    using System.IO;
    using System.Threading.Tasks;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Objects.Get.Watched;
    using TraktNet.Objects.Get.Watched.Json.Reader;
    using Xunit;

    [TestCategory("Objects.Get.Watched.JsonReader")]
    public partial class WatchedMovieObjectJsonReader_Tests
    {
        [Fact]
        public async Task Test_WatchedMovieObjectJsonReader_ReadObject_From_JsonReader_Complete()
        {
            var traktJsonReader = new WatchedMovieObjectJsonReader();

            using (var reader = new StringReader(JSON_COMPLETE))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktWatchedMovie = await traktJsonReader.ReadObjectAsync(jsonReader);

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
        }

        [Fact]
        public async Task Test_WatchedMovieObjectJsonReader_ReadObject_From_JsonReader_Incomplete_1()
        {
            var traktJsonReader = new WatchedMovieObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_1))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktWatchedMovie = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktWatchedMovie.Should().NotBeNull();
                traktWatchedMovie.Plays.Should().BeNull();
                traktWatchedMovie.LastWatchedAt.Should().Be(DateTime.Parse("2014-09-01T09:10:11.000Z").ToUniversalTime());
                traktWatchedMovie.LastUpdatedAt.Should().Be(DateTime.Parse("2014-09-01T09:10:11.000Z").ToUniversalTime());

                traktWatchedMovie.Movie.Should().NotBeNull();
                traktWatchedMovie.Movie.Title.Should().Be("Star Wars: The Force Awakens");
                traktWatchedMovie.Movie.Year.Should().Be(2015);
                traktWatchedMovie.Movie.Ids.Should().NotBeNull();
                traktWatchedMovie.Movie.Ids.Trakt.Should().Be(94024U);
                traktWatchedMovie.Movie.Ids.Slug.Should().Be("star-wars-the-force-awakens-2015");
                traktWatchedMovie.Movie.Ids.Imdb.Should().Be("tt2488496");
                traktWatchedMovie.Movie.Ids.Tmdb.Should().Be(140607U);
            }
        }

        [Fact]
        public async Task Test_WatchedMovieObjectJsonReader_ReadObject_From_JsonReader_Incomplete_2()
        {
            var traktJsonReader = new WatchedMovieObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_2))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktWatchedMovie = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktWatchedMovie.Should().NotBeNull();
                traktWatchedMovie.Plays.Should().Be(1);
                traktWatchedMovie.LastWatchedAt.Should().BeNull();
                traktWatchedMovie.LastUpdatedAt.Should().Be(DateTime.Parse("2014-09-01T09:10:11.000Z").ToUniversalTime());

                traktWatchedMovie.Movie.Should().NotBeNull();
                traktWatchedMovie.Movie.Title.Should().Be("Star Wars: The Force Awakens");
                traktWatchedMovie.Movie.Year.Should().Be(2015);
                traktWatchedMovie.Movie.Ids.Should().NotBeNull();
                traktWatchedMovie.Movie.Ids.Trakt.Should().Be(94024U);
                traktWatchedMovie.Movie.Ids.Slug.Should().Be("star-wars-the-force-awakens-2015");
                traktWatchedMovie.Movie.Ids.Imdb.Should().Be("tt2488496");
                traktWatchedMovie.Movie.Ids.Tmdb.Should().Be(140607U);
            }
        }

        [Fact]
        public async Task Test_WatchedMovieObjectJsonReader_ReadObject_From_JsonReader_Incomplete_3()
        {
            var traktJsonReader = new WatchedMovieObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_3))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktWatchedMovie = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktWatchedMovie.Should().NotBeNull();
                traktWatchedMovie.Plays.Should().Be(1);
                traktWatchedMovie.LastWatchedAt.Should().Be(DateTime.Parse("2014-09-01T09:10:11.000Z").ToUniversalTime());
                traktWatchedMovie.LastUpdatedAt.Should().BeNull();

                traktWatchedMovie.Movie.Should().NotBeNull();
                traktWatchedMovie.Movie.Title.Should().Be("Star Wars: The Force Awakens");
                traktWatchedMovie.Movie.Year.Should().Be(2015);
                traktWatchedMovie.Movie.Ids.Should().NotBeNull();
                traktWatchedMovie.Movie.Ids.Trakt.Should().Be(94024U);
                traktWatchedMovie.Movie.Ids.Slug.Should().Be("star-wars-the-force-awakens-2015");
                traktWatchedMovie.Movie.Ids.Imdb.Should().Be("tt2488496");
                traktWatchedMovie.Movie.Ids.Tmdb.Should().Be(140607U);
            }
        }

        [Fact]
        public async Task Test_WatchedMovieObjectJsonReader_ReadObject_From_JsonReader_Incomplete_4()
        {
            var traktJsonReader = new WatchedMovieObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_4))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktWatchedMovie = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktWatchedMovie.Should().NotBeNull();
                traktWatchedMovie.Plays.Should().Be(1);
                traktWatchedMovie.LastWatchedAt.Should().Be(DateTime.Parse("2014-09-01T09:10:11.000Z").ToUniversalTime());
                traktWatchedMovie.LastUpdatedAt.Should().Be(DateTime.Parse("2014-09-01T09:10:11.000Z").ToUniversalTime());
                traktWatchedMovie.Movie.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_WatchedMovieObjectJsonReader_ReadObject_From_JsonReader_Incomplete_5()
        {
            var traktJsonReader = new WatchedMovieObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_5))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktWatchedMovie = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktWatchedMovie.Should().NotBeNull();
                traktWatchedMovie.Plays.Should().Be(1);
                traktWatchedMovie.LastWatchedAt.Should().BeNull();
                traktWatchedMovie.LastUpdatedAt.Should().BeNull();
                traktWatchedMovie.Movie.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_WatchedMovieObjectJsonReader_ReadObject_From_JsonReader_Incomplete_6()
        {
            var traktJsonReader = new WatchedMovieObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_6))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktWatchedMovie = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktWatchedMovie.Should().NotBeNull();
                traktWatchedMovie.Plays.Should().BeNull();
                traktWatchedMovie.LastWatchedAt.Should().Be(DateTime.Parse("2014-09-01T09:10:11.000Z").ToUniversalTime());
                traktWatchedMovie.LastUpdatedAt.Should().BeNull();
                traktWatchedMovie.Movie.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_WatchedMovieObjectJsonReader_ReadObject_From_JsonReader_Incomplete_7()
        {
            var traktJsonReader = new WatchedMovieObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_7))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktWatchedMovie = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktWatchedMovie.Should().NotBeNull();
                traktWatchedMovie.Plays.Should().BeNull();
                traktWatchedMovie.LastWatchedAt.Should().BeNull();
                traktWatchedMovie.LastUpdatedAt.Should().Be(DateTime.Parse("2014-09-01T09:10:11.000Z").ToUniversalTime());
                traktWatchedMovie.Movie.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_WatchedMovieObjectJsonReader_ReadObject_From_JsonReader_Incomplete_8()
        {
            var traktJsonReader = new WatchedMovieObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_8))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktWatchedMovie = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktWatchedMovie.Should().NotBeNull();
                traktWatchedMovie.Plays.Should().BeNull();
                traktWatchedMovie.LastWatchedAt.Should().BeNull();
                traktWatchedMovie.LastUpdatedAt.Should().BeNull();

                traktWatchedMovie.Movie.Should().NotBeNull();
                traktWatchedMovie.Movie.Title.Should().Be("Star Wars: The Force Awakens");
                traktWatchedMovie.Movie.Year.Should().Be(2015);
                traktWatchedMovie.Movie.Ids.Should().NotBeNull();
                traktWatchedMovie.Movie.Ids.Trakt.Should().Be(94024U);
                traktWatchedMovie.Movie.Ids.Slug.Should().Be("star-wars-the-force-awakens-2015");
                traktWatchedMovie.Movie.Ids.Imdb.Should().Be("tt2488496");
                traktWatchedMovie.Movie.Ids.Tmdb.Should().Be(140607U);
            }
        }

        [Fact]
        public async Task Test_WatchedMovieObjectJsonReader_ReadObject_From_JsonReader_Not_Valid_1()
        {
            var traktJsonReader = new WatchedMovieObjectJsonReader();

            using (var reader = new StringReader(JSON_NOT_VALID_1))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktWatchedMovie = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktWatchedMovie.Should().NotBeNull();
                traktWatchedMovie.Plays.Should().BeNull();
                traktWatchedMovie.LastWatchedAt.Should().Be(DateTime.Parse("2014-09-01T09:10:11.000Z").ToUniversalTime());
                traktWatchedMovie.LastUpdatedAt.Should().Be(DateTime.Parse("2014-09-01T09:10:11.000Z").ToUniversalTime());

                traktWatchedMovie.Movie.Should().NotBeNull();
                traktWatchedMovie.Movie.Title.Should().Be("Star Wars: The Force Awakens");
                traktWatchedMovie.Movie.Year.Should().Be(2015);
                traktWatchedMovie.Movie.Ids.Should().NotBeNull();
                traktWatchedMovie.Movie.Ids.Trakt.Should().Be(94024U);
                traktWatchedMovie.Movie.Ids.Slug.Should().Be("star-wars-the-force-awakens-2015");
                traktWatchedMovie.Movie.Ids.Imdb.Should().Be("tt2488496");
                traktWatchedMovie.Movie.Ids.Tmdb.Should().Be(140607U);
            }
        }

        [Fact]
        public async Task Test_WatchedMovieObjectJsonReader_ReadObject_From_JsonReader_Not_Valid_2()
        {
            var traktJsonReader = new WatchedMovieObjectJsonReader();

            using (var reader = new StringReader(JSON_NOT_VALID_2))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktWatchedMovie = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktWatchedMovie.Should().NotBeNull();
                traktWatchedMovie.Plays.Should().Be(1);
                traktWatchedMovie.LastWatchedAt.Should().BeNull();
                traktWatchedMovie.LastUpdatedAt.Should().Be(DateTime.Parse("2014-09-01T09:10:11.000Z").ToUniversalTime());

                traktWatchedMovie.Movie.Should().NotBeNull();
                traktWatchedMovie.Movie.Title.Should().Be("Star Wars: The Force Awakens");
                traktWatchedMovie.Movie.Year.Should().Be(2015);
                traktWatchedMovie.Movie.Ids.Should().NotBeNull();
                traktWatchedMovie.Movie.Ids.Trakt.Should().Be(94024U);
                traktWatchedMovie.Movie.Ids.Slug.Should().Be("star-wars-the-force-awakens-2015");
                traktWatchedMovie.Movie.Ids.Imdb.Should().Be("tt2488496");
                traktWatchedMovie.Movie.Ids.Tmdb.Should().Be(140607U);
            }
        }

        [Fact]
        public async Task Test_WatchedMovieObjectJsonReader_ReadObject_From_JsonReader_Not_Valid_3()
        {
            var traktJsonReader = new WatchedMovieObjectJsonReader();

            using (var reader = new StringReader(JSON_NOT_VALID_3))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktWatchedMovie = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktWatchedMovie.Should().NotBeNull();
                traktWatchedMovie.Plays.Should().Be(1);
                traktWatchedMovie.LastWatchedAt.Should().Be(DateTime.Parse("2014-09-01T09:10:11.000Z").ToUniversalTime());
                traktWatchedMovie.LastUpdatedAt.Should().BeNull();

                traktWatchedMovie.Movie.Should().NotBeNull();
                traktWatchedMovie.Movie.Title.Should().Be("Star Wars: The Force Awakens");
                traktWatchedMovie.Movie.Year.Should().Be(2015);
                traktWatchedMovie.Movie.Ids.Should().NotBeNull();
                traktWatchedMovie.Movie.Ids.Trakt.Should().Be(94024U);
                traktWatchedMovie.Movie.Ids.Slug.Should().Be("star-wars-the-force-awakens-2015");
                traktWatchedMovie.Movie.Ids.Imdb.Should().Be("tt2488496");
                traktWatchedMovie.Movie.Ids.Tmdb.Should().Be(140607U);
            }
        }

        [Fact]
        public async Task Test_WatchedMovieObjectJsonReader_ReadObject_From_JsonReader_Not_Valid_4()
        {
            var traktJsonReader = new WatchedMovieObjectJsonReader();

            using (var reader = new StringReader(JSON_NOT_VALID_4))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktWatchedMovie = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktWatchedMovie.Should().NotBeNull();
                traktWatchedMovie.Plays.Should().Be(1);
                traktWatchedMovie.LastWatchedAt.Should().Be(DateTime.Parse("2014-09-01T09:10:11.000Z").ToUniversalTime());
                traktWatchedMovie.LastUpdatedAt.Should().Be(DateTime.Parse("2014-09-01T09:10:11.000Z").ToUniversalTime());
                traktWatchedMovie.Movie.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_WatchedMovieObjectJsonReader_ReadObject_From_JsonReader_Not_Valid_5()
        {
            var traktJsonReader = new WatchedMovieObjectJsonReader();

            using (var reader = new StringReader(JSON_NOT_VALID_5))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktWatchedMovie = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktWatchedMovie.Should().NotBeNull();
                traktWatchedMovie.Plays.Should().BeNull();
                traktWatchedMovie.LastWatchedAt.Should().BeNull();
                traktWatchedMovie.LastUpdatedAt.Should().BeNull();
                traktWatchedMovie.Movie.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_WatchedMovieObjectJsonReader_ReadObject_From_JsonReader_Null()
        {
            var traktJsonReader = new WatchedMovieObjectJsonReader();
            Func<Task<ITraktWatchedMovie>> traktWatchedMovie = () => traktJsonReader.ReadObjectAsync(default(JsonTextReader));
            await traktWatchedMovie.Should().ThrowAsync<ArgumentNullException>();
        }

        [Fact]
        public async Task Test_WatchedMovieObjectJsonReader_ReadObject_From_JsonReader_Empty()
        {
            var traktJsonReader = new WatchedMovieObjectJsonReader();

            using (var reader = new StringReader(string.Empty))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktWatchedMovie = await traktJsonReader.ReadObjectAsync(jsonReader);
                traktWatchedMovie.Should().BeNull();
            }
        }
    }
}
