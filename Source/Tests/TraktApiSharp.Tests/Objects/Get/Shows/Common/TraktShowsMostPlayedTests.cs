namespace TraktApiSharp.Tests.Objects.Shows.Common
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Newtonsoft.Json;
    using System.Collections.Generic;
    using System.Linq;
    using TraktApiSharp.Objects.Get.Shows.Common;
    using Utils;

    [TestClass]
    public class TraktShowsMostPlayedTests
    {
        [TestMethod]
        public void TestTraktShowsMostPlayedDefaultConstructor()
        {
            var playedShow = new TraktMostPlayedShow();

            playedShow.WatcherCount.Should().NotHaveValue();
            playedShow.PlayCount.Should().NotHaveValue();
            playedShow.CollectedCount.Should().NotHaveValue();
            playedShow.CollectorCount.Should().NotHaveValue();
            playedShow.Show.Should().BeNull();
        }

        [TestMethod]
        public void TestTraktShowsMostPlayedReadFromJson()
        {
            var jsonFile = TestUtility.ReadFileContents(@"Objects\Get\Shows\Common\ShowsMostPlayed.json");

            jsonFile.Should().NotBeNullOrEmpty();

            var playedShows = JsonConvert.DeserializeObject<IEnumerable<TraktMostPlayedShow>>(jsonFile);

            playedShows.Should().NotBeNull().And.HaveCount(2);

            var shows = playedShows.ToArray();

            shows[0].WatcherCount.Should().Be(21365);
            shows[0].PlayCount.Should().Be(263571);
            shows[0].CollectedCount.Should().Be(247898);
            shows[0].CollectorCount.Should().Be(7964);
            shows[0].Show.Should().NotBeNull();

            shows[1].WatcherCount.Should().Be(32546);
            shows[1].PlayCount.Should().Be(200966);
            shows[1].CollectedCount.Should().Be(148070);
            shows[1].CollectorCount.Should().Be(9607);
            shows[1].Show.Should().NotBeNull();
        }
    }
}
