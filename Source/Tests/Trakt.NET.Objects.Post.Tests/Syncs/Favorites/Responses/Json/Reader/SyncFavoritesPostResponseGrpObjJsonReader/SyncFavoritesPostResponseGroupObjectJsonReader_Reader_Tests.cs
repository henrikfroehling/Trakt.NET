namespace TraktNet.Objects.Post.Tests.Syncs.Favorites.Responses.Json.Reader
{
    using FluentAssertions;
    using Newtonsoft.Json;
    using System;
    using System.IO;
    using System.Threading.Tasks;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Objects.Post.Syncs.Favorites.Responses;
    using TraktNet.Objects.Post.Syncs.Favorites.Responses.Json.Reader;
    using Xunit;

    [TestCategory("Objects.Post.Syncs.Favorites.Responses.JsonReader")]
    public partial class SyncFavoritesPostResponseGroupObjectJsonReader_Tests
    {
        [Fact]
        public async Task Test_SyncFavoritesPostResponseGroupObjectJsonReader_ReadObject_From_JsonReader_Complete()
        {
            var traktJsonReader = new SyncFavoritesPostResponseGroupObjectJsonReader();

            using var reader = new StringReader(JSON_COMPLETE);
            using var jsonReader = new JsonTextReader(reader);
            ITraktSyncFavoritesPostResponseGroup traktSyncFavoritesPostResponseGroup = await traktJsonReader.ReadObjectAsync(jsonReader);

            traktSyncFavoritesPostResponseGroup.Should().NotBeNull();
            traktSyncFavoritesPostResponseGroup.Movies.Should().Be(1);
            traktSyncFavoritesPostResponseGroup.Shows.Should().Be(2);
        }

        [Fact]
        public async Task Test_SyncFavoritesPostResponseGroupObjectJsonReader_ReadObject_From_JsonReader_Null()
        {
            var traktJsonReader = new SyncFavoritesPostResponseGroupObjectJsonReader();
            Func<Task<ITraktSyncFavoritesPostResponseGroup>> traktSyncFavoritesPostResponseGroup = () => traktJsonReader.ReadObjectAsync(default(JsonTextReader));
            await traktSyncFavoritesPostResponseGroup.Should().ThrowAsync<ArgumentNullException>();
        }

        [Fact]
        public async Task Test_SyncFavoritesPostResponseGroupObjectJsonReader_ReadObject_From_JsonReader_Empty()
        {
            var traktJsonReader = new SyncFavoritesPostResponseGroupObjectJsonReader();

            using var reader = new StringReader(string.Empty);
            using var jsonReader = new JsonTextReader(reader);
            ITraktSyncFavoritesPostResponseGroup traktSyncFavoritesPostResponseGroup = await traktJsonReader.ReadObjectAsync(jsonReader);
            traktSyncFavoritesPostResponseGroup.Should().BeNull();
        }
    }
}
