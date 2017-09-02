namespace TraktApiSharp.Tests.Objects.Get.Movies.JsonReader
{
    using FluentAssertions;
    using System.Threading.Tasks;
    using Traits;
    using TraktApiSharp.Objects.Get.Movies.JsonReader;
    using Xunit;

    [Category("Objects.Get.Movies.JsonReader")]
    public partial class MostAnticipatedMovieObjectJsonReader_Tests
    {
        [Fact]
        public async Task Test_MostAnticipatedMovieObjectJsonReader_ReadObject_From_Json_String_Complete()
        {
            var jsonReader = new MostAnticipatedMovieObjectJsonReader();

            var traktMostAnticipatedMovie = await jsonReader.ReadObjectAsync(JSON_COMPLETE);

            traktMostAnticipatedMovie.Should().NotBeNull();
            traktMostAnticipatedMovie.ListCount.Should().Be(12805);
            traktMostAnticipatedMovie.Movie.Should().NotBeNull();
            traktMostAnticipatedMovie.Movie.Title.Should().Be("Star Wars: The Force Awakens");
            traktMostAnticipatedMovie.Movie.Year.Should().Be(2015);
            traktMostAnticipatedMovie.Movie.Ids.Should().NotBeNull();
            traktMostAnticipatedMovie.Movie.Ids.Trakt.Should().Be(94024U);
            traktMostAnticipatedMovie.Movie.Ids.Slug.Should().Be("star-wars-the-force-awakens-2015");
            traktMostAnticipatedMovie.Movie.Ids.Imdb.Should().Be("tt2488496");
            traktMostAnticipatedMovie.Movie.Ids.Tmdb.Should().Be(140607U);
        }

        [Fact]
        public async Task Test_MostAnticipatedMovieObjectJsonReader_ReadObject_From_Json_String_Incomplete_1()
        {
            var jsonReader = new MostAnticipatedMovieObjectJsonReader();

            var traktMostAnticipatedMovie = await jsonReader.ReadObjectAsync(JSON_INCOMPLETE_1);

            traktMostAnticipatedMovie.Should().NotBeNull();
            traktMostAnticipatedMovie.ListCount.Should().Be(12805);
            traktMostAnticipatedMovie.Movie.Should().BeNull();
        }

        [Fact]
        public async Task Test_MostAnticipatedMovieObjectJsonReader_ReadObject_From_Json_String_Incomplete_2()
        {
            var jsonReader = new MostAnticipatedMovieObjectJsonReader();

            var traktMostAnticipatedMovie = await jsonReader.ReadObjectAsync(JSON_INCOMPLETE_2);

            traktMostAnticipatedMovie.Should().NotBeNull();
            traktMostAnticipatedMovie.ListCount.Should().BeNull();
            traktMostAnticipatedMovie.Movie.Should().NotBeNull();
            traktMostAnticipatedMovie.Movie.Title.Should().Be("Star Wars: The Force Awakens");
            traktMostAnticipatedMovie.Movie.Year.Should().Be(2015);
            traktMostAnticipatedMovie.Movie.Ids.Should().NotBeNull();
            traktMostAnticipatedMovie.Movie.Ids.Trakt.Should().Be(94024U);
            traktMostAnticipatedMovie.Movie.Ids.Slug.Should().Be("star-wars-the-force-awakens-2015");
            traktMostAnticipatedMovie.Movie.Ids.Imdb.Should().Be("tt2488496");
            traktMostAnticipatedMovie.Movie.Ids.Tmdb.Should().Be(140607U);
        }

        [Fact]
        public async Task Test_MostAnticipatedMovieObjectJsonReader_ReadObject_From_Json_String_Not_Valid_1()
        {
            var jsonReader = new MostAnticipatedMovieObjectJsonReader();

            var traktMostAnticipatedMovie = await jsonReader.ReadObjectAsync(JSON_NOT_VALID_1);

            traktMostAnticipatedMovie.Should().NotBeNull();
            traktMostAnticipatedMovie.ListCount.Should().BeNull();
            traktMostAnticipatedMovie.Movie.Should().NotBeNull();
            traktMostAnticipatedMovie.Movie.Title.Should().Be("Star Wars: The Force Awakens");
            traktMostAnticipatedMovie.Movie.Year.Should().Be(2015);
            traktMostAnticipatedMovie.Movie.Ids.Should().NotBeNull();
            traktMostAnticipatedMovie.Movie.Ids.Trakt.Should().Be(94024U);
            traktMostAnticipatedMovie.Movie.Ids.Slug.Should().Be("star-wars-the-force-awakens-2015");
            traktMostAnticipatedMovie.Movie.Ids.Imdb.Should().Be("tt2488496");
            traktMostAnticipatedMovie.Movie.Ids.Tmdb.Should().Be(140607U);
        }

        [Fact]
        public async Task Test_MostAnticipatedMovieObjectJsonReader_ReadObject_From_Json_String_Not_Valid_2()
        {
            var jsonReader = new MostAnticipatedMovieObjectJsonReader();

            var traktMostAnticipatedMovie = await jsonReader.ReadObjectAsync(JSON_NOT_VALID_2);

            traktMostAnticipatedMovie.Should().NotBeNull();
            traktMostAnticipatedMovie.ListCount.Should().Be(12805);
            traktMostAnticipatedMovie.Movie.Should().BeNull();
        }

        [Fact]
        public async Task Test_MostAnticipatedMovieObjectJsonReader_ReadObject_From_Json_String_Not_Valid_3()
        {
            var jsonReader = new MostAnticipatedMovieObjectJsonReader();

            var traktMostAnticipatedMovie = await jsonReader.ReadObjectAsync(JSON_NOT_VALID_3);

            traktMostAnticipatedMovie.Should().NotBeNull();
            traktMostAnticipatedMovie.ListCount.Should().BeNull();
            traktMostAnticipatedMovie.Movie.Should().BeNull();
        }

        [Fact]
        public async Task Test_MostAnticipatedMovieObjectJsonReader_ReadObject_From_Json_String_Null()
        {
            var jsonReader = new MostAnticipatedMovieObjectJsonReader();

            var traktMostAnticipatedMovie = await jsonReader.ReadObjectAsync(default(string));
            traktMostAnticipatedMovie.Should().BeNull();
        }

        [Fact]
        public async Task Test_MostAnticipatedMovieObjectJsonReader_ReadObject_From_Json_String_Empty()
        {
            var jsonReader = new MostAnticipatedMovieObjectJsonReader();

            var traktMostAnticipatedMovie = await jsonReader.ReadObjectAsync(string.Empty);
            traktMostAnticipatedMovie.Should().BeNull();
        }
    }
}
