namespace TraktApiSharp.Tests.Objects.Basic.Implementations
{
    using FluentAssertions;
    using System.Threading.Tasks;
    using Traits;
    using TraktApiSharp.Objects.Basic.Implementations;
    using TraktApiSharp.Objects.Basic.Json;
    using Xunit;

    [Category("Objects.Basic.Implementations")]
    public class TraktIds_Tests
    {
        [Fact]
        public void Test_TraktIds_Default_Constructor()
        {
            var traktIds = new TraktIds();

            traktIds.Trakt.Should().Be(0);
            traktIds.Slug.Should().BeNull();
            traktIds.Tvdb.Should().BeNull();
            traktIds.Imdb.Should().BeNull();
            traktIds.Tmdb.Should().BeNull();
            traktIds.TvRage.Should().BeNull();
        }

        [Fact]
        public async Task Test_TraktIds_From_Json()
        {
            var jsonReader = new IdsObjectJsonReader();
            var traktIds = await jsonReader.ReadObjectAsync(JSON) as TraktIds;

            traktIds.Should().NotBeNull();
            traktIds.Trakt.Should().Be(1390);
            traktIds.Slug.Should().Be("game-of-thrones");
            traktIds.Tvdb.Should().Be(121361U);
            traktIds.Imdb.Should().Be("tt0944947");
            traktIds.Tmdb.Should().Be(1399U);
            traktIds.TvRage.Should().Be(24493U);
        }

        private const string JSON =
            @"{
                ""trakt"": 1390,
                ""slug"": ""game-of-thrones"",
                ""tvdb"": 121361,
                ""imdb"": ""tt0944947"",
                ""tmdb"": 1399,
                ""tvrage"": 24493
              }";
    }
}
