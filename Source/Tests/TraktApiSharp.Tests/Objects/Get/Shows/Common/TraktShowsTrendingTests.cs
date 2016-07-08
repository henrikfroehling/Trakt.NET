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
    public class TraktShowsTrendingTests
    {
        [TestMethod]
        public void TestTraktShowsTrendingDefaultConstructor()
        {
            var trendingShow = new TraktTrendingShow();

            trendingShow.Watchers.Should().NotHaveValue();
            trendingShow.Show.Should().BeNull();
        }

        [TestMethod]
        public void TestTraktShowsTrendingReadFromJson()
        {
            var jsonFile = TestUtility.ReadFileContents(@"Objects\Get\Shows\Common\ShowsTrending.json");

            jsonFile.Should().NotBeNullOrEmpty();

            var trendingShows = JsonConvert.DeserializeObject<IEnumerable<TraktTrendingShow>>(jsonFile);

            trendingShows.Should().NotBeNull().And.HaveCount(2);

            var shows = trendingShows.ToArray();

            shows[0].Watchers.Should().Be(175);
            shows[0].Show.Should().NotBeNull();

            shows[1].Watchers.Should().Be(137);
            shows[1].Show.Should().NotBeNull();
        }
    }
}
