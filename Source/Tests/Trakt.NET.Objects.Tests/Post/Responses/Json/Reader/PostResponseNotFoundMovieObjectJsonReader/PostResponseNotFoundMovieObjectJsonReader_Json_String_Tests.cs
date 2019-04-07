namespace TraktNet.Objects.Tests.Post.Responses.Json.Reader
{
    using FluentAssertions;
    using System.Threading.Tasks;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Objects.Post.Responses.Json.Reader;
    using Xunit;

    [Category("Objects.Post.Responses.JsonReader")]
    public partial class PostResponseNotFoundMovieObjectJsonReader_Tests
    {
        [Fact]
        public async Task Test_PostResponseNotFoundMovieObjectJsonReader_ReadObject_From_Json_String_Complete()
        {
            var jsonReader = new PostResponseNotFoundMovieObjectJsonReader();

            var postResponseNotFoundMovie = await jsonReader.ReadObjectAsync(JSON_COMPLETE);

            postResponseNotFoundMovie.Should().NotBeNull();
            postResponseNotFoundMovie.Ids.Should().NotBeNull();
            postResponseNotFoundMovie.Ids.Trakt.Should().Be(94024U);
            postResponseNotFoundMovie.Ids.Slug.Should().Be("star-wars-the-force-awakens-2015");
            postResponseNotFoundMovie.Ids.Imdb.Should().Be("tt2488496");
            postResponseNotFoundMovie.Ids.Tmdb.Should().Be(140607U);
        }

        [Fact]
        public async Task Test_PostResponseNotFoundMovieObjectJsonReader_ReadObject_From_Json_String_Not_Valid()
        {
            var jsonReader = new PostResponseNotFoundMovieObjectJsonReader();

            var postResponseNotFoundMovie = await jsonReader.ReadObjectAsync(JSON_NOT_VALID);

            postResponseNotFoundMovie.Should().NotBeNull();
            postResponseNotFoundMovie.Ids.Should().BeNull();
        }

        [Fact]
        public async Task Test_PostResponseNotFoundMovieObjectJsonReader_ReadObject_From_Json_String_Null()
        {
            var jsonReader = new PostResponseNotFoundMovieObjectJsonReader();

            var postResponseNotFoundMovie = await jsonReader.ReadObjectAsync(default(string));
            postResponseNotFoundMovie.Should().BeNull();
        }

        [Fact]
        public async Task Test_PostResponseNotFoundMovieObjectJsonReader_ReadObject_From_Json_String_Empty()
        {
            var jsonReader = new PostResponseNotFoundMovieObjectJsonReader();

            var postResponseNotFoundMovie = await jsonReader.ReadObjectAsync(string.Empty);
            postResponseNotFoundMovie.Should().BeNull();
        }
    }
}
