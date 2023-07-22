namespace TraktNet.Objects.Post.Tests.Syncs.Favorites.Responses.Json.Writer
{
    using FluentAssertions;
    using System;
    using System.Threading.Tasks;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Objects.Post.Syncs.Favorites.Responses;
    using TraktNet.Objects.Post.Syncs.Favorites.Responses.Json.Writer;
    using Xunit;

    [TestCategory("Objects.Post.Syncs.Favorites.Responses.JsonWriter")]
    public partial class SyncFavoritesPostResponseGroupObjectJsonWriter_Tests
    {
        [Fact]
        public async Task Test_SyncFavoritesPostResponseGroupObjectJsonWriter_WriteObject_Object_Exceptions()
        {
            var traktJsonWriter = new SyncFavoritesPostResponseGroupObjectJsonWriter();
            Func<Task<string>> action = () => traktJsonWriter.WriteObjectAsync(default);
            await action.Should().ThrowAsync<ArgumentNullException>();
        }

        [Fact]
        public async Task Test_SyncFavoritesPostResponseGroupObjectJsonWriter_WriteObject_Object_Complete()
        {
            ITraktSyncFavoritesPostResponseGroup traktSyncFavoritesPostResponseGroup = new TraktSyncFavoritesPostResponseGroup
            {
                Movies = 1,
                Shows = 2
            };

            var traktJsonWriter = new SyncFavoritesPostResponseGroupObjectJsonWriter();
            string json = await traktJsonWriter.WriteObjectAsync(traktSyncFavoritesPostResponseGroup);
            json.Should().Be(@"{""movies"":1,""shows"":2}");
        }
    }
}
