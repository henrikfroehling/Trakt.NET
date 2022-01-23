namespace TraktNet.Objects.Post.Tests.Syncs.Recommendations.Json.Writer
{
    using FluentAssertions;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Threading.Tasks;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Objects.Get.Movies;
    using TraktNet.Objects.Get.Shows;
    using TraktNet.Objects.Post.Syncs.Recommendations;
    using TraktNet.Objects.Post.Syncs.Recommendations.Json.Writer;
    using Xunit;

    [Category("Objects.Post.Syncs.Recommendations.JsonWriter")]
    public partial class SyncRecommendationsPostObjectJsonWriter_Tests
    {
        [Fact]
        public async Task Test_SyncRecommendationsPostObjectJsonWriter_WriteObject_StringWriter_Exceptions()
        {
            var traktJsonWriter = new SyncRecommendationsPostObjectJsonWriter();
            ITraktSyncRecommendationsPost traktSyncRecommendationsPost = new TraktSyncRecommendationsPost();
            Func<Task<string>> action = () => traktJsonWriter.WriteObjectAsync(default(StringWriter), traktSyncRecommendationsPost);
            await action.Should().ThrowAsync<ArgumentNullException>();
        }

        [Fact]
        public async Task Test_SyncRecommendationsPostObjectJsonWriter_WriteObject_StringWriter_Complete()
        {
            ITraktSyncRecommendationsPost traktSyncRecommendationsPost = new TraktSyncRecommendationsPost
            {
                Movies = new List<ITraktSyncRecommendationsPostMovie>
                {
                    new TraktSyncRecommendationsPostMovie
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
                    new TraktSyncRecommendationsPostMovie
                    {
                        Ids = new TraktMovieIds
                        {
                            Imdb = "tt0000111"
                        }
                    }
                },
                Shows = new List<ITraktSyncRecommendationsPostShow>
                {
                    new TraktSyncRecommendationsPostShow
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
                    new TraktSyncRecommendationsPostShow
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

            using var stringWriter = new StringWriter();
            var traktJsonWriter = new SyncRecommendationsPostObjectJsonWriter();
            string json = await traktJsonWriter.WriteObjectAsync(stringWriter, traktSyncRecommendationsPost);
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
