namespace TraktNet.Objects.Post.Tests.Syncs.Recommendations.Responses.Json.Writer
{
    using FluentAssertions;
    using System;
    using System.IO;
    using System.Threading.Tasks;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Objects.Post.Syncs.Recommendations.Responses;
    using TraktNet.Objects.Post.Syncs.Recommendations.Responses.Json.Writer;
    using Xunit;

    [Category("Objects.Post.Syncs.Recommendations.Responses.JsonWriter")]
    public partial class SyncRecommendationsPostResponseGroupObjectJsonWriter_Tests
    {
        [Fact]
        public async Task Test_SyncRecommendationsPostResponseGroupObjectJsonWriter_WriteObject_StringWriter_Exceptions()
        {
            var traktJsonWriter = new SyncRecommendationsPostResponseGroupObjectJsonWriter();
            ITraktSyncRecommendationsPostResponseGroup traktSyncRecommendationsPostResponseGroup = new TraktSyncRecommendationsPostResponseGroup();
            Func<Task<string>> action = () => traktJsonWriter.WriteObjectAsync(default(StringWriter), traktSyncRecommendationsPostResponseGroup);
            await action.Should().ThrowAsync<ArgumentNullException>();
        }

        [Fact]
        public async Task Test_SyncRecommendationsPostResponseGroupObjectJsonWriter_WriteObject_StringWriter_Complete()
        {
            ITraktSyncRecommendationsPostResponseGroup traktSyncRecommendationsPostResponseGroup = new TraktSyncRecommendationsPostResponseGroup
            {
                Movies = 1,
                Shows = 2
            };

            using var stringWriter = new StringWriter();
            var traktJsonWriter = new SyncRecommendationsPostResponseGroupObjectJsonWriter();
            string json = await traktJsonWriter.WriteObjectAsync(stringWriter, traktSyncRecommendationsPostResponseGroup);
            json.Should().Be(@"{""movies"":1,""shows"":2}");
        }
    }
}
