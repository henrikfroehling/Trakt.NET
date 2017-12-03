namespace TraktApiSharp.Tests.Objects.Post.Responses.Implementations
{
    using FluentAssertions;
    using System.Threading.Tasks;
    using Traits;
    using TraktApiSharp.Objects.Post.Responses.Implementations;
    using TraktApiSharp.Objects.Post.Responses.Json.Reader;
    using Xunit;

    [Category("Objects.Post.Responses.Implementations")]
    public class TraktPostResponseNotFoundShow_Tests
    {
        [Fact]
        public void Test_TraktPostResponseNotFoundShow_Default_Constructor()
        {
            var postResponseNotFoundShow = new TraktPostResponseNotFoundShow();

            postResponseNotFoundShow.Ids.Should().BeNull();
        }

        [Fact]
        public async Task Test_TraktPostResponseNotFoundShow_From_Json()
        {
            var jsonReader = new PostResponseNotFoundShowObjectJsonReader();
            var postResponseNotFoundShow = await jsonReader.ReadObjectAsync(JSON) as TraktPostResponseNotFoundShow;

            postResponseNotFoundShow.Should().NotBeNull();
            postResponseNotFoundShow.Ids.Trakt.Should().Be(1390U);
            postResponseNotFoundShow.Ids.Slug.Should().Be("game-of-thrones");
            postResponseNotFoundShow.Ids.Tvdb.Should().Be(121361U);
            postResponseNotFoundShow.Ids.Imdb.Should().Be("tt0944947");
            postResponseNotFoundShow.Ids.Tmdb.Should().Be(1399U);
            postResponseNotFoundShow.Ids.TvRage.Should().Be(24493U);
        }

        private const string JSON =
            @"{
                ""ids"": {
                  ""trakt"": 1390,
                  ""slug"": ""game-of-thrones"",
                  ""tvdb"": 121361,
                  ""imdb"": ""tt0944947"",
                  ""tmdb"": 1399,
                  ""tvrage"": 24493
                }
              }";
    }
}
