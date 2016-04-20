﻿namespace TraktApiSharp.Tests.Objects.Shows.Seasons
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Newtonsoft.Json;
    using TraktApiSharp.Objects.Get.Shows.Seasons;
    using Utils;

    [TestClass]
    public class TraktSeasonStatisticsTests
    {
        [TestMethod]
        public void TestTraktSeasonStatisticsDefaultConstructor()
        {
            var seasonStats = new TraktSeasonStatistics();

            seasonStats.Watchers.Should().Be(0);
            seasonStats.Plays.Should().Be(0);
            seasonStats.Collectors.Should().Be(0);
            seasonStats.CollectedEpisodes.Should().NotHaveValue();
            seasonStats.Comments.Should().Be(0);
            seasonStats.Lists.Should().Be(0);
            seasonStats.Votes.Should().Be(0);
        }

        [TestMethod]
        public void TestTraktSeasonStatisticsReadFromJson()
        {
            var jsonFile = TestUtility.ReadFileContents(@"Objects\Get\Shows\Seasons\Single\SeasonStatistics.json");

            jsonFile.Should().NotBeNullOrEmpty();

            var seasonStats = JsonConvert.DeserializeObject<TraktSeasonStatistics>(jsonFile);

            seasonStats.Should().NotBeNull();
            seasonStats.Watchers.Should().Be(232215);
            seasonStats.Plays.Should().Be(2719701);
            seasonStats.Collectors.Should().Be(91770);
            seasonStats.CollectedEpisodes.Should().Be(907358);
            seasonStats.Comments.Should().Be(6);
            seasonStats.Lists.Should().Be(250);
            seasonStats.Votes.Should().Be(1149);
        }
    }
}
