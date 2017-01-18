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
    public class TraktShowsMostWatchedTests
    {
        [TestMethod]
        public void TestTraktShowsMostWatchedDefaultConstructor()
        {
            var watchedShow = new TraktMostWatchedShow();

            watchedShow.WatcherCount.Should().NotHaveValue();
            watchedShow.PlayCount.Should().NotHaveValue();
            watchedShow.CollectedCount.Should().NotHaveValue();
            watchedShow.CollectorCount.Should().NotHaveValue();
            watchedShow.Show.Should().BeNull();
        }

        [TestMethod]
        public void TestTraktShowsMostWatchedReadFromJson()
        {
            var jsonFile = TestUtility.ReadFileContents(@"Objects\Get\Shows\Common\ShowsMostWatched.json");

            jsonFile.Should().NotBeNullOrEmpty();

            var watchedShows = JsonConvert.DeserializeObject<IEnumerable<TraktMostWatchedShow>>(jsonFile);

            watchedShows.Should().NotBeNull().And.HaveCount(2);

            var shows = watchedShows.ToArray();

            shows[0].WatcherCount.Should().Be(32546);
            shows[0].PlayCount.Should().Be(200966);
            shows[0].CollectedCount.Should().Be(148070);
            shows[0].CollectorCount.Should().Be(9607);
            shows[0].Show.Should().NotBeNull();

            shows[1].WatcherCount.Should().Be(27330);
            shows[1].PlayCount.Should().Be(85321);
            shows[1].CollectedCount.Should().Be(52363);
            shows[1].CollectorCount.Should().Be(7926);
            shows[1].Show.Should().NotBeNull();
        }
    }
}
