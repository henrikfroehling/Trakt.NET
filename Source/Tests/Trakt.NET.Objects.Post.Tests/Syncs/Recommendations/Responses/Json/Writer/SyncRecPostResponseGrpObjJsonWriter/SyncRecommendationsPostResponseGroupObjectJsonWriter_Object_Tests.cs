namespace TraktNet.Objects.Post.Tests.Syncs.Recommendations.Responses.Json.Writer
{
    using FluentAssertions;
    using System;
    using System.Threading.Tasks;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Objects.Post.Syncs.Recommendations.Responses;
    using TraktNet.Objects.Post.Syncs.Recommendations.Responses.Json.Writer;
    using Xunit;

    [TestCategory("Objects.Post.Syncs.Recommendations.Responses.JsonWriter")]
    public partial class SyncRecommendationsPostResponseGroupObjectJsonWriter_Tests
    {
        [Fact]
        public async Task Test_SyncRecommendationsPostResponseGroupObjectJsonWriter_WriteObject_Object_Exceptions()
        {
            var traktJsonWriter = new SyncRecommendationsPostResponseGroupObjectJsonWriter();
            Func<Task<string>> action = () => traktJsonWriter.WriteObjectAsync(default);
            await action.Should().ThrowAsync<ArgumentNullException>();
        }

        [Fact]
        public async Task Test_SyncRecommendationsPostResponseGroupObjectJsonWriter_WriteObject_Object_Complete()
        {
            ITraktSyncRecommendationsPostResponseGroup traktSyncRecommendationsPostResponseGroup = new TraktSyncRecommendationsPostResponseGroup
            {
                Movies = 1,
                Shows = 2
            };

            var traktJsonWriter = new SyncRecommendationsPostResponseGroupObjectJsonWriter();
            string json = await traktJsonWriter.WriteObjectAsync(traktSyncRecommendationsPostResponseGroup);
            json.Should().Be(@"{""movies"":1,""shows"":2}");
        }
    }
}
