namespace TraktNet.Objects.Post.Tests.Syncs.Favorites.Responses.Json.Writer
{
    using FluentAssertions;
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Objects.Get.Movies;
    using TraktNet.Objects.Get.Shows;
    using TraktNet.Objects.Post.Syncs.Favorites;
    using TraktNet.Objects.Post.Syncs.Favorites.Responses;
    using TraktNet.Objects.Post.Syncs.Favorites.Responses.Json.Writer;
    using Xunit;

    [TestCategory("Objects.Post.Syncs.Favorites.Responses.JsonWriter")]
    public partial class SyncFavoritesPostResponseNotFoundGroupObjectJsonWriter_Tests
    {
        [Fact]
        public async Task Test_SyncFavoritesPostResponseNotFoundGroupObjectJsonWriter_WriteObject_Object_Exceptions()
        {
            var traktJsonWriter = new SyncFavoritesPostResponseNotFoundGroupObjectJsonWriter();
            Func<Task<string>> action = () => traktJsonWriter.WriteObjectAsync(default);
            await action.Should().ThrowAsync<ArgumentNullException>();
        }

        [Fact]
        public async Task Test_SyncFavoritesPostResponseNotFoundGroupObjectJsonWriter_WriteObject_Object_Complete()
        {
            ITraktSyncFavoritesPostResponseNotFoundGroup traktSyncFavoritesPostResponseNotFoundGroup = new TraktSyncFavoritesPostResponseNotFoundGroup
            {
                Movies = new List<ITraktSyncFavoritesPostMovie>
                {
                    new TraktSyncFavoritesPostMovie
                    {
                        Ids = new TraktMovieIds
                        {
                            Imdb = "tt0000111"
                        }
                    }
                },
                Shows = new List<ITraktSyncFavoritesPostShow>
                {
                    new TraktSyncFavoritesPostShow
                    {
                        Ids = new TraktShowIds
                        {
                            Imdb = "tt0000222"
                        }
                    }
                }
            };

            var traktJsonWriter = new SyncFavoritesPostResponseNotFoundGroupObjectJsonWriter();
            string json = await traktJsonWriter.WriteObjectAsync(traktSyncFavoritesPostResponseNotFoundGroup);
            json.Should().Be(@"{""movies"":[{""ids"":{""trakt"":0,""imdb"":""tt0000111""}}]," +
                             @"""shows"":[{""ids"":{""trakt"":0,""imdb"":""tt0000222""}}]}");
        }
    }
}
