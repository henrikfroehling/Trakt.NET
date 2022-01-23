namespace TraktNet.Objects.Post.Tests.Syncs.Recommendations.Responses.Json.Writer
{
    using FluentAssertions;
    using Newtonsoft.Json;
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
        public async Task Test_SyncRecommendationsPostResponseGroupObjectJsonWriter_WriteObject_JsonWriter_Exceptions()
        {
            var traktJsonWriter = new SyncRecommendationsPostResponseGroupObjectJsonWriter();
            ITraktSyncRecommendationsPostResponseGroup traktSyncRecommendationsPostResponseGroup = new TraktSyncRecommendationsPostResponseGroup();
            Func<Task> action = () => traktJsonWriter.WriteObjectAsync(default(JsonTextWriter), traktSyncRecommendationsPostResponseGroup);
            await action.Should().ThrowAsync<ArgumentNullException>();
        }

        [Fact]
        public async Task Test_SyncRecommendationsPostResponseGroupObjectJsonWriter_WriteObject_JsonWriter_Complete()
        {
            ITraktSyncRecommendationsPostResponseGroup traktSyncRecommendationsPostResponseGroup = new TraktSyncRecommendationsPostResponseGroup
            {
                Movies = 1,
                Shows = 2
            };

            using var stringWriter = new StringWriter();
            using var jsonWriter = new JsonTextWriter(stringWriter);
            var traktJsonWriter = new SyncRecommendationsPostResponseGroupObjectJsonWriter();
            await traktJsonWriter.WriteObjectAsync(jsonWriter, traktSyncRecommendationsPostResponseGroup);
            stringWriter.ToString().Should().Be(@"{""movies"":1,""shows"":2}");
        }
    }
}
