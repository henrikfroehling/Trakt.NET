namespace TraktNet.Tests.Objects.Get.Movies.Json.Reader
{
    using FluentAssertions;
    using System.IO;
    using System.Threading.Tasks;
    using TestUtils;
    using Traits;
    using TraktNet.Objects.Get.Movies.Json.Reader;
    using Xunit;

    [Category("Objects.Get.Movies.JsonReader")]
    public partial class TrendingMovieObjectJsonReader_Tests
    {
        [Fact]
        public async Task Test_TrendingMovieObjectJsonReader_ReadObject_From_Stream_Complete()
        {
            var traktJsonReader = new TrendingMovieObjectJsonReader();

            using (var stream = JSON_COMPLETE.ToStream())
            {
                var traktTrendingMovie = await traktJsonReader.ReadObjectAsync(stream);

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
        public async Task Test_TrendingMovieObjectJsonReader_ReadObject_From_Stream_Incomplete_1()
        {
            var traktJsonReader = new TrendingMovieObjectJsonReader();

            using (var stream = JSON_INCOMPLETE_1.ToStream())
            {
                var traktTrendingMovie = await traktJsonReader.ReadObjectAsync(stream);

                traktTrendingMovie.Should().NotBeNull();
                traktTrendingMovie.Watchers.Should().Be(35);
                traktTrendingMovie.Movie.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_TrendingMovieObjectJsonReader_ReadObject_From_Stream_Incomplete_2()
        {
            var traktJsonReader = new TrendingMovieObjectJsonReader();

            using (var stream = JSON_INCOMPLETE_2.ToStream())
            {
                var traktTrendingMovie = await traktJsonReader.ReadObjectAsync(stream);

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
        public async Task Test_TrendingMovieObjectJsonReader_ReadObject_From_Stream_Not_Valid_1()
        {
            var traktJsonReader = new TrendingMovieObjectJsonReader();

            using (var stream = JSON_NOT_VALID_1.ToStream())
            {
                var traktTrendingMovie = await traktJsonReader.ReadObjectAsync(stream);

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
        public async Task Test_TrendingMovieObjectJsonReader_ReadObject_From_Stream_Not_Valid_2()
        {
            var traktJsonReader = new TrendingMovieObjectJsonReader();

            using (var stream = JSON_NOT_VALID_2.ToStream())
            {
                var traktTrendingMovie = await traktJsonReader.ReadObjectAsync(stream);

                traktTrendingMovie.Should().NotBeNull();
                traktTrendingMovie.Watchers.Should().Be(35);
                traktTrendingMovie.Movie.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_TrendingMovieObjectJsonReader_ReadObject_From_Stream_Not_Valid_3()
        {
            var traktJsonReader = new TrendingMovieObjectJsonReader();

            using (var stream = JSON_NOT_VALID_3.ToStream())
            {
                var traktTrendingMovie = await traktJsonReader.ReadObjectAsync(stream);

                traktTrendingMovie.Should().NotBeNull();
                traktTrendingMovie.Watchers.Should().BeNull();
                traktTrendingMovie.Movie.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_TrendingMovieObjectJsonReader_ReadObject_From_Stream_Null()
        {
            var traktJsonReader = new TrendingMovieObjectJsonReader();

            var traktTrendingMovie = await traktJsonReader.ReadObjectAsync(default(Stream));
            traktTrendingMovie.Should().BeNull();
        }

        [Fact]
        public async Task Test_TrendingMovieObjectJsonReader_ReadObject_From_Stream_Empty()
        {
            var traktJsonReader = new TrendingMovieObjectJsonReader();

            using (var stream = string.Empty.ToStream())
            {
                var traktTrendingMovie = await traktJsonReader.ReadObjectAsync(stream);
                traktTrendingMovie.Should().BeNull();
            }
        }
    }
}
