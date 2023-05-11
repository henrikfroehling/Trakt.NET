namespace TraktNet.Objects.Basic.Tests.Implementations
{
    using FluentAssertions;
    using System.Threading.Tasks;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Objects.Basic;
    using TraktNet.Objects.Basic.Json.Reader;
    using Xunit;

    [TestCategory("Objects.Basic.Implementations")]
    public class TraktStudioIds_Tests
    {
        [Fact]
        public void Test_TraktStudioIds_Default_Constructor()
        {
            var traktStudioIds = new TraktStudioIds();

            traktStudioIds.Trakt.Should().Be(0);
            traktStudioIds.Slug.Should().BeNull();
            traktStudioIds.Tmdb.Should().BeNull();
        }

        [Fact]
        public async Task Test_TraktStudioIds_From_Json()
        {
            var jsonReader = new StudioIdsObjectJsonReader();
            var traktStudioIds = await jsonReader.ReadObjectAsync(JSON) as TraktStudioIds;

            traktStudioIds.Should().NotBeNull();
            traktStudioIds.Trakt.Should().Be(20U);
            traktStudioIds.Slug.Should().Be("20th-century-fox");
            traktStudioIds.Tmdb.Should().Be(25U);
        }

        private const string JSON =
            @"{
                ""trakt"": 20,
                ""slug"": ""20th-century-fox"",
                ""tmdb"": 25
              }";
    }
}
