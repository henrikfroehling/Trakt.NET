namespace TraktNet.Objects.Basic.Tests.Implementations
{
    using FluentAssertions;
    using System.Threading.Tasks;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Objects.Basic;
    using TraktNet.Objects.Basic.Json.Reader;
    using Xunit;

    [TestCategory("Objects.Basic.Implementations")]
    public class TraktCommentUserStats_Tests
    {
        [Fact]
        public void Test_TraktCommentUserStats_Default_Constructor()
        {
            var traktCommentUserStats = new TraktCommentUserStats();

            traktCommentUserStats.Rating.Should().BeNull();
            traktCommentUserStats.PlayCount.Should().BeNull();
            traktCommentUserStats.CompletedCount.Should().BeNull();
        }

        [Fact]
        public async Task Test_TraktCommentUserStats_From_Json()
        {
            var jsonReader = new CommentUserStatsObjectJsonReader();
            var traktCommentUserStats = await jsonReader.ReadObjectAsync(JSON) as TraktCommentUserStats;

            traktCommentUserStats.Should().NotBeNull();
            traktCommentUserStats.Rating.Should().Be(8);
            traktCommentUserStats.PlayCount.Should().Be(1);
            traktCommentUserStats.CompletedCount.Should().Be(1);
        }

        private const string JSON =
            @"{
                ""rating"": 8,
                ""play_count"": 1,
                ""completed_count"": 1
              }";
    }
}
