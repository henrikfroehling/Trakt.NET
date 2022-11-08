namespace TraktNet.Objects.Post.Tests.Syncs.Recommendations.Responses.Json.Reader
{
    using FluentAssertions;
    using System;
    using System.Threading.Tasks;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Objects.Post.Syncs.Recommendations.Responses;
    using TraktNet.Objects.Post.Syncs.Recommendations.Responses.Json.Reader;
    using Xunit;

    [TestCategory("Objects.Post.Syncs.Recommendations.Responses.JsonReader")]
    public partial class SyncRecommendationsPostResponseGroupObjectJsonReader_Tests
    {
        [Fact]
        public async Task Test_SyncRecommendationsPostResponseGroupObjectJsonReader_ReadObject_From_Json_String_Complete()
        {
            var traktJsonReader = new SyncRecommendationsPostResponseGroupObjectJsonReader();
            ITraktSyncRecommendationsPostResponseGroup traktSyncRecommendationsPostResponseGroup = await traktJsonReader.ReadObjectAsync(JSON_COMPLETE);

            traktSyncRecommendationsPostResponseGroup.Should().NotBeNull();
            traktSyncRecommendationsPostResponseGroup.Movies.Should().Be(1);
            traktSyncRecommendationsPostResponseGroup.Shows.Should().Be(2);
        }

        [Fact]
        public async Task Test_SyncRecommendationsPostResponseGroupObjectJsonReader_ReadObject_From_Json_String_Null()
        {
            var traktJsonReader = new SyncRecommendationsPostResponseGroupObjectJsonReader();
            Func<Task<ITraktSyncRecommendationsPostResponseGroup>> traktSyncRecommendationsPostResponseGroup = () => traktJsonReader.ReadObjectAsync(default(string));
            await traktSyncRecommendationsPostResponseGroup.Should().ThrowAsync<ArgumentNullException>();
        }

        [Fact]
        public async Task Test_SyncRecommendationsPostResponseGroupObjectJsonReader_ReadObject_From_Json_String_Empty()
        {
            var traktJsonReader = new SyncRecommendationsPostResponseGroupObjectJsonReader();
            ITraktSyncRecommendationsPostResponseGroup traktSyncRecommendationsPostResponseGroup = await traktJsonReader.ReadObjectAsync(string.Empty);
            traktSyncRecommendationsPostResponseGroup.Should().BeNull();
        }
    }
}
