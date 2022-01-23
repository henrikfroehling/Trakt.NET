namespace TraktNet.Objects.Post.Tests.Syncs.Recommendations.Json.Writer
{
    using FluentAssertions;
    using Newtonsoft.Json;
    using System;
    using System.IO;
    using System.Threading.Tasks;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Objects.Get.Shows;
    using TraktNet.Objects.Post.Syncs.Recommendations;
    using TraktNet.Objects.Post.Syncs.Recommendations.Json.Writer;
    using Xunit;

    [Category("Objects.Post.Syncs.Recommendations.JsonWriter")]
    public partial class SyncRecommendationsPostShowObjectJsonWriter_Tests
    {
        [Fact]
        public async Task Test_SyncRecommendationsPostShowObjectJsonWriter_WriteObject_JsonWriter_Exceptions()
        {
            var traktJsonWriter = new SyncRecommendationsPostShowObjectJsonWriter();
            ITraktSyncRecommendationsPostShow traktSyncRecommendationsPostShow = new TraktSyncRecommendationsPostShow();
            Func<Task> action = () => traktJsonWriter.WriteObjectAsync(default(JsonTextWriter), traktSyncRecommendationsPostShow);
            await action.Should().ThrowAsync<ArgumentNullException>();
        }

        [Fact]
        public async Task Test_SyncRecommendationsPostShowObjectJsonWriter_WriteObject_JsonWriter_Complete()
        {
            ITraktSyncRecommendationsPostShow traktSyncRecommendationsPostShow = new TraktSyncRecommendationsPostShow
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

            using var stringWriter = new StringWriter();
            using var jsonWriter = new JsonTextWriter(stringWriter);
            var traktJsonWriter = new SyncRecommendationsPostShowObjectJsonWriter();
            await traktJsonWriter.WriteObjectAsync(jsonWriter, traktSyncRecommendationsPostShow);
            stringWriter.ToString().Should().Be(@"{""title"":""Breaking Bad"",""year"":2008," +
                                                @"""ids"":{""trakt"":1,""slug"":""breaking-bad""," +
                                                @"""tvdb"":81189,""imdb"":""tt0903747"",""tmdb"":1396}," +
                                                @"""notes"":""I AM THE DANGER!""}");
        }
    }
}
