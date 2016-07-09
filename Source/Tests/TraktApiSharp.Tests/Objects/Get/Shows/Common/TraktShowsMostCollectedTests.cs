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
    public class TraktShowsMostCollectedTests
    {
        [TestMethod]
        public void TestTraktShowsMostCollectedDefaultConstructor()
        {
            var collectedShow = new TraktMostCollectedShow();

            collectedShow.WatcherCount.Should().NotHaveValue();
            collectedShow.PlayCount.Should().NotHaveValue();
            collectedShow.CollectedCount.Should().NotHaveValue();
            collectedShow.CollectorCount.Should().NotHaveValue();
            collectedShow.Show.Should().BeNull();
        }

        [TestMethod]
        public void TestTraktShowsMostCollectedReadFromJson()
        {
            var jsonFile = TestUtility.ReadFileContents(@"Objects\Get\Shows\Common\ShowsMostCollected.json");

            jsonFile.Should().NotBeNullOrEmpty();

            var collectedShows = JsonConvert.DeserializeObject<IEnumerable<TraktMostCollectedShow>>(jsonFile);

            collectedShows.Should().NotBeNull().And.HaveCount(2);

            var shows = collectedShows.ToArray();

            shows[0].WatcherCount.Should().Be(32546);
            shows[0].PlayCount.Should().Be(200966);
            shows[0].CollectedCount.Should().Be(148070);
            shows[0].CollectorCount.Should().Be(9607);
            shows[0].Show.Should().NotBeNull();

            shows[1].WatcherCount.Should().Be(21365);
            shows[1].PlayCount.Should().Be(263571);
            shows[1].CollectedCount.Should().Be(247898);
            shows[1].CollectorCount.Should().Be(7964);
            shows[1].Show.Should().NotBeNull();
        }
    }
}
