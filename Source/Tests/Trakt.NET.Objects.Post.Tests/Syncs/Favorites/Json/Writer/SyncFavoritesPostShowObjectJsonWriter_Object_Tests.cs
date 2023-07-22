namespace TraktNet.Objects.Post.Tests.Syncs.Favorites.Json.Writer
{
    using FluentAssertions;
    using System;
    using System.Threading.Tasks;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Objects.Get.Shows;
    using TraktNet.Objects.Post.Syncs.Favorites;
    using TraktNet.Objects.Post.Syncs.Favorites.Json.Writer;
    using Xunit;

    [TestCategory("Objects.Post.Syncs.Favorites.JsonWriter")]
    public partial class SyncFavoritesPostShowObjectJsonWriter_Tests
    {
        [Fact]
        public async Task Test_SyncFavoritesPostShowObjectJsonWriter_WriteObject_Object_Exceptions()
        {
            var traktJsonWriter = new SyncFavoritesPostShowObjectJsonWriter();
            Func<Task<string>> action = () => traktJsonWriter.WriteObjectAsync(default);
            await action.Should().ThrowAsync<ArgumentNullException>();
        }

        [Fact]
        public async Task Test_SyncFavoritesPostShowObjectJsonWriter_WriteObject_Object_Complete()
        {
            ITraktSyncFavoritesPostShow traktSyncFavoritesPostShow = new TraktSyncFavoritesPostShow
            {
                Title = "Breaking Bad",
                Year = 2008,
                Ids = new TraktShowIds
                {
                    Trakt = 1,
                    Slug = "breaking-bad",
                    Tvdb = 81189,
                    Imdb = "tt0903747",
                    Tmdb = 1396
                },
                Notes = "I AM THE DANGER!"
            };

            var traktJsonWriter = new SyncFavoritesPostShowObjectJsonWriter();
            string json = await traktJsonWriter.WriteObjectAsync(traktSyncFavoritesPostShow);
            json.Should().Be(@"{""title"":""Breaking Bad"",""year"":2008," +
                             @"""ids"":{""trakt"":1,""slug"":""breaking-bad""," +
                             @"""tvdb"":81189,""imdb"":""tt0903747"",""tmdb"":1396}," +
                             @"""notes"":""I AM THE DANGER!""}");
        }
    }
}
