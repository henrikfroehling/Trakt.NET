namespace TraktNet.Objects.Post.Tests.Syncs.Recommendations.Responses.Json.Writer
{
    using FluentAssertions;
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Threading.Tasks;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Objects.Get.Movies;
    using TraktNet.Objects.Get.Shows;
    using TraktNet.Objects.Post.Syncs.Recommendations;
    using TraktNet.Objects.Post.Syncs.Recommendations.Responses;
    using TraktNet.Objects.Post.Syncs.Recommendations.Responses.Json.Writer;
    using Xunit;

    [Category("Objects.Post.Syncs.Recommendations.Responses.JsonWriter")]
    public partial class SyncRecommendationsPostResponseObjectJsonWriter_Tests
    {
        [Fact]
        public async Task Test_SyncRecommendationsPostResponseObjectJsonWriter_WriteObject_JsonWriter_Exceptions()
        {
            var traktJsonWriter = new SyncRecommendationsPostResponseObjectJsonWriter();
            ITraktSyncRecommendationsPostResponse traktSyncRecommendationsPostResponse = new TraktSyncRecommendationsPostResponse();
            Func<Task> action = () => traktJsonWriter.WriteObjectAsync(default(JsonTextWriter), traktSyncRecommendationsPostResponse);
            await action.Should().ThrowAsync<ArgumentNullException>();
        }

        [Fact]
        public async Task Test_SyncRecommendationsPostResponseObjectJsonWriter_WriteObject_JsonWriter_Complete()
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

            using var stringWriter = new StringWriter();
            using var jsonWriter = new JsonTextWriter(stringWriter);
            var traktJsonWriter = new SyncRecommendationsPostResponseObjectJsonWriter();
            await traktJsonWriter.WriteObjectAsync(jsonWriter, traktSyncRecommendationsPostResponse);
            stringWriter.ToString().Should().Be(@"{""added"":{""movies"":1,""shows"":2}," +
                                                @"""existing"":{""movies"":3,""shows"":4}," +
                                                @"""not_found"":{""movies"":[{""ids"":{""trakt"":0,""imdb"":""tt0000111""}}]," +
                                                @"""shows"":[{""ids"":{""trakt"":0,""imdb"":""tt0000222""}}]}}");
        }
    }
}
