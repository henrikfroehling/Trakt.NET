namespace TraktNET.Json.Movies
{
    public sealed class TraktMovieStatisticsTests
    {
        [Fact]
        public void TestTraktMovieStatisticsConstructor()
        {
            var movieStatistics = new TraktMovieStatistics();

            movieStatistics.Watchers.ShouldBeNull();
            movieStatistics.Plays.ShouldBeNull();
            movieStatistics.Collectors.ShouldBeNull();
            movieStatistics.Comments.ShouldBeNull();
            movieStatistics.Lists.ShouldBeNull();
            movieStatistics.Votes.ShouldBeNull();
            movieStatistics.Favorited.ShouldBeNull();
            movieStatistics.Recommended.ShouldBeNull();
        }

        [Fact]
        public async Task TestTraktMovieStatisticsFromJson()
        {
            TraktMovieStatistics? movieStatistics = await TraktTestUtility.DeserializeJsonAsync<TraktMovieStatistics>("Movies\\moviestatistics.json");

            movieStatistics.ShouldNotBeNull();

            movieStatistics!.Watchers.ShouldBe(164943U);
            movieStatistics!.Plays.ShouldBe(219925U);
            movieStatistics!.Collectors.ShouldBe(66444U);
            movieStatistics!.Comments.ShouldBe(177U);
            movieStatistics!.Lists.ShouldBe(51079U);
            movieStatistics!.Votes.ShouldBe(18906U);
            movieStatistics!.Favorited.ShouldBe(773U);
            movieStatistics!.Recommended.ShouldBe(773U);
        }
    }
}
