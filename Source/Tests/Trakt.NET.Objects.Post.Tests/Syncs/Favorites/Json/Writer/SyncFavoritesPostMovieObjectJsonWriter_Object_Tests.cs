namespace TraktNet.Objects.Post.Tests.Syncs.Favorites.Json.Writer
{
    using FluentAssertions;
    using System;
    using System.Threading.Tasks;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Objects.Get.Movies;
    using TraktNet.Objects.Post.Syncs.Favorites;
    using TraktNet.Objects.Post.Syncs.Favorites.Json.Writer;
    using Xunit;

    [TestCategory("Objects.Post.Syncs.Favorites.JsonWriter")]
    public partial class SyncFavoritesPostMovieObjectJsonWriter_Tests
    {
        [Fact]
        public async Task Test_SyncFavoritesPostMovieObjectJsonWriter_WriteObject_Object_Exceptions()
        {
            var traktJsonWriter = new SyncFavoritesPostMovieObjectJsonWriter();
            Func<Task<string>> action = () => traktJsonWriter.WriteObjectAsync(default);
            await action.Should().ThrowAsync<ArgumentNullException>();
        }

        [Fact]
        public async Task Test_SyncFavoritesPostMovieObjectJsonWriter_WriteObject_Object_Complete()
        {
            ITraktSyncFavoritesPostMovie traktSyncFavoritesPostMovie = new TraktSyncFavoritesPostMovie
            {
                Title = "Batman Begins",
                Year = 2005,
                Ids = new TraktMovieIds
                {
                    Trakt = 1,
                    Slug = "batman-begins-2005",
                    Imdb = "tt0372784",
                    Tmdb = 272
                },
                Notes = "One of Chritian Bale's most iconic roles."
            };

            var traktJsonWriter = new SyncFavoritesPostMovieObjectJsonWriter();
            string json = await traktJsonWriter.WriteObjectAsync(traktSyncFavoritesPostMovie);
            json.Should().Be(@"{""title"":""Batman Begins"",""year"":2005," +
                             @"""ids"":{""trakt"":1,""slug"":""batman-begins-2005""," +
                             @"""imdb"":""tt0372784"",""tmdb"":272}," +
                             @"""notes"":""One of Chritian Bale's most iconic roles.""}");
        }
    }
}
