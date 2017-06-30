namespace TraktApiSharp.Tests.Objects.Post.Responses.JsonReader
{
    using FluentAssertions;
    using System.Linq;
    using System.Threading.Tasks;
    using Traits;
    using TraktApiSharp.Objects.Post.Responses.JsonReader;
    using Xunit;

    [Category("Objects.Post.Responses.JsonReader")]
    public partial class TraktPostResponseNotFoundMovieArrayJsonReader_Tests
    {
        [Fact]
        public async Task Test_TraktPostResponseNotFoundMovieArrayJsonReader_ReadArray_From_Json_String_Empty_Array()
        {
            var jsonReader = new TraktPostResponseNotFoundMovieArrayJsonReader();

            var notFoundMovies = await jsonReader.ReadArrayAsync(JSON_EMPTY_ARRAY);
            notFoundMovies.Should().NotBeNull().And.BeEmpty();
        }

        [Fact]
        public async Task Test_TraktPostResponseNotFoundMovieArrayJsonReader_ReadArray_From_Json_String_Complete()
        {
            var jsonReader = new TraktPostResponseNotFoundMovieArrayJsonReader();

            var notFoundMovies = await jsonReader.ReadArrayAsync(JSON_COMPLETE);
            notFoundMovies.Should().NotBeNull().And.NotBeEmpty().And.HaveCount(2);

            var notFoundMovie = notFoundMovies.ToArray();

            notFoundMovie[0].Should().NotBeNull();
            notFoundMovie[0].Ids.Should().NotBeNull();
            notFoundMovie[0].Ids.Trakt.Should().Be(94024U);
            notFoundMovie[0].Ids.Slug.Should().Be("star-wars-the-force-awakens-2015");
            notFoundMovie[0].Ids.Imdb.Should().Be("tt2488496");
            notFoundMovie[0].Ids.Tmdb.Should().Be(140607U);

            notFoundMovie[1].Should().NotBeNull();
            notFoundMovie[1].Ids.Should().NotBeNull();
            notFoundMovie[1].Ids.Trakt.Should().Be(172687U);
            notFoundMovie[1].Ids.Slug.Should().Be("king-arthur-legend-of-the-sword-2017");
            notFoundMovie[1].Ids.Imdb.Should().Be("tt1972591");
            notFoundMovie[1].Ids.Tmdb.Should().Be(274857U);
        }

        [Fact]
        public async Task Test_TraktPostResponseNotFoundMovieArrayJsonReader_ReadArray_From_Json_String_Not_Valid()
        {
            var jsonReader = new TraktPostResponseNotFoundMovieArrayJsonReader();

            var notFoundMovies = await jsonReader.ReadArrayAsync(JSON_NOT_VALID);
            notFoundMovies.Should().NotBeNull().And.NotBeEmpty().And.HaveCount(2);

            var notFoundMovie = notFoundMovies.ToArray();

            notFoundMovie[0].Should().NotBeNull();
            notFoundMovie[0].Ids.Should().NotBeNull();
            notFoundMovie[0].Ids.Trakt.Should().Be(94024U);
            notFoundMovie[0].Ids.Slug.Should().Be("star-wars-the-force-awakens-2015");
            notFoundMovie[0].Ids.Imdb.Should().Be("tt2488496");
            notFoundMovie[0].Ids.Tmdb.Should().Be(140607U);

            notFoundMovie[1].Should().NotBeNull();
            notFoundMovie[1].Ids.Should().BeNull();
        }

        [Fact]
        public async Task Test_TraktPostResponseNotFoundMovieArrayJsonReader_ReadArray_From_Json_String_Null()
        {
            var jsonReader = new TraktPostResponseNotFoundMovieArrayJsonReader();

            var notFoundMovies = await jsonReader.ReadArrayAsync(default(string));
            notFoundMovies.Should().BeNull();
        }

        [Fact]
        public async Task Test_TraktPostResponseNotFoundMovieArrayJsonReader_ReadArray_From_Json_String_Empty()
        {
            var jsonReader = new TraktPostResponseNotFoundMovieArrayJsonReader();

            var notFoundMovies = await jsonReader.ReadArrayAsync(string.Empty);
            notFoundMovies.Should().BeNull();
        }
    }
}
