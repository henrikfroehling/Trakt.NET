namespace TraktNet.Objects.Post.Tests.Syncs.Favorites.Json.Reader
{
    using FluentAssertions;
    using Newtonsoft.Json;
    using System;
    using System.IO;
    using System.Threading.Tasks;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Objects.Post.Syncs.Favorites;
    using TraktNet.Objects.Post.Syncs.Favorites.Json.Reader;
    using Xunit;

    [TestCategory("Objects.Post.Syncs.Favorites.JsonReader")]
    public partial class SyncFavoritesPostShowObjectJsonReader_Tests
    {
        [Fact]
        public async Task Test_SyncFavoritesPostShowObjectJsonReader_ReadObject_From_JsonReader_Complete()
        {
            var traktJsonReader = new SyncFavoritesPostShowObjectJsonReader();

            using var reader = new StringReader(JSON_COMPLETE);
            using var jsonReader = new JsonTextReader(reader);
            ITraktSyncFavoritesPostShow traktSyncFavoritesPostShow = await traktJsonReader.ReadObjectAsync(jsonReader);

            traktSyncFavoritesPostShow.Should().NotBeNull();
            traktSyncFavoritesPostShow.Title.Should().Be("Breaking Bad");
            traktSyncFavoritesPostShow.Year.Should().Be(2008);
            traktSyncFavoritesPostShow.Ids.Should().NotBeNull();
            traktSyncFavoritesPostShow.Ids.Trakt.Should().Be(1U);
            traktSyncFavoritesPostShow.Ids.Slug.Should().Be("breaking-bad");
            traktSyncFavoritesPostShow.Ids.Tvdb.Should().Be(81189U);
            traktSyncFavoritesPostShow.Ids.Imdb.Should().Be("tt0903747");
            traktSyncFavoritesPostShow.Ids.Tmdb.Should().Be(1396U);
            traktSyncFavoritesPostShow.Notes.Should().Be("I AM THE DANGER!");
        }

        [Fact]
        public async Task Test_SyncFavoritesPostShowObjectJsonReader_ReadObject_From_JsonReader_Null()
        {
            var traktJsonReader = new SyncFavoritesPostShowObjectJsonReader();
            Func<Task<ITraktSyncFavoritesPostShow>> traktSyncFavoritesPostShow = () => traktJsonReader.ReadObjectAsync(default(JsonTextReader));
            await traktSyncFavoritesPostShow.Should().ThrowAsync<ArgumentNullException>();
        }

        [Fact]
        public async Task Test_SyncFavoritesPostShowObjectJsonReader_ReadObject_From_JsonReader_Empty()
        {
            var traktJsonReader = new SyncFavoritesPostShowObjectJsonReader();

            using var reader = new StringReader(string.Empty);
            using var jsonReader = new JsonTextReader(reader);
            ITraktSyncFavoritesPostShow traktSyncFavoritesPostShow = await traktJsonReader.ReadObjectAsync(jsonReader);
            traktSyncFavoritesPostShow.Should().BeNull();
        }
    }
}
