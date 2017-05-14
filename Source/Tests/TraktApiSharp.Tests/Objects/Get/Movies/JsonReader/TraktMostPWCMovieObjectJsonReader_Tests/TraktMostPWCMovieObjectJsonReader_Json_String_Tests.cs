namespace TraktApiSharp.Tests.Objects.Get.Movies.JsonReader
{
    using FluentAssertions;
    using System.Threading.Tasks;
    using Traits;
    using TraktApiSharp.Objects.Get.Movies.JsonReader;
    using Xunit;

    [Category("Objects.Get.Movies.JsonReader")]
    public partial class TraktMostPWCMovieObjectJsonReader_Tests
    {
        [Fact]
        public async Task Test_TraktMostPWCMovieObjectJsonReader_ReadObject_From_Json_String_Complete()
        {
            var jsonReader = new TraktMostPWCMovieObjectJsonReader();

            var traktMostPWCMovie = await jsonReader.ReadObjectAsync(JSON_COMPLETE);

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

        [Fact]
        public async Task Test_TraktMostPWCMovieObjectJsonReader_ReadObject_From_Json_String_Incomplete_1()
        {
            var jsonReader = new TraktMostPWCMovieObjectJsonReader();

            var traktMostPWCMovie = await jsonReader.ReadObjectAsync(JSON_INCOMPLETE_1);

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

        [Fact]
        public async Task Test_TraktMostPWCMovieObjectJsonReader_ReadObject_From_Json_String_Incomplete_2()
        {
            var jsonReader = new TraktMostPWCMovieObjectJsonReader();

            var traktMostPWCMovie = await jsonReader.ReadObjectAsync(JSON_INCOMPLETE_2);

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

        [Fact]
        public async Task Test_TraktMostPWCMovieObjectJsonReader_ReadObject_From_Json_String_Incomplete_3()
        {
            var jsonReader = new TraktMostPWCMovieObjectJsonReader();

            var traktMostPWCMovie = await jsonReader.ReadObjectAsync(JSON_INCOMPLETE_3);

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

        [Fact]
        public async Task Test_TraktMostPWCMovieObjectJsonReader_ReadObject_From_Json_String_Incomplete_4()
        {
            var jsonReader = new TraktMostPWCMovieObjectJsonReader();

            var traktMostPWCMovie = await jsonReader.ReadObjectAsync(JSON_INCOMPLETE_4);

            traktMostPWCMovie.Should().NotBeNull();
            traktMostPWCMovie.WatcherCount.Should().Be(4992);
            traktMostPWCMovie.PlayCount.Should().Be(7100);
            traktMostPWCMovie.CollectedCount.Should().Be(1348);
            traktMostPWCMovie.Movie.Should().BeNull();
        }

        [Fact]
        public async Task Test_TraktMostPWCMovieObjectJsonReader_ReadObject_From_Json_String_Incomplete_5()
        {
            var jsonReader = new TraktMostPWCMovieObjectJsonReader();

            var traktMostPWCMovie = await jsonReader.ReadObjectAsync(JSON_INCOMPLETE_5);

            traktMostPWCMovie.Should().NotBeNull();
            traktMostPWCMovie.WatcherCount.Should().Be(4992);
            traktMostPWCMovie.PlayCount.Should().BeNull();
            traktMostPWCMovie.CollectedCount.Should().BeNull();
            traktMostPWCMovie.Movie.Should().BeNull();
        }

        [Fact]
        public async Task Test_TraktMostPWCMovieObjectJsonReader_ReadObject_From_Json_String_Incomplete_6()
        {
            var jsonReader = new TraktMostPWCMovieObjectJsonReader();

            var traktMostPWCMovie = await jsonReader.ReadObjectAsync(JSON_INCOMPLETE_6);

            traktMostPWCMovie.Should().NotBeNull();
            traktMostPWCMovie.WatcherCount.Should().BeNull();
            traktMostPWCMovie.PlayCount.Should().Be(7100);
            traktMostPWCMovie.CollectedCount.Should().BeNull();
            traktMostPWCMovie.Movie.Should().BeNull();
        }

        [Fact]
        public async Task Test_TraktMostPWCMovieObjectJsonReader_ReadObject_From_Json_String_Incomplete_7()
        {
            var jsonReader = new TraktMostPWCMovieObjectJsonReader();

            var traktMostPWCMovie = await jsonReader.ReadObjectAsync(JSON_INCOMPLETE_7);

            traktMostPWCMovie.Should().NotBeNull();
            traktMostPWCMovie.WatcherCount.Should().BeNull();
            traktMostPWCMovie.PlayCount.Should().BeNull();
            traktMostPWCMovie.CollectedCount.Should().Be(1348);
            traktMostPWCMovie.Movie.Should().BeNull();
        }

        [Fact]
        public async Task Test_TraktMostPWCMovieObjectJsonReader_ReadObject_From_Json_String_Incomplete_8()
        {
            var jsonReader = new TraktMostPWCMovieObjectJsonReader();

            var traktMostPWCMovie = await jsonReader.ReadObjectAsync(JSON_INCOMPLETE_8);

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

        [Fact]
        public async Task Test_TraktMostPWCMovieObjectJsonReader_ReadObject_From_Json_String_Not_Valid_1()
        {
            var jsonReader = new TraktMostPWCMovieObjectJsonReader();

            var traktMostPWCMovie = await jsonReader.ReadObjectAsync(JSON_NOT_VALID_1);

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

        [Fact]
        public async Task Test_TraktMostPWCMovieObjectJsonReader_ReadObject_From_Json_String_Not_Valid_2()
        {
            var jsonReader = new TraktMostPWCMovieObjectJsonReader();

            var traktMostPWCMovie = await jsonReader.ReadObjectAsync(JSON_NOT_VALID_2);

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

        [Fact]
        public async Task Test_TraktMostPWCMovieObjectJsonReader_ReadObject_From_Json_String_Not_Valid_3()
        {
            var jsonReader = new TraktMostPWCMovieObjectJsonReader();

            var traktMostPWCMovie = await jsonReader.ReadObjectAsync(JSON_NOT_VALID_3);

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

        [Fact]
        public async Task Test_TraktMostPWCMovieObjectJsonReader_ReadObject_From_Json_String_Not_Valid_4()
        {
            var jsonReader = new TraktMostPWCMovieObjectJsonReader();

            var traktMostPWCMovie = await jsonReader.ReadObjectAsync(JSON_NOT_VALID_4);

            traktMostPWCMovie.Should().NotBeNull();
            traktMostPWCMovie.WatcherCount.Should().Be(4992);
            traktMostPWCMovie.PlayCount.Should().Be(7100);
            traktMostPWCMovie.CollectedCount.Should().Be(1348);
            traktMostPWCMovie.Movie.Should().BeNull();
        }

        [Fact]
        public async Task Test_TraktMostPWCMovieObjectJsonReader_ReadObject_From_Json_String_Not_Valid_5()
        {
            var jsonReader = new TraktMostPWCMovieObjectJsonReader();

            var traktMostPWCMovie = await jsonReader.ReadObjectAsync(JSON_NOT_VALID_5);

            traktMostPWCMovie.Should().NotBeNull();
            traktMostPWCMovie.WatcherCount.Should().BeNull();
            traktMostPWCMovie.PlayCount.Should().BeNull();
            traktMostPWCMovie.CollectedCount.Should().BeNull();
            traktMostPWCMovie.Movie.Should().BeNull();
        }

        [Fact]
        public async Task Test_TraktMostPWCMovieObjectJsonReader_ReadObject_From_Json_String_Null()
        {
            var jsonReader = new TraktMostPWCMovieObjectJsonReader();

            var traktMostPWCMovie = await jsonReader.ReadObjectAsync(default(string));
            traktMostPWCMovie.Should().BeNull();
        }

        [Fact]
        public async Task Test_TraktMostPWCMovieObjectJsonReader_ReadObject_From_Json_String_Empty()
        {
            var jsonReader = new TraktMostPWCMovieObjectJsonReader();

            var traktMostPWCMovie = await jsonReader.ReadObjectAsync(string.Empty);
            traktMostPWCMovie.Should().BeNull();
        }
    }
}
