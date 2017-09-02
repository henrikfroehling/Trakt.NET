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
    public partial class PostResponseNotFoundShowObjectJsonReader_Tests
    {
        [Fact]
        public async Task Test_PostResponseNotFoundShowObjectJsonReader_ReadObject_From_Stream_Complete()
        {
            var jsonReader = new PostResponseNotFoundShowObjectJsonReader();

            using (var stream = JSON_COMPLETE.ToStream())
            {
                var postResponseNotFoundShow = await jsonReader.ReadObjectAsync(stream);

                postResponseNotFoundShow.Should().NotBeNull();
                postResponseNotFoundShow.Ids.Trakt.Should().Be(1390U);
                postResponseNotFoundShow.Ids.Slug.Should().Be("game-of-thrones");
                postResponseNotFoundShow.Ids.Tvdb.Should().Be(121361U);
                postResponseNotFoundShow.Ids.Imdb.Should().Be("tt0944947");
                postResponseNotFoundShow.Ids.Tmdb.Should().Be(1399U);
                postResponseNotFoundShow.Ids.TvRage.Should().Be(24493U);
            }
        }

        [Fact]
        public async Task Test_PostResponseNotFoundShowObjectJsonReader_ReadObject_From_Stream_Not_Valid()
        {
            var jsonReader = new PostResponseNotFoundShowObjectJsonReader();

            using (var stream = JSON_NOT_VALID.ToStream())
            {
                var postResponseNotFoundShow = await jsonReader.ReadObjectAsync(stream);

                postResponseNotFoundShow.Should().NotBeNull();
                postResponseNotFoundShow.Ids.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_PostResponseNotFoundShowObjectJsonReader_ReadObject_From_Stream_Null()
        {
            var jsonReader = new PostResponseNotFoundShowObjectJsonReader();

            var postResponseNotFoundShow = await jsonReader.ReadObjectAsync(default(Stream));
            postResponseNotFoundShow.Should().BeNull();
        }

        [Fact]
        public async Task Test_PostResponseNotFoundShowObjectJsonReader_ReadObject_From_Stream_Empty()
        {
            var jsonReader = new PostResponseNotFoundShowObjectJsonReader();

            using (var stream = string.Empty.ToStream())
            {
                var postResponseNotFoundShow = await jsonReader.ReadObjectAsync(stream);
                postResponseNotFoundShow.Should().BeNull();
            }
        }
    }
}
