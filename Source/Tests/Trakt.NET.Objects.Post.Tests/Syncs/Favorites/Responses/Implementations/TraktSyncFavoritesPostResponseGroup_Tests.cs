namespace TraktNet.Objects.Post.Tests.Syncs.Favorites.Responses.Implementations
{
    using FluentAssertions;
    using System.Threading.Tasks;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Objects.Post.Syncs.Favorites.Responses;
    using TraktNet.Objects.Post.Syncs.Favorites.Responses.Json.Reader;
    using Xunit;

    [TestCategory("Objects.Post.Syncs.Favorites.Responses.Implementations")]
    public class TraktSyncFavoritesPostResponseGroup_Tests
    {
        [Fact]
        public void Test_TraktSyncFavoritesPostResponseGroup_Default_Constructor()
        {
            var syncFavoritesPostResponseGroup = new TraktSyncFavoritesPostResponseGroup();

            syncFavoritesPostResponseGroup.Movies.Should().BeNull();
            syncFavoritesPostResponseGroup.Shows.Should().BeNull();
        }

        [Fact]
        public async Task Test_TraktSyncFavoritesPostResponseGroup_From_Json()
        {
            var jsonReader = new SyncFavoritesPostResponseGroupObjectJsonReader();
            var syncFavoritesPostResponseGroup = await jsonReader.ReadObjectAsync(JSON) as TraktSyncFavoritesPostResponseGroup;

            syncFavoritesPostResponseGroup.Should().NotBeNull();

            syncFavoritesPostResponseGroup.Movies.Should().Be(1);
            syncFavoritesPostResponseGroup.Shows.Should().Be(2);
        }

        private const string JSON =
            @"{
                ""movies"": 1,
                ""shows"": 2
              }";
    }
}
