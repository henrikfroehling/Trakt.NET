namespace TraktNET.Json.Comments
{
    public sealed class TraktCommentUserStatsTests
    {
        [Fact]
        public void TestTraktCommentUserStatsConstructor()
        {
            var commentUserStats = new TraktCommentUserStats();

            commentUserStats.Rating.ShouldBeNull();
            commentUserStats.PlayCount.ShouldBeNull();
            commentUserStats.CompletedCount.ShouldBeNull();
        }

        [Fact]
        public async Task TestTraktCommentUserStatsFromJson()
        {
            TraktCommentUserStats? commentUserStats = await TraktTestUtility.DeserializeJsonAsync<TraktCommentUserStats>("Comments\\commentuserstats.json");

            commentUserStats.ShouldNotBeNull();

            commentUserStats!.Rating.ShouldBe(9U);
            commentUserStats!.PlayCount.ShouldBe(3U);
            commentUserStats!.CompletedCount.ShouldBe(1U);
        }
    }
}
