namespace TraktApiSharp.Tests.Objects.Post.Responses.Json.Reader
{
    using FluentAssertions;
    using System.IO;
    using System.Threading.Tasks;
    using TestUtils;
    using Traits;
    using TraktApiSharp.Objects.Post.Responses.Json.Reader;
    using Xunit;

    [Category("Objects.Post.Responses.JsonReader")]
    public partial class PostResponseNotFoundEpisodeObjectJsonReader_Tests
    {
        [Fact]
        public async Task Test_PostResponseNotFoundEpisodeObjectJsonReader_ReadObject_From_Stream_Complete()
        {
            var jsonReader = new PostResponseNotFoundEpisodeObjectJsonReader();

            using (var stream = JSON_COMPLETE.ToStream())
            {
                var postResponseNotFoundEpisode = await jsonReader.ReadObjectAsync(stream);

                postResponseNotFoundEpisode.Should().NotBeNull();
                postResponseNotFoundEpisode.Ids.Should().NotBeNull();
                postResponseNotFoundEpisode.Ids.Trakt.Should().Be(73640U);
                postResponseNotFoundEpisode.Ids.Tvdb.Should().Be(3254641U);
                postResponseNotFoundEpisode.Ids.Imdb.Should().Be("tt1480055");
                postResponseNotFoundEpisode.Ids.Tmdb.Should().Be(63056U);
                postResponseNotFoundEpisode.Ids.TvRage.Should().Be(1065008299U);
            }
        }

        [Fact]
        public async Task Test_PostResponseNotFoundEpisodeObjectJsonReader_ReadObject_From_Stream_Not_Valid()
        {
            var jsonReader = new PostResponseNotFoundEpisodeObjectJsonReader();

            using (var stream = JSON_NOT_VALID.ToStream())
            {
                var postResponseNotFoundEpisode = await jsonReader.ReadObjectAsync(stream);

                postResponseNotFoundEpisode.Should().NotBeNull();
                postResponseNotFoundEpisode.Ids.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_PostResponseNotFoundEpisodeObjectJsonReader_ReadObject_From_Stream_Null()
        {
            var jsonReader = new PostResponseNotFoundEpisodeObjectJsonReader();

            var postResponseNotFoundEpisode = await jsonReader.ReadObjectAsync(default(Stream));
            postResponseNotFoundEpisode.Should().BeNull();
        }

        [Fact]
        public async Task Test_PostResponseNotFoundEpisodeObjectJsonReader_ReadObject_From_Stream_Empty()
        {
            var jsonReader = new PostResponseNotFoundEpisodeObjectJsonReader();

            using (var stream = string.Empty.ToStream())
            {
                var postResponseNotFoundEpisode = await jsonReader.ReadObjectAsync(stream);
                postResponseNotFoundEpisode.Should().BeNull();
            }
        }
    }
}
