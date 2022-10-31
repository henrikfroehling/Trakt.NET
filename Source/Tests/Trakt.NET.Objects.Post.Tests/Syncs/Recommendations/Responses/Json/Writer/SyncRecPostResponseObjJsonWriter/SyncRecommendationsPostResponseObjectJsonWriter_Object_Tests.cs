namespace TraktNet.Objects.Post.Tests.Syncs.Recommendations.Responses.Json.Writer
{
    using FluentAssertions;
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Objects.Get.Movies;
    using TraktNet.Objects.Get.Shows;
    using TraktNet.Objects.Post.Syncs.Recommendations;
    using TraktNet.Objects.Post.Syncs.Recommendations.Responses;
    using TraktNet.Objects.Post.Syncs.Recommendations.Responses.Json.Writer;
    using Xunit;

    [TestCategory("Objects.Post.Syncs.Recommendations.Responses.JsonWriter")]
    public partial class SyncRecommendationsPostResponseObjectJsonWriter_Tests
    {
        [Fact]
        public async Task Test_SyncRecommendationsPostResponseObjectJsonWriter_WriteObject_Object_Exceptions()
        {
            var traktJsonWriter = new SyncRecommendationsPostResponseObjectJsonWriter();
            Func<Task<string>> action = () => traktJsonWriter.WriteObjectAsync(default);
            await action.Should().ThrowAsync<ArgumentNullException>();
        }

        [Fact]
        public async Task Test_SyncRecommendationsPostResponseObjectJsonWriter_WriteObject_Object_Complete()
        {
            ITraktSyncRecommendationsPostResponse traktSyncRecommendationsPostResponse = new TraktSyncRecommendationsPostResponse
            {
                Added = new TraktSyncRecommendationsPostResponseGroup
                {
                    Movies = 1,
                    Shows = 2
                },
                Existing = new TraktSyncRecommendationsPostResponseGroup
                {
                    Movies = 3,
                    Shows = 4
                },
                NotFound = new TraktSyncRecommendationsPostResponseNotFoundGroup
                {
                    Movies = new List<ITraktSyncRecommendationsPostMovie>
                    {
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
                            Ids = new TraktShowIds
                            {
                                Imdb = "tt0000222"
                            }
                        }
                    }
                }
            };

            var traktJsonWriter = new SyncRecommendationsPostResponseObjectJsonWriter();
            string json = await traktJsonWriter.WriteObjectAsync(traktSyncRecommendationsPostResponse);
            json.Should().Be(@"{""added"":{""movies"":1,""shows"":2}," +
                             @"""existing"":{""movies"":3,""shows"":4}," +
                             @"""not_found"":{""movies"":[{""ids"":{""trakt"":0,""imdb"":""tt0000111""}}]," +
                             @"""shows"":[{""ids"":{""trakt"":0,""imdb"":""tt0000222""}}]}}");
        }
    }
}
