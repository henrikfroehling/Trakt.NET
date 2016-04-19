namespace TraktApiSharp.Tests.Objects
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Newtonsoft.Json;
    using TraktApiSharp.Objects.Basic;
    using Utils;

    [TestClass]
    public class TraktStatisticsTests
    {
        [TestMethod]
        public void TestTraktStatisticsDefaultConstructor()
        {
            var stats = new TraktStatistics();

            stats.Watchers.Should().NotHaveValue();
            stats.Plays.Should().NotHaveValue();
            stats.Collectors.Should().NotHaveValue();
            stats.CollectedEpisodes.Should().NotHaveValue();
            stats.Comments.Should().NotHaveValue();
            stats.Lists.Should().NotHaveValue();
            stats.Votes.Should().NotHaveValue();
        }

        [TestMethod]
        public void TestTraktStatisticsReadFromJson()
        {
            var jsonFile = TestUtility.ReadFileContents(@"Objects\Basic\Statistics.json");

            jsonFile.Should().NotBeNullOrEmpty();

            var stats = JsonConvert.DeserializeObject<TraktStatistics>(jsonFile);

            stats.Should().NotBeNull();
            stats.Watchers.Should().Be(129920);
            stats.Plays.Should().Be(3563853);
            stats.Collectors.Should().Be(49711);
            stats.CollectedEpisodes.Should().Be(1310350);
            stats.Comments.Should().Be(96);
            stats.Lists.Should().Be(49468);
            stats.Votes.Should().Be(9274);
        }
    }
}
