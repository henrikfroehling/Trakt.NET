namespace TraktNet.Objects.Post.Tests.Syncs.Recommendations.Responses.Implementations
{
    using FluentAssertions;
    using System.Threading.Tasks;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Objects.Post.Syncs.Recommendations.Responses;
    using TraktNet.Objects.Post.Syncs.Recommendations.Responses.Json.Reader;
    using Xunit;

    [Category("Objects.Post.Syncs.Recommendations.Responses.Implementations")]
    public class TraktSyncRecommendationsPostResponseGroup_Tests
    {
        [Fact]
        public void Test_TraktSyncRecommendationsPostResponseGroup_Default_Constructor()
        {
            var syncRecommendationsPostResponseGroup = new TraktSyncRecommendationsPostResponseGroup();

            syncRecommendationsPostResponseGroup.Movies.Should().BeNull();
            syncRecommendationsPostResponseGroup.Shows.Should().BeNull();
        }

        [Fact]
        public async Task Test_TraktSyncRecommendationsPostResponseGroup_From_Json()
        {
            var jsonReader = new SyncRecommendationsPostResponseGroupObjectJsonReader();
            var syncRecommendationsPostResponseGroup = await jsonReader.ReadObjectAsync(JSON) as TraktSyncRecommendationsPostResponseGroup;

            syncRecommendationsPostResponseGroup.Should().NotBeNull();

            syncRecommendationsPostResponseGroup.Movies.Should().Be(1);
            syncRecommendationsPostResponseGroup.Shows.Should().Be(2);
        }

        private const string JSON =
            @"{
                ""movies"": 1,
                ""shows"": 2
              }";
    }
}
