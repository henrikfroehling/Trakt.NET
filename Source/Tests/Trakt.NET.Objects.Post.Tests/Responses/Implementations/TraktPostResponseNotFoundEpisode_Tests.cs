namespace TraktNet.Objects.Post.Tests.Responses.Implementations
{
    using FluentAssertions;
    using System.Threading.Tasks;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Objects.Post.Responses;
    using TraktNet.Objects.Post.Responses.Json.Reader;
    using Xunit;

    [Category("Objects.Post.Responses.Implementations")]
    public class TraktPostResponseNotFoundEpisode_Tests
    {
        [Fact]
        public void Test_TraktPostResponseNotFoundEpisode_Default_Constructor()
        {
            var postResponseNotFoundEpisode = new TraktPostResponseNotFoundEpisode();

            postResponseNotFoundEpisode.Ids.Should().BeNull();
        }

        [Fact]
        public async Task Test_TraktPostResponseNotFoundEpisode_From_Json()
        {
            var jsonReader = new PostResponseNotFoundEpisodeObjectJsonReader();
            var postResponseNotFoundEpisode = await jsonReader.ReadObjectAsync(JSON) as TraktPostResponseNotFoundEpisode;

            postResponseNotFoundEpisode.Should().NotBeNull();
            postResponseNotFoundEpisode.Ids.Should().NotBeNull();
            postResponseNotFoundEpisode.Ids.Trakt.Should().Be(73640U);
            postResponseNotFoundEpisode.Ids.Tvdb.Should().Be(3254641U);
            postResponseNotFoundEpisode.Ids.Imdb.Should().Be("tt1480055");
            postResponseNotFoundEpisode.Ids.Tmdb.Should().Be(63056U);
            postResponseNotFoundEpisode.Ids.TvRage.Should().Be(1065008299U);
        }

        private const string JSON =
            @"{
                ""ids"": {
                  ""trakt"": 73640,
                  ""tvdb"": 3254641,
                  ""imdb"": ""tt1480055"",
                  ""tmdb"": 63056,
                  ""tvrage"": 1065008299
                }
              }";
    }
}
