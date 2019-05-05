namespace TraktNet.Objects.Get.Tests.Movies.Json.Reader
{
    using FluentAssertions;
    using Newtonsoft.Json;
    using System.IO;
    using System.Threading.Tasks;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Objects.Get.Movies.Json.Reader;
    using Xunit;

    [Category("Objects.Get.Movies.JsonReader")]
    public partial class MostPWCMovieObjectJsonReader_Tests
    {
        [Fact]
        public async Task Test_MostPWCMovieObjectJsonReader_ReadObject_From_JsonReader_Complete()
        {
            var traktJsonReader = new MostPWCMovieObjectJsonReader();

            using (var reader = new StringReader(JSON_COMPLETE))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktMostPWCMovie = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktMostPWCMovie.Should().NotBeNull();
                traktMostPWCMovie.WatcherCount.Should().Be(4992);
                traktMostPWCMovie.PlayCount.Should().Be(7100);
                traktMostPWCMovie.CollectedCount.Should().Be(1348);
                traktMostPWCMovie.Movie.Should().NotBeNull();
                traktMostPWCMovie.Movie.Title.Should().Be("Star Wars: The Force Awakens");
                traktMostPWCMovie.Movie.Year.Should().Be(2015);
                traktMostPWCMovie.Movie.Ids.Should().NotBeNull();
                traktMostPWCMovie.Movie.Ids.Trakt.Should().Be(94024U);
                traktMostPWCMovie.Movie.Ids.Slug.Should().Be("star-wars-the-force-awakens-2015");
                traktMostPWCMovie.Movie.Ids.Imdb.Should().Be("tt2488496");
                traktMostPWCMovie.Movie.Ids.Tmdb.Should().Be(140607U);
            }
        }

        [Fact]
        public async Task Test_MostPWCMovieObjectJsonReader_ReadObject_From_JsonReader_Incomplete_1()
        {
            var traktJsonReader = new MostPWCMovieObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_1))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktMostPWCMovie = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktMostPWCMovie.Should().NotBeNull();
                traktMostPWCMovie.WatcherCount.Should().BeNull();
                traktMostPWCMovie.PlayCount.Should().Be(7100);
                traktMostPWCMovie.CollectedCount.Should().Be(1348);
                traktMostPWCMovie.Movie.Should().NotBeNull();
                traktMostPWCMovie.Movie.Title.Should().Be("Star Wars: The Force Awakens");
                traktMostPWCMovie.Movie.Year.Should().Be(2015);
                traktMostPWCMovie.Movie.Ids.Should().NotBeNull();
                traktMostPWCMovie.Movie.Ids.Trakt.Should().Be(94024U);
                traktMostPWCMovie.Movie.Ids.Slug.Should().Be("star-wars-the-force-awakens-2015");
                traktMostPWCMovie.Movie.Ids.Imdb.Should().Be("tt2488496");
                traktMostPWCMovie.Movie.Ids.Tmdb.Should().Be(140607U);
            }
        }

        [Fact]
        public async Task Test_MostPWCMovieObjectJsonReader_ReadObject_From_JsonReader_Incomplete_2()
        {
            var traktJsonReader = new MostPWCMovieObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_2))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktMostPWCMovie = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktMostPWCMovie.Should().NotBeNull();
                traktMostPWCMovie.WatcherCount.Should().Be(4992);
                traktMostPWCMovie.PlayCount.Should().BeNull();
                traktMostPWCMovie.CollectedCount.Should().Be(1348);
                traktMostPWCMovie.Movie.Should().NotBeNull();
                traktMostPWCMovie.Movie.Title.Should().Be("Star Wars: The Force Awakens");
                traktMostPWCMovie.Movie.Year.Should().Be(2015);
                traktMostPWCMovie.Movie.Ids.Should().NotBeNull();
                traktMostPWCMovie.Movie.Ids.Trakt.Should().Be(94024U);
                traktMostPWCMovie.Movie.Ids.Slug.Should().Be("star-wars-the-force-awakens-2015");
                traktMostPWCMovie.Movie.Ids.Imdb.Should().Be("tt2488496");
                traktMostPWCMovie.Movie.Ids.Tmdb.Should().Be(140607U);
            }
        }

        [Fact]
        public async Task Test_MostPWCMovieObjectJsonReader_ReadObject_From_JsonReader_Incomplete_3()
        {
            var traktJsonReader = new MostPWCMovieObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_3))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktMostPWCMovie = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktMostPWCMovie.Should().NotBeNull();
                traktMostPWCMovie.WatcherCount.Should().Be(4992);
                traktMostPWCMovie.PlayCount.Should().Be(7100);
                traktMostPWCMovie.CollectedCount.Should().BeNull();
                traktMostPWCMovie.Movie.Should().NotBeNull();
                traktMostPWCMovie.Movie.Title.Should().Be("Star Wars: The Force Awakens");
                traktMostPWCMovie.Movie.Year.Should().Be(2015);
                traktMostPWCMovie.Movie.Ids.Should().NotBeNull();
                traktMostPWCMovie.Movie.Ids.Trakt.Should().Be(94024U);
                traktMostPWCMovie.Movie.Ids.Slug.Should().Be("star-wars-the-force-awakens-2015");
                traktMostPWCMovie.Movie.Ids.Imdb.Should().Be("tt2488496");
                traktMostPWCMovie.Movie.Ids.Tmdb.Should().Be(140607U);
            }
        }

        [Fact]
        public async Task Test_MostPWCMovieObjectJsonReader_ReadObject_From_JsonReader_Incomplete_4()
        {
            var traktJsonReader = new MostPWCMovieObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_4))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktMostPWCMovie = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktMostPWCMovie.Should().NotBeNull();
                traktMostPWCMovie.WatcherCount.Should().Be(4992);
                traktMostPWCMovie.PlayCount.Should().Be(7100);
                traktMostPWCMovie.CollectedCount.Should().Be(1348);
                traktMostPWCMovie.Movie.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_MostPWCMovieObjectJsonReader_ReadObject_From_JsonReader_Incomplete_5()
        {
            var traktJsonReader = new MostPWCMovieObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_5))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktMostPWCMovie = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktMostPWCMovie.Should().NotBeNull();
                traktMostPWCMovie.WatcherCount.Should().Be(4992);
                traktMostPWCMovie.PlayCount.Should().BeNull();
                traktMostPWCMovie.CollectedCount.Should().BeNull();
                traktMostPWCMovie.Movie.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_MostPWCMovieObjectJsonReader_ReadObject_From_JsonReader_Incomplete_6()
        {
            var traktJsonReader = new MostPWCMovieObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_6))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktMostPWCMovie = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktMostPWCMovie.Should().NotBeNull();
                traktMostPWCMovie.WatcherCount.Should().BeNull();
                traktMostPWCMovie.PlayCount.Should().Be(7100);
                traktMostPWCMovie.CollectedCount.Should().BeNull();
                traktMostPWCMovie.Movie.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_MostPWCMovieObjectJsonReader_ReadObject_From_JsonReader_Incomplete_7()
        {
            var traktJsonReader = new MostPWCMovieObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_7))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktMostPWCMovie = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktMostPWCMovie.Should().NotBeNull();
                traktMostPWCMovie.WatcherCount.Should().BeNull();
                traktMostPWCMovie.PlayCount.Should().BeNull();
                traktMostPWCMovie.CollectedCount.Should().Be(1348);
                traktMostPWCMovie.Movie.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_MostPWCMovieObjectJsonReader_ReadObject_From_JsonReader_Incomplete_8()
        {
            var traktJsonReader = new MostPWCMovieObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_8))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktMostPWCMovie = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktMostPWCMovie.Should().NotBeNull();
                traktMostPWCMovie.WatcherCount.Should().BeNull();
                traktMostPWCMovie.PlayCount.Should().BeNull();
                traktMostPWCMovie.CollectedCount.Should().BeNull();
                traktMostPWCMovie.Movie.Should().NotBeNull();
                traktMostPWCMovie.Movie.Title.Should().Be("Star Wars: The Force Awakens");
                traktMostPWCMovie.Movie.Year.Should().Be(2015);
                traktMostPWCMovie.Movie.Ids.Should().NotBeNull();
                traktMostPWCMovie.Movie.Ids.Trakt.Should().Be(94024U);
                traktMostPWCMovie.Movie.Ids.Slug.Should().Be("star-wars-the-force-awakens-2015");
                traktMostPWCMovie.Movie.Ids.Imdb.Should().Be("tt2488496");
                traktMostPWCMovie.Movie.Ids.Tmdb.Should().Be(140607U);
            }
        }

        [Fact]
        public async Task Test_MostPWCMovieObjectJsonReader_ReadObject_From_JsonReader_Not_Valid_1()
        {
            var traktJsonReader = new MostPWCMovieObjectJsonReader();

            using (var reader = new StringReader(JSON_NOT_VALID_1))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktMostPWCMovie = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktMostPWCMovie.Should().NotBeNull();
                traktMostPWCMovie.WatcherCount.Should().BeNull();
                traktMostPWCMovie.PlayCount.Should().Be(7100);
                traktMostPWCMovie.CollectedCount.Should().Be(1348);
                traktMostPWCMovie.Movie.Should().NotBeNull();
                traktMostPWCMovie.Movie.Title.Should().Be("Star Wars: The Force Awakens");
                traktMostPWCMovie.Movie.Year.Should().Be(2015);
                traktMostPWCMovie.Movie.Ids.Should().NotBeNull();
                traktMostPWCMovie.Movie.Ids.Trakt.Should().Be(94024U);
                traktMostPWCMovie.Movie.Ids.Slug.Should().Be("star-wars-the-force-awakens-2015");
                traktMostPWCMovie.Movie.Ids.Imdb.Should().Be("tt2488496");
                traktMostPWCMovie.Movie.Ids.Tmdb.Should().Be(140607U);
            }
        }

        [Fact]
        public async Task Test_MostPWCMovieObjectJsonReader_ReadObject_From_JsonReader_Not_Valid_2()
        {
            var traktJsonReader = new MostPWCMovieObjectJsonReader();

            using (var reader = new StringReader(JSON_NOT_VALID_2))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktMostPWCMovie = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktMostPWCMovie.Should().NotBeNull();
                traktMostPWCMovie.WatcherCount.Should().Be(4992);
                traktMostPWCMovie.PlayCount.Should().BeNull();
                traktMostPWCMovie.CollectedCount.Should().Be(1348);
                traktMostPWCMovie.Movie.Should().NotBeNull();
                traktMostPWCMovie.Movie.Title.Should().Be("Star Wars: The Force Awakens");
                traktMostPWCMovie.Movie.Year.Should().Be(2015);
                traktMostPWCMovie.Movie.Ids.Should().NotBeNull();
                traktMostPWCMovie.Movie.Ids.Trakt.Should().Be(94024U);
                traktMostPWCMovie.Movie.Ids.Slug.Should().Be("star-wars-the-force-awakens-2015");
                traktMostPWCMovie.Movie.Ids.Imdb.Should().Be("tt2488496");
                traktMostPWCMovie.Movie.Ids.Tmdb.Should().Be(140607U);
            }
        }

        [Fact]
        public async Task Test_MostPWCMovieObjectJsonReader_ReadObject_From_JsonReader_Not_Valid_3()
        {
            var traktJsonReader = new MostPWCMovieObjectJsonReader();

            using (var reader = new StringReader(JSON_NOT_VALID_3))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktMostPWCMovie = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktMostPWCMovie.Should().NotBeNull();
                traktMostPWCMovie.WatcherCount.Should().Be(4992);
                traktMostPWCMovie.PlayCount.Should().Be(7100);
                traktMostPWCMovie.CollectedCount.Should().BeNull();
                traktMostPWCMovie.Movie.Should().NotBeNull();
                traktMostPWCMovie.Movie.Title.Should().Be("Star Wars: The Force Awakens");
                traktMostPWCMovie.Movie.Year.Should().Be(2015);
                traktMostPWCMovie.Movie.Ids.Should().NotBeNull();
                traktMostPWCMovie.Movie.Ids.Trakt.Should().Be(94024U);
                traktMostPWCMovie.Movie.Ids.Slug.Should().Be("star-wars-the-force-awakens-2015");
                traktMostPWCMovie.Movie.Ids.Imdb.Should().Be("tt2488496");
                traktMostPWCMovie.Movie.Ids.Tmdb.Should().Be(140607U);
            }
        }

        [Fact]
        public async Task Test_MostPWCMovieObjectJsonReader_ReadObject_From_JsonReader_Not_Valid_4()
        {
            var traktJsonReader = new MostPWCMovieObjectJsonReader();

            using (var reader = new StringReader(JSON_NOT_VALID_4))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktMostPWCMovie = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktMostPWCMovie.Should().NotBeNull();
                traktMostPWCMovie.WatcherCount.Should().Be(4992);
                traktMostPWCMovie.PlayCount.Should().Be(7100);
                traktMostPWCMovie.CollectedCount.Should().Be(1348);
                traktMostPWCMovie.Movie.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_MostPWCMovieObjectJsonReader_ReadObject_From_JsonReader_Not_Valid_5()
        {
            var traktJsonReader = new MostPWCMovieObjectJsonReader();

            using (var reader = new StringReader(JSON_NOT_VALID_5))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktMostPWCMovie = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktMostPWCMovie.Should().NotBeNull();
                traktMostPWCMovie.WatcherCount.Should().BeNull();
                traktMostPWCMovie.PlayCount.Should().BeNull();
                traktMostPWCMovie.CollectedCount.Should().BeNull();
                traktMostPWCMovie.Movie.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_MostPWCMovieObjectJsonReader_ReadObject_From_JsonReader_Null()
        {
            var traktJsonReader = new MostPWCMovieObjectJsonReader();

            var traktMostPWCMovie = await traktJsonReader.ReadObjectAsync(default(JsonTextReader));
            traktMostPWCMovie.Should().BeNull();
        }

        [Fact]
        public async Task Test_MostPWCMovieObjectJsonReader_ReadObject_From_JsonReader_Empty()
        {
            var traktJsonReader = new MostPWCMovieObjectJsonReader();

            using (var reader = new StringReader(string.Empty))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktMostPWCMovie = await traktJsonReader.ReadObjectAsync(jsonReader);
                traktMostPWCMovie.Should().BeNull();
            }
        }
    }
}
