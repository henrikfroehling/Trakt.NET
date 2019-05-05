namespace TraktNet.Objects.Post.Tests.Responses.Json.Reader
{
    using FluentAssertions;
    using System.Threading.Tasks;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Objects.Post.Responses.Json.Reader;
    using Xunit;

    [Category("Objects.Post.Responses.JsonReader")]
    public partial class PostResponseNotFoundShowObjectJsonReader_Tests
    {
        [Fact]
        public async Task Test_PostResponseNotFoundShowObjectJsonReader_ReadObject_From_Json_String_Complete()
        {
            var jsonReader = new PostResponseNotFoundShowObjectJsonReader();

            var postResponseNotFoundShow = await jsonReader.ReadObjectAsync(JSON_COMPLETE);

            postResponseNotFoundShow.Should().NotBeNull();
            postResponseNotFoundShow.Ids.Trakt.Should().Be(1390U);
            postResponseNotFoundShow.Ids.Slug.Should().Be("game-of-thrones");
            postResponseNotFoundShow.Ids.Tvdb.Should().Be(121361U);
            postResponseNotFoundShow.Ids.Imdb.Should().Be("tt0944947");
            postResponseNotFoundShow.Ids.Tmdb.Should().Be(1399U);
            postResponseNotFoundShow.Ids.TvRage.Should().Be(24493U);
        }

        [Fact]
        public async Task Test_PostResponseNotFoundShowObjectJsonReader_ReadObject_From_Json_String_Not_Valid()
        {
            var jsonReader = new PostResponseNotFoundShowObjectJsonReader();

            var postResponseNotFoundShow = await jsonReader.ReadObjectAsync(JSON_NOT_VALID);

            postResponseNotFoundShow.Should().NotBeNull();
            postResponseNotFoundShow.Ids.Should().BeNull();
        }

        [Fact]
        public async Task Test_PostResponseNotFoundShowObjectJsonReader_ReadObject_From_Json_String_Null()
        {
            var jsonReader = new PostResponseNotFoundShowObjectJsonReader();

            var postResponseNotFoundShow = await jsonReader.ReadObjectAsync(default(string));
            postResponseNotFoundShow.Should().BeNull();
        }

        [Fact]
        public async Task Test_PostResponseNotFoundShowObjectJsonReader_ReadObject_From_Json_String_Empty()
        {
            var jsonReader = new PostResponseNotFoundShowObjectJsonReader();

            var postResponseNotFoundShow = await jsonReader.ReadObjectAsync(string.Empty);
            postResponseNotFoundShow.Should().BeNull();
        }
    }
}
