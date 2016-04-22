namespace TraktApiSharp.Tests.Objects.Movies
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Newtonsoft.Json;
    using TraktApiSharp.Objects.Get.Movies;
    using Utils;

    [TestClass]
    public class TraktMovieStatisticsTests
    {
        [TestMethod]
        public void TestTraktMovieStatisticsDefaultConstructor()
        {
            var movieStats = new TraktMovieStatistics();

            movieStats.Watchers.Should().Be(0);
            movieStats.Plays.Should().Be(0);
            movieStats.Collectors.Should().Be(0);
            movieStats.CollectedEpisodes.Should().NotHaveValue();
            movieStats.Comments.Should().Be(0);
            movieStats.Lists.Should().Be(0);
            movieStats.Votes.Should().Be(0);
        }

        [TestMethod]
        public void TestTraktMovieStatisticsReadFromJson()
        {
            var jsonFile = TestUtility.ReadFileContents(@"Objects\Get\Movies\MovieStatistics.json");

            jsonFile.Should().NotBeNullOrEmpty();

            var movieStats = JsonConvert.DeserializeObject<TraktMovieStatistics>(jsonFile);

            movieStats.Should().NotBeNull();
            movieStats.Watchers.Should().Be(40619);
            movieStats.Plays.Should().Be(64620);
            movieStats.Collectors.Should().Be(17519);
            movieStats.CollectedEpisodes.Should().NotHaveValue();
            movieStats.Comments.Should().Be(99);
            movieStats.Lists.Should().Be(17089);
            movieStats.Votes.Should().Be(10359);
        }
    }
}
