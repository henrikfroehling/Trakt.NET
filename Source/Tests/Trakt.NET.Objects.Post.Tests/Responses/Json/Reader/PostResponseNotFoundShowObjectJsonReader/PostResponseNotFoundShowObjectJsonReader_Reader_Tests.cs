namespace TraktNet.Objects.Post.Tests.Responses.Json.Reader
{
    using FluentAssertions;
    using Newtonsoft.Json;
    using System;
    using System.IO;
    using System.Threading.Tasks;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Objects.Post.Responses;
    using TraktNet.Objects.Post.Responses.Json.Reader;
    using Xunit;

    [TestCategory("Objects.Post.Responses.JsonReader")]
    public partial class PostResponseNotFoundShowObjectJsonReader_Tests
    {
        [Fact]
        public async Task Test_PostResponseNotFoundShowObjectJsonReader_ReadObject_From_JsonReader_Complete()
        {
            var traktJsonReader = new PostResponseNotFoundShowObjectJsonReader();

            using (var reader = new StringReader(JSON_COMPLETE))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var postResponseNotFoundShow = await traktJsonReader.ReadObjectAsync(jsonReader);

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
        public async Task Test_PostResponseNotFoundShowObjectJsonReader_ReadObject_From_JsonReader_Not_Valid()
        {
            var traktJsonReader = new PostResponseNotFoundShowObjectJsonReader();

            using (var reader = new StringReader(JSON_NOT_VALID))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var postResponseNotFoundShow = await traktJsonReader.ReadObjectAsync(jsonReader);

                postResponseNotFoundShow.Should().NotBeNull();
                postResponseNotFoundShow.Ids.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_PostResponseNotFoundShowObjectJsonReader_ReadObject_From_JsonReader_Null()
        {
            var traktJsonReader = new PostResponseNotFoundShowObjectJsonReader();
            Func<Task<ITraktPostResponseNotFoundShow>> postResponseNotFoundShow = () => traktJsonReader.ReadObjectAsync(default(JsonTextReader));
            await postResponseNotFoundShow.Should().ThrowAsync<ArgumentNullException>();
        }

        [Fact]
        public async Task Test_PostResponseNotFoundShowObjectJsonReader_ReadObject_From_JsonReader_Empty()
        {
            var traktJsonReader = new PostResponseNotFoundShowObjectJsonReader();

            using (var reader = new StringReader(string.Empty))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var postResponseNotFoundShow = await traktJsonReader.ReadObjectAsync(jsonReader);
                postResponseNotFoundShow.Should().BeNull();
            }
        }
    }
}
