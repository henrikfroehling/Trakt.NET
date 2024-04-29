namespace TraktNet.Objects.Post.Tests.Syncs.Favorites.Implementations
{
    using FluentAssertions;
    using System.Threading.Tasks;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Objects.Post.Syncs.Favorites;
    using TraktNet.Objects.Post.Syncs.Favorites.Json.Reader;
    using Xunit;

    [TestCategory("Objects.Post.Syncs.Favorites.Implementations")]
    public class  TraktSyncFavoritesPostShow_Tests
    {
        [Fact]
        public void Test_TraktSyncFavoritesPostShow_Default_Constructor()
        {
            var syncFavoritesPostShow = new TraktSyncFavoritesPostShow();

            syncFavoritesPostShow.Title.Should().BeNull();
            syncFavoritesPostShow.Year.Should().BeNull();
            syncFavoritesPostShow.Ids.Should().BeNull();
            syncFavoritesPostShow.Notes.Should().BeNull();
        }

        [Fact]
        public async Task Test_TraktSyncFavoritesPostShow_From_Json()
        {
            var jsonReader = new SyncFavoritesPostShowObjectJsonReader();
            var syncFavoritesPostShow = await jsonReader.ReadObjectAsync(JSON) as TraktSyncFavoritesPostShow;

            syncFavoritesPostShow.Should().NotBeNull();

            syncFavoritesPostShow.Title.Should().Be("Breaking Bad");
            syncFavoritesPostShow.Year.Should().Be(2008);
            syncFavoritesPostShow.Ids.Should().NotBeNull();
            syncFavoritesPostShow.Ids.Trakt.Should().Be(1U);
            syncFavoritesPostShow.Ids.Slug.Should().Be("breaking-bad");
            syncFavoritesPostShow.Ids.Tvdb.Should().Be(81189U);
            syncFavoritesPostShow.Ids.Imdb.Should().Be("tt0903747");
            syncFavoritesPostShow.Ids.Tmdb.Should().Be(1396U);
            syncFavoritesPostShow.Notes.Should().Be("I AM THE DANGER!");
        }

        private const string JSON =
            @"{
                ""title"": ""Breaking Bad"",
                ""year"": 2008,
                ""ids"": {
                  ""trakt"": 1,
                  ""slug"": ""breaking-bad"",
                  ""tvdb"": 81189,
                  ""imdb"": ""tt0903747"",
                  ""tmdb"": 1396
                },
                ""notes"": ""I AM THE DANGER!""
              }";
    }
}
