namespace TraktNet.Objects.Post.Tests.Syncs.Favorites.Json.Writer
{
    using FluentAssertions;
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Objects.Get.Movies;
    using TraktNet.Objects.Get.Shows;
    using TraktNet.Objects.Post.Syncs.Favorites;
    using TraktNet.Objects.Post.Syncs.Favorites.Json.Writer;
    using Xunit;

    [TestCategory("Objects.Post.Syncs.Favorites.JsonWriter")]
    public partial class SyncFavoritesPostObjectJsonWriter_Tests
    {
        [Fact]
        public async Task Test_SyncFavoritesPostObjectJsonWriter_WriteObject_Object_Exceptions()
        {
            var traktJsonWriter = new SyncFavoritesPostObjectJsonWriter();
            Func<Task<string>> action = () => traktJsonWriter.WriteObjectAsync(default);
            await action.Should().ThrowAsync<ArgumentNullException>();
        }

        [Fact]
        public async Task Test_SyncFavoritesPostObjectJsonWriter_WriteObject_Object_Complete()
        {
            ITraktSyncFavoritesPost traktSyncFavoritesPost = new TraktSyncFavoritesPost
            {
                Movies = new List<ITraktSyncFavoritesPostMovie>
                {
                    new TraktSyncFavoritesPostMovie
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
                    },
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
                    },
                    new TraktSyncFavoritesPostShow
                    {
                        Title = "The Walking Dead",
                        Year = 2010,
                        Ids = new TraktShowIds
                        {
                            Trakt = 2,
                            Slug = "the-walking-dead",
                            Tvdb = 153021,
                            Imdb = "tt1520211",
                            Tmdb = 1402
                        }
                    }
                }
            };

            var traktJsonWriter = new SyncFavoritesPostObjectJsonWriter();
            string json = await traktJsonWriter.WriteObjectAsync(traktSyncFavoritesPost);
            json.Should().Be(@"{""movies"":[{""title"":""Batman Begins"",""year"":2005," +
                             @"""ids"":{""trakt"":1,""slug"":""batman-begins-2005""," +
                             @"""imdb"":""tt0372784"",""tmdb"":272}," +
                             @"""notes"":""One of Chritian Bale's most iconic roles.""}," +
                             @"{""ids"":{""trakt"":0,""imdb"":""tt0000111""}}]," +
                             @"""shows"":[{""title"":""Breaking Bad"",""year"":2008," +
                             @"""ids"":{""trakt"":1,""slug"":""breaking-bad""," +
                             @"""tvdb"":81189,""imdb"":""tt0903747"",""tmdb"":1396}," +
                             @"""notes"":""I AM THE DANGER!""}," +
                             @"{""title"":""The Walking Dead"",""year"":2010," +
                             @"""ids"":{""trakt"":2,""slug"":""the-walking-dead""," +
                             @"""tvdb"":153021,""imdb"":""tt1520211"",""tmdb"":1402}}]}");
        }
    }
}
