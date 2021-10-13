namespace TraktNet.Objects.Post.Tests.Responses.Json.Reader
{
    using FluentAssertions;
    using System;
    using System.Threading.Tasks;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Objects.Post.Responses;
    using TraktNet.Objects.Post.Responses.Json.Reader;
    using Xunit;

    [Category("Objects.Post.Responses.JsonReader")]
    public partial class PostResponseNotFoundEpisodeObjectJsonReader_Tests
    {
        [Fact]
        public async Task Test_PostResponseNotFoundEpisodeObjectJsonReader_ReadObject_From_Json_String_Complete()
        {
            var jsonReader = new PostResponseNotFoundEpisodeObjectJsonReader();

            var postResponseNotFoundEpisode = await jsonReader.ReadObjectAsync(JSON_COMPLETE);

            postResponseNotFoundEpisode.Should().NotBeNull();
            postResponseNotFoundEpisode.Ids.Should().NotBeNull();
            postResponseNotFoundEpisode.Ids.Trakt.Should().Be(73640U);
            postResponseNotFoundEpisode.Ids.Tvdb.Should().Be(3254641U);
            postResponseNotFoundEpisode.Ids.Imdb.Should().Be("tt1480055");
            postResponseNotFoundEpisode.Ids.Tmdb.Should().Be(63056U);
            postResponseNotFoundEpisode.Ids.TvRage.Should().Be(1065008299U);
        }

        [Fact]
        public async Task Test_PostResponseNotFoundEpisodeObjectJsonReader_ReadObject_From_Json_String_Not_Valid()
        {
            var jsonReader = new PostResponseNotFoundEpisodeObjectJsonReader();

            var postResponseNotFoundEpisode = await jsonReader.ReadObjectAsync(JSON_NOT_VALID);

            postResponseNotFoundEpisode.Should().NotBeNull();
            postResponseNotFoundEpisode.Ids.Should().BeNull();
        }

        [Fact]
        public async Task Test_PostResponseNotFoundEpisodeObjectJsonReader_ReadObject_From_Json_String_Null()
        {
            var jsonReader = new PostResponseNotFoundEpisodeObjectJsonReader();
            Func<Task<ITraktPostResponseNotFoundEpisode>> postResponseNotFoundEpisode = () => jsonReader.ReadObjectAsync(default(string));
            await postResponseNotFoundEpisode.Should().ThrowAsync<ArgumentNullException>();
        }

        [Fact]
        public async Task Test_PostResponseNotFoundEpisodeObjectJsonReader_ReadObject_From_Json_String_Empty()
        {
            var jsonReader = new PostResponseNotFoundEpisodeObjectJsonReader();

            var postResponseNotFoundEpisode = await jsonReader.ReadObjectAsync(string.Empty);
            postResponseNotFoundEpisode.Should().BeNull();
        }
    }
}
