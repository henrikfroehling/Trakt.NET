namespace TraktApiSharp.Tests.Objects.Shows.Episodes
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Newtonsoft.Json;
    using TraktApiSharp.Objects.Shows.Episodes;
    using Utils;

    [TestClass]
    public class TraktEpisodeStatisticsTests
    {
        [TestMethod]
        public void TestTraktEpisodeStatisticsDefaultConstructor()
        {
            var episodeStats = new TraktEpisodeStatistics();

            episodeStats.Watchers.Should().NotHaveValue();
            episodeStats.Plays.Should().NotHaveValue();
            episodeStats.Collectors.Should().NotHaveValue();
            episodeStats.CollectedEpisodes.Should().NotHaveValue();
            episodeStats.Comments.Should().NotHaveValue();
            episodeStats.Lists.Should().NotHaveValue();
            episodeStats.Votes.Should().NotHaveValue();
        }

        [TestMethod]
        public void TestTraktEpisodeStatisticsReadFromJson()
        {
            var jsonFile = TestUtility.ReadJsonData(@"Shows\Episodes\EpisodeStatistics.json");

            jsonFile.Should().NotBeNullOrEmpty();

            var episodeStats = JsonConvert.DeserializeObject<TraktEpisodeStatistics>(jsonFile);

            episodeStats.Should().NotBeNull();
            episodeStats.Watchers.Should().Be(233273);
            episodeStats.Plays.Should().Be(303464);
            episodeStats.Collectors.Should().Be(92759);
            episodeStats.CollectedEpisodes.Should().NotHaveValue();
            episodeStats.Comments.Should().Be(4);
            episodeStats.Lists.Should().Be(418);
            episodeStats.Votes.Should().Be(3919);
        }
    }
}
