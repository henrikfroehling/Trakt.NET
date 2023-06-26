namespace TraktNet.Objects.Basic.Tests.Implementations
{
    using FluentAssertions;
    using System.Threading.Tasks;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Objects.Basic;
    using TraktNet.Objects.Basic.Json.Reader;
    using Xunit;

    [TestCategory("Objects.Basic.Implementations")]
    public class TraktNetworkIds_Tests
    {
        [Fact]
        public void Test_TraktNetworkIds_Default_Constructor()
        {
            var traktNetworkIds = new TraktNetworkIds();

            traktNetworkIds.Trakt.Should().Be(0U);
            traktNetworkIds.Tmdb.Should().Be(0U);
        }

        [Fact]
        public async Task Test_TraktNetworkIds_From_Json()
        {
            var jsonReader = new NetworkIdsObjectJsonReader();
            var traktNetworkIds = await jsonReader.ReadObjectAsync(JSON) as TraktNetworkIds;

            traktNetworkIds.Should().NotBeNull();
            traktNetworkIds.Trakt.Should().Be(16U);
            traktNetworkIds.Tmdb.Should().Be(2U);
        }

        private const string JSON =
            @"{
                ""trakt"": 16,
                ""tmdb"": 2
              }";
    }
}
