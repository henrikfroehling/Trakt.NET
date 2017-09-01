namespace TraktApiSharp.Tests.Objects.Get.Movies.JsonReader
{
    using FluentAssertions;
    using Newtonsoft.Json;
    using System.IO;
    using System.Threading.Tasks;
    using Traits;
    using TraktApiSharp.Objects.Get.Movies.JsonReader;
    using Xunit;

    [Category("Objects.Get.Movies.JsonReader")]
    public partial class TrendingMovieObjectJsonReader_Tests
    {
        [Fact]
        public async Task Test_TrendingMovieObjectJsonReader_ReadObject_From_JsonReader_Complete()
        {
            var traktJsonReader = new TrendingMovieObjectJsonReader();

            using (var reader = new StringReader(JSON_COMPLETE))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktTrendingMovie = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktTrendingMovie.Should().NotBeNull();
                traktTrendingMovie.Watchers.Should().Be(35);
                traktTrendingMovie.Movie.Should().NotBeNull();
                traktTrendingMovie.Movie.Title.Should().Be("Star Wars: The Force Awakens");
                traktTrendingMovie.Movie.Year.Should().Be(2015);
                traktTrendingMovie.Movie.Ids.Should().NotBeNull();
                traktTrendingMovie.Movie.Ids.Trakt.Should().Be(94024U);
                traktTrendingMovie.Movie.Ids.Slug.Should().Be("star-wars-the-force-awakens-2015");
                traktTrendingMovie.Movie.Ids.Imdb.Should().Be("tt2488496");
                traktTrendingMovie.Movie.Ids.Tmdb.Should().Be(140607U);
            }
        }

        [Fact]
        public async Task Test_TrendingMovieObjectJsonReader_ReadObject_From_JsonReader_Incomplete_1()
        {
            var traktJsonReader = new TrendingMovieObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_1))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktTrendingMovie = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktTrendingMovie.Should().NotBeNull();
                traktTrendingMovie.Watchers.Should().Be(35);
                traktTrendingMovie.Movie.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_TrendingMovieObjectJsonReader_ReadObject_From_JsonReader_Incomplete_2()
        {
            var traktJsonReader = new TrendingMovieObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_2))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktTrendingMovie = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktTrendingMovie.Should().NotBeNull();
                traktTrendingMovie.Watchers.Should().BeNull();
                traktTrendingMovie.Movie.Should().NotBeNull();
                traktTrendingMovie.Movie.Title.Should().Be("Star Wars: The Force Awakens");
                traktTrendingMovie.Movie.Year.Should().Be(2015);
                traktTrendingMovie.Movie.Ids.Should().NotBeNull();
                traktTrendingMovie.Movie.Ids.Trakt.Should().Be(94024U);
                traktTrendingMovie.Movie.Ids.Slug.Should().Be("star-wars-the-force-awakens-2015");
                traktTrendingMovie.Movie.Ids.Imdb.Should().Be("tt2488496");
                traktTrendingMovie.Movie.Ids.Tmdb.Should().Be(140607U);
            }
        }

        [Fact]
        public async Task Test_TrendingMovieObjectJsonReader_ReadObject_From_JsonReader_Not_Valid_1()
        {
            var traktJsonReader = new TrendingMovieObjectJsonReader();

            using (var reader = new StringReader(JSON_NOT_VALID_1))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktTrendingMovie = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktTrendingMovie.Should().NotBeNull();
                traktTrendingMovie.Watchers.Should().BeNull();
                traktTrendingMovie.Movie.Should().NotBeNull();
                traktTrendingMovie.Movie.Title.Should().Be("Star Wars: The Force Awakens");
                traktTrendingMovie.Movie.Year.Should().Be(2015);
                traktTrendingMovie.Movie.Ids.Should().NotBeNull();
                traktTrendingMovie.Movie.Ids.Trakt.Should().Be(94024U);
                traktTrendingMovie.Movie.Ids.Slug.Should().Be("star-wars-the-force-awakens-2015");
                traktTrendingMovie.Movie.Ids.Imdb.Should().Be("tt2488496");
                traktTrendingMovie.Movie.Ids.Tmdb.Should().Be(140607U);
            }
        }

        [Fact]
        public async Task Test_TrendingMovieObjectJsonReader_ReadObject_From_JsonReader_Not_Valid_2()
        {
            var traktJsonReader = new TrendingMovieObjectJsonReader();

            using (var reader = new StringReader(JSON_NOT_VALID_2))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktTrendingMovie = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktTrendingMovie.Should().NotBeNull();
                traktTrendingMovie.Watchers.Should().Be(35);
                traktTrendingMovie.Movie.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_TrendingMovieObjectJsonReader_ReadObject_From_JsonReader_Not_Valid_3()
        {
            var traktJsonReader = new TrendingMovieObjectJsonReader();

            using (var reader = new StringReader(JSON_NOT_VALID_3))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktTrendingMovie = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktTrendingMovie.Should().NotBeNull();
                traktTrendingMovie.Watchers.Should().BeNull();
                traktTrendingMovie.Movie.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_TrendingMovieObjectJsonReader_ReadObject_From_JsonReader_Null()
        {
            var traktJsonReader = new TrendingMovieObjectJsonReader();

            var traktTrendingMovie = await traktJsonReader.ReadObjectAsync(default(JsonTextReader));
            traktTrendingMovie.Should().BeNull();
        }

        [Fact]
        public async Task Test_TrendingMovieObjectJsonReader_ReadObject_From_JsonReader_Empty()
        {
            var traktJsonReader = new TrendingMovieObjectJsonReader();

            using (var reader = new StringReader(string.Empty))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktTrendingMovie = await traktJsonReader.ReadObjectAsync(jsonReader);
                traktTrendingMovie.Should().BeNull();
            }
        }
    }
}
