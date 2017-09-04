namespace TraktApiSharp.Tests.Objects.Post.Responses.JsonReader
{
    using FluentAssertions;
    using System.IO;
    using System.Threading.Tasks;
    using TestUtils;
    using Traits;
    using TraktApiSharp.Objects.Post.Responses.JsonReader;
    using Xunit;

    [Category("Objects.Post.Responses.JsonReader")]
    public partial class PostResponseNotFoundMovieObjectJsonReader_Tests
    {
        [Fact]
        public async Task Test_PostResponseNotFoundMovieObjectJsonReader_ReadObject_From_Stream_Complete()
        {
            var jsonReader = new PostResponseNotFoundMovieObjectJsonReader();

            using (var stream = JSON_COMPLETE.ToStream())
            {
                var postResponseNotFoundMovie = await jsonReader.ReadObjectAsync(stream);

                postResponseNotFoundMovie.Should().NotBeNull();
                postResponseNotFoundMovie.Ids.Should().NotBeNull();
                postResponseNotFoundMovie.Ids.Trakt.Should().Be(94024U);
                postResponseNotFoundMovie.Ids.Slug.Should().Be("star-wars-the-force-awakens-2015");
                postResponseNotFoundMovie.Ids.Imdb.Should().Be("tt2488496");
                postResponseNotFoundMovie.Ids.Tmdb.Should().Be(140607U);
            }
        }

        [Fact]
        public async Task Test_PostResponseNotFoundMovieObjectJsonReader_ReadObject_From_Stream_Not_Valid()
        {
            var jsonReader = new PostResponseNotFoundMovieObjectJsonReader();

            using (var stream = JSON_NOT_VALID.ToStream())
            {
                var postResponseNotFoundMovie = await jsonReader.ReadObjectAsync(stream);

                postResponseNotFoundMovie.Should().NotBeNull();
                postResponseNotFoundMovie.Ids.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_PostResponseNotFoundMovieObjectJsonReader_ReadObject_From_Stream_Null()
        {
            var jsonReader = new PostResponseNotFoundMovieObjectJsonReader();

            var postResponseNotFoundMovie = await jsonReader.ReadObjectAsync(default(Stream));
            postResponseNotFoundMovie.Should().BeNull();
        }

        [Fact]
        public async Task Test_PostResponseNotFoundMovieObjectJsonReader_ReadObject_From_Stream_Empty()
        {
            var jsonReader = new PostResponseNotFoundMovieObjectJsonReader();

            using (var stream = string.Empty.ToStream())
            {
                var postResponseNotFoundMovie = await jsonReader.ReadObjectAsync(stream);
                postResponseNotFoundMovie.Should().BeNull();
            }
        }
    }
}
