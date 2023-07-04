namespace TraktNet.Objects.Get.Tests.Movies.Json.Reader
{
    using FluentAssertions;
    using Newtonsoft.Json;
    using System;
    using System.IO;
    using System.Threading.Tasks;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Objects.Get.Movies;
    using TraktNet.Objects.Get.Movies.Json.Reader;
    using Xunit;

    [TestCategory("Objects.Get.Movies.JsonReader")]
    public partial class MostFavoritedMovieObjectJsonReader_Tests
    {
        [Fact]
        public async Task Test_MostFavoritedMovieObjectJsonReader_ReadObject_From_JsonReader_Complete()
        {
            var traktJsonReader = new MostFavoritedMovieObjectJsonReader();

            using (var reader = new StringReader(JSON_COMPLETE))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktMostFavoritedMovie = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktMostFavoritedMovie.Should().NotBeNull();
                traktMostFavoritedMovie.UserCount.Should().Be(76254);
                traktMostFavoritedMovie.Movie.Should().NotBeNull();
                traktMostFavoritedMovie.Movie.Title.Should().Be("Star Wars: The Force Awakens");
                traktMostFavoritedMovie.Movie.Year.Should().Be(2015);
                traktMostFavoritedMovie.Movie.Ids.Should().NotBeNull();
                traktMostFavoritedMovie.Movie.Ids.Trakt.Should().Be(94024U);
                traktMostFavoritedMovie.Movie.Ids.Slug.Should().Be("star-wars-the-force-awakens-2015");
                traktMostFavoritedMovie.Movie.Ids.Imdb.Should().Be("tt2488496");
                traktMostFavoritedMovie.Movie.Ids.Tmdb.Should().Be(140607U);
            }
        }

        [Fact]
        public async Task Test_MostFavoritedMovieObjectJsonReader_ReadObject_From_JsonReader_Incomplete_1()
        {
            var traktJsonReader = new MostFavoritedMovieObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_1))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktMostFavoritedMovie = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktMostFavoritedMovie.Should().NotBeNull();
                traktMostFavoritedMovie.UserCount.Should().Be(76254);
                traktMostFavoritedMovie.Movie.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_MostFavoritedMovieObjectJsonReader_ReadObject_From_JsonReader_Incomplete_2()
        {
            var traktJsonReader = new MostFavoritedMovieObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_2))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktMostFavoritedMovie = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktMostFavoritedMovie.Should().NotBeNull();
                traktMostFavoritedMovie.UserCount.Should().BeNull();
                traktMostFavoritedMovie.Movie.Should().NotBeNull();
                traktMostFavoritedMovie.Movie.Title.Should().Be("Star Wars: The Force Awakens");
                traktMostFavoritedMovie.Movie.Year.Should().Be(2015);
                traktMostFavoritedMovie.Movie.Ids.Should().NotBeNull();
                traktMostFavoritedMovie.Movie.Ids.Trakt.Should().Be(94024U);
                traktMostFavoritedMovie.Movie.Ids.Slug.Should().Be("star-wars-the-force-awakens-2015");
                traktMostFavoritedMovie.Movie.Ids.Imdb.Should().Be("tt2488496");
                traktMostFavoritedMovie.Movie.Ids.Tmdb.Should().Be(140607U);
            }
        }

        [Fact]
        public async Task Test_MostFavoritedMovieObjectJsonReader_ReadObject_From_JsonReader_Not_Valid_1()
        {
            var traktJsonReader = new MostFavoritedMovieObjectJsonReader();

            using (var reader = new StringReader(JSON_NOT_VALID_1))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktMostFavoritedMovie = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktMostFavoritedMovie.Should().NotBeNull();
                traktMostFavoritedMovie.UserCount.Should().BeNull();
                traktMostFavoritedMovie.Movie.Should().NotBeNull();
                traktMostFavoritedMovie.Movie.Title.Should().Be("Star Wars: The Force Awakens");
                traktMostFavoritedMovie.Movie.Year.Should().Be(2015);
                traktMostFavoritedMovie.Movie.Ids.Should().NotBeNull();
                traktMostFavoritedMovie.Movie.Ids.Trakt.Should().Be(94024U);
                traktMostFavoritedMovie.Movie.Ids.Slug.Should().Be("star-wars-the-force-awakens-2015");
                traktMostFavoritedMovie.Movie.Ids.Imdb.Should().Be("tt2488496");
                traktMostFavoritedMovie.Movie.Ids.Tmdb.Should().Be(140607U);
            }
        }

        [Fact]
        public async Task Test_MostFavoritedMovieObjectJsonReader_ReadObject_From_JsonReader_Not_Valid_2()
        {
            var traktJsonReader = new MostFavoritedMovieObjectJsonReader();

            using (var reader = new StringReader(JSON_NOT_VALID_2))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktMostFavoritedMovie = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktMostFavoritedMovie.Should().NotBeNull();
                traktMostFavoritedMovie.UserCount.Should().Be(76254);
                traktMostFavoritedMovie.Movie.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_MostFavoritedMovieObjectJsonReader_ReadObject_From_JsonReader_Not_Valid_3()
        {
            var traktJsonReader = new MostFavoritedMovieObjectJsonReader();

            using (var reader = new StringReader(JSON_NOT_VALID_3))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktMostFavoritedMovie = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktMostFavoritedMovie.Should().NotBeNull();
                traktMostFavoritedMovie.UserCount.Should().BeNull();
                traktMostFavoritedMovie.Movie.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_MostFavoritedMovieObjectJsonReader_ReadObject_From_JsonReader_Null()
        {
            var traktJsonReader = new MostFavoritedMovieObjectJsonReader();
            Func<Task<ITraktMostFavoritedMovie>> traktMostFavoritedMovie = () => traktJsonReader.ReadObjectAsync(default(JsonTextReader));
            await traktMostFavoritedMovie.Should().ThrowAsync<ArgumentNullException>();
        }

        [Fact]
        public async Task Test_MostFavoritedMovieObjectJsonReader_ReadObject_From_JsonReader_Empty()
        {
            var traktJsonReader = new MostFavoritedMovieObjectJsonReader();
            using var reader = new StringReader(string.Empty);
            using var jsonReader = new JsonTextReader(reader);
            var traktMostFavoritedMovie = await traktJsonReader.ReadObjectAsync(jsonReader);
            traktMostFavoritedMovie.Should().BeNull();
        }
    }
}
