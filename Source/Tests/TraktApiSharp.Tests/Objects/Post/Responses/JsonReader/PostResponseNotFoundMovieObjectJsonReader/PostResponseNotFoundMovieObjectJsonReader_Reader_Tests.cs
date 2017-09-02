namespace TraktApiSharp.Tests.Objects.Post.Responses.JsonReader
{
    using FluentAssertions;
    using Newtonsoft.Json;
    using System.IO;
    using System.Threading.Tasks;
    using Traits;
    using TraktApiSharp.Objects.Post.Responses.JsonReader;
    using Xunit;

    [Category("Objects.Post.Responses.JsonReader")]
    public partial class PostResponseNotFoundMovieObjectJsonReader_Tests
    {
        [Fact]
        public async Task Test_PostResponseNotFoundMovieObjectJsonReader_ReadObject_From_JsonReader_Complete()
        {
            var traktJsonReader = new PostResponseNotFoundMovieObjectJsonReader();

            using (var reader = new StringReader(JSON_COMPLETE))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var postResponseNotFoundMovie = await traktJsonReader.ReadObjectAsync(jsonReader);

                postResponseNotFoundMovie.Should().NotBeNull();
                postResponseNotFoundMovie.Ids.Should().NotBeNull();
                postResponseNotFoundMovie.Ids.Trakt.Should().Be(94024U);
                postResponseNotFoundMovie.Ids.Slug.Should().Be("star-wars-the-force-awakens-2015");
                postResponseNotFoundMovie.Ids.Imdb.Should().Be("tt2488496");
                postResponseNotFoundMovie.Ids.Tmdb.Should().Be(140607U);
            }
        }

        [Fact]
        public async Task Test_PostResponseNotFoundMovieObjectJsonReader_ReadObject_From_JsonReader_Not_Valid()
        {
            var traktJsonReader = new PostResponseNotFoundMovieObjectJsonReader();

            using (var reader = new StringReader(JSON_NOT_VALID))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var postResponseNotFoundMovie = await traktJsonReader.ReadObjectAsync(jsonReader);

                postResponseNotFoundMovie.Should().NotBeNull();
                postResponseNotFoundMovie.Ids.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_PostResponseNotFoundMovieObjectJsonReader_ReadObject_From_JsonReader_Null()
        {
            var traktJsonReader = new PostResponseNotFoundMovieObjectJsonReader();

            var postResponseNotFoundMovie = await traktJsonReader.ReadObjectAsync(default(JsonTextReader));
            postResponseNotFoundMovie.Should().BeNull();
        }

        [Fact]
        public async Task Test_PostResponseNotFoundMovieObjectJsonReader_ReadObject_From_JsonReader_Empty()
        {
            var traktJsonReader = new PostResponseNotFoundMovieObjectJsonReader();

            using (var reader = new StringReader(string.Empty))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var postResponseNotFoundMovie = await traktJsonReader.ReadObjectAsync(jsonReader);
                postResponseNotFoundMovie.Should().BeNull();
            }
        }
    }
}
