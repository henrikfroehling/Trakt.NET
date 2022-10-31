namespace TraktNet.Objects.Post.Tests.Syncs.Recommendations.Json.Writer
{
    using FluentAssertions;
    using System;
    using System.IO;
    using System.Threading.Tasks;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Objects.Get.Shows;
    using TraktNet.Objects.Post.Syncs.Recommendations;
    using TraktNet.Objects.Post.Syncs.Recommendations.Json.Writer;
    using Xunit;

    [TestCategory("Objects.Post.Syncs.Recommendations.JsonWriter")]
    public partial class SyncRecommendationsPostShowObjectJsonWriter_Tests
    {
        [Fact]
        public async Task Test_SyncRecommendationsPostShowObjectJsonWriter_WriteObject_StringWriter_Exceptions()
        {
            var traktJsonWriter = new SyncRecommendationsPostShowObjectJsonWriter();
            ITraktSyncRecommendationsPostShow traktSyncRecommendationsPostShow = new TraktSyncRecommendationsPostShow();
            Func<Task<string>> action = () => traktJsonWriter.WriteObjectAsync(default(StringWriter), traktSyncRecommendationsPostShow);
            await action.Should().ThrowAsync<ArgumentNullException>();
        }

        [Fact]
        public async Task Test_SyncRecommendationsPostShowObjectJsonWriter_WriteObject_StringWriter_Complete()
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
            var traktJsonWriter = new SyncRecommendationsPostShowObjectJsonWriter();
            string json = await traktJsonWriter.WriteObjectAsync(stringWriter, traktSyncRecommendationsPostShow);
            json.Should().Be(@"{""title"":""Breaking Bad"",""year"":2008," +
                             @"""ids"":{""trakt"":1,""slug"":""breaking-bad""," +
                             @"""tvdb"":81189,""imdb"":""tt0903747"",""tmdb"":1396}," +
                             @"""notes"":""I AM THE DANGER!""}");
        }
    }
}
