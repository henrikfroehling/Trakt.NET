namespace TraktNet.Tests.Objects.Get.Movies.Json.Reader
{
    using FluentAssertions;
    using System.Threading.Tasks;
    using Traits;
    using TraktNet.Objects.Get.Movies.Json.Reader;
    using Xunit;

    [Category("Objects.Get.Movies.JsonReader")]
    public partial class TrendingMovieObjectJsonReader_Tests
    {
        [Fact]
        public async Task Test_TrendingMovieObjectJsonReader_ReadObject_From_Json_String_Complete()
        {
            var jsonReader = new TrendingMovieObjectJsonReader();

            var traktTrendingMovie = await jsonReader.ReadObjectAsync(JSON_COMPLETE);

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

        [Fact]
        public async Task Test_TrendingMovieObjectJsonReader_ReadObject_From_Json_String_Incomplete_1()
        {
            var jsonReader = new TrendingMovieObjectJsonReader();

            var traktTrendingMovie = await jsonReader.ReadObjectAsync(JSON_INCOMPLETE_1);

            traktTrendingMovie.Should().NotBeNull();
            traktTrendingMovie.Watchers.Should().Be(35);
            traktTrendingMovie.Movie.Should().BeNull();
        }

        [Fact]
        public async Task Test_TrendingMovieObjectJsonReader_ReadObject_From_Json_String_Incomplete_2()
        {
            var jsonReader = new TrendingMovieObjectJsonReader();

            var traktTrendingMovie = await jsonReader.ReadObjectAsync(JSON_INCOMPLETE_2);

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

        [Fact]
        public async Task Test_TrendingMovieObjectJsonReader_ReadObject_From_Json_String_Not_Valid_1()
        {
            var jsonReader = new TrendingMovieObjectJsonReader();

            var traktTrendingMovie = await jsonReader.ReadObjectAsync(JSON_NOT_VALID_1);

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

        [Fact]
        public async Task Test_TrendingMovieObjectJsonReader_ReadObject_From_Json_String_Not_Valid_2()
        {
            var jsonReader = new TrendingMovieObjectJsonReader();

            var traktTrendingMovie = await jsonReader.ReadObjectAsync(JSON_NOT_VALID_2);

            traktTrendingMovie.Should().NotBeNull();
            traktTrendingMovie.Watchers.Should().Be(35);
            traktTrendingMovie.Movie.Should().BeNull();
        }

        [Fact]
        public async Task Test_TrendingMovieObjectJsonReader_ReadObject_From_Json_String_Not_Valid_3()
        {
            var jsonReader = new TrendingMovieObjectJsonReader();

            var traktTrendingMovie = await jsonReader.ReadObjectAsync(JSON_NOT_VALID_3);

            traktTrendingMovie.Should().NotBeNull();
            traktTrendingMovie.Watchers.Should().BeNull();
            traktTrendingMovie.Movie.Should().BeNull();
        }

        [Fact]
        public async Task Test_TrendingMovieObjectJsonReader_ReadObject_From_Json_String_Null()
        {
            var jsonReader = new TrendingMovieObjectJsonReader();

            var traktTrendingMovie = await jsonReader.ReadObjectAsync(default(string));
            traktTrendingMovie.Should().BeNull();
        }

        [Fact]
        public async Task Test_TrendingMovieObjectJsonReader_ReadObject_From_Json_String_Empty()
        {
            var jsonReader = new TrendingMovieObjectJsonReader();

            var traktTrendingMovie = await jsonReader.ReadObjectAsync(string.Empty);
            traktTrendingMovie.Should().BeNull();
        }
    }
}
