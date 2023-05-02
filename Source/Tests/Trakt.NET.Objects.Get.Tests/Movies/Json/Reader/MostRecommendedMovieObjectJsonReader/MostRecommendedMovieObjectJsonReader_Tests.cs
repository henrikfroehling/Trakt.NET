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
    public partial class MostRecommendedMovieObjectJsonReader_Tests
    {
        [Fact]
        public async Task Test_MostRecommendedMovieObjectJsonReader_ReadObject_From_JsonReader_Complete()
        {
            var traktJsonReader = new MostRecommendedMovieObjectJsonReader();

            using (var reader = new StringReader(JSON_COMPLETE))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktMostRecommendedMovie = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktMostRecommendedMovie.Should().NotBeNull();
                traktMostRecommendedMovie.UserCount.Should().Be(76254);
                traktMostRecommendedMovie.Movie.Should().NotBeNull();
                traktMostRecommendedMovie.Movie.Title.Should().Be("Star Wars: The Force Awakens");
                traktMostRecommendedMovie.Movie.Year.Should().Be(2015);
                traktMostRecommendedMovie.Movie.Ids.Should().NotBeNull();
                traktMostRecommendedMovie.Movie.Ids.Trakt.Should().Be(94024U);
                traktMostRecommendedMovie.Movie.Ids.Slug.Should().Be("star-wars-the-force-awakens-2015");
                traktMostRecommendedMovie.Movie.Ids.Imdb.Should().Be("tt2488496");
                traktMostRecommendedMovie.Movie.Ids.Tmdb.Should().Be(140607U);
            }
        }

        [Fact]
        public async Task Test_MostRecommendedMovieObjectJsonReader_ReadObject_From_JsonReader_Incomplete_1()
        {
            var traktJsonReader = new MostRecommendedMovieObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_1))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktMostRecommendedMovie = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktMostRecommendedMovie.Should().NotBeNull();
                traktMostRecommendedMovie.UserCount.Should().Be(76254);
                traktMostRecommendedMovie.Movie.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_MostRecommendedMovieObjectJsonReader_ReadObject_From_JsonReader_Incomplete_2()
        {
            var traktJsonReader = new MostRecommendedMovieObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_2))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktMostRecommendedMovie = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktMostRecommendedMovie.Should().NotBeNull();
                traktMostRecommendedMovie.UserCount.Should().BeNull();
                traktMostRecommendedMovie.Movie.Should().NotBeNull();
                traktMostRecommendedMovie.Movie.Title.Should().Be("Star Wars: The Force Awakens");
                traktMostRecommendedMovie.Movie.Year.Should().Be(2015);
                traktMostRecommendedMovie.Movie.Ids.Should().NotBeNull();
                traktMostRecommendedMovie.Movie.Ids.Trakt.Should().Be(94024U);
                traktMostRecommendedMovie.Movie.Ids.Slug.Should().Be("star-wars-the-force-awakens-2015");
                traktMostRecommendedMovie.Movie.Ids.Imdb.Should().Be("tt2488496");
                traktMostRecommendedMovie.Movie.Ids.Tmdb.Should().Be(140607U);
            }
        }

        [Fact]
        public async Task Test_MostRecommendedMovieObjectJsonReader_ReadObject_From_JsonReader_Not_Valid_1()
        {
            var traktJsonReader = new MostRecommendedMovieObjectJsonReader();

            using (var reader = new StringReader(JSON_NOT_VALID_1))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktMostRecommendedMovie = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktMostRecommendedMovie.Should().NotBeNull();
                traktMostRecommendedMovie.UserCount.Should().BeNull();
                traktMostRecommendedMovie.Movie.Should().NotBeNull();
                traktMostRecommendedMovie.Movie.Title.Should().Be("Star Wars: The Force Awakens");
                traktMostRecommendedMovie.Movie.Year.Should().Be(2015);
                traktMostRecommendedMovie.Movie.Ids.Should().NotBeNull();
                traktMostRecommendedMovie.Movie.Ids.Trakt.Should().Be(94024U);
                traktMostRecommendedMovie.Movie.Ids.Slug.Should().Be("star-wars-the-force-awakens-2015");
                traktMostRecommendedMovie.Movie.Ids.Imdb.Should().Be("tt2488496");
                traktMostRecommendedMovie.Movie.Ids.Tmdb.Should().Be(140607U);
            }
        }

        [Fact]
        public async Task Test_MostRecommendedMovieObjectJsonReader_ReadObject_From_JsonReader_Not_Valid_2()
        {
            var traktJsonReader = new MostRecommendedMovieObjectJsonReader();

            using (var reader = new StringReader(JSON_NOT_VALID_2))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktMostRecommendedMovie = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktMostRecommendedMovie.Should().NotBeNull();
                traktMostRecommendedMovie.UserCount.Should().Be(76254);
                traktMostRecommendedMovie.Movie.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_MostRecommendedMovieObjectJsonReader_ReadObject_From_JsonReader_Not_Valid_3()
        {
            var traktJsonReader = new MostRecommendedMovieObjectJsonReader();

            using (var reader = new StringReader(JSON_NOT_VALID_3))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktMostRecommendedMovie = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktMostRecommendedMovie.Should().NotBeNull();
                traktMostRecommendedMovie.UserCount.Should().BeNull();
                traktMostRecommendedMovie.Movie.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_MostRecommendedMovieObjectJsonReader_ReadObject_From_JsonReader_Null()
        {
            var traktJsonReader = new MostRecommendedMovieObjectJsonReader();
            Func<Task<ITraktMostRecommendedMovie>> traktMostRecommendedMovie = () => traktJsonReader.ReadObjectAsync(default(JsonTextReader));
            await traktMostRecommendedMovie.Should().ThrowAsync<ArgumentNullException>();
        }

        [Fact]
        public async Task Test_MostRecommendedMovieObjectJsonReader_ReadObject_From_JsonReader_Empty()
        {
            var traktJsonReader = new MostRecommendedMovieObjectJsonReader();
            using var reader = new StringReader(string.Empty);
            using var jsonReader = new JsonTextReader(reader);
            var traktMostRecommendedMovie = await traktJsonReader.ReadObjectAsync(jsonReader);
            traktMostRecommendedMovie.Should().BeNull();
        }
    }
}
