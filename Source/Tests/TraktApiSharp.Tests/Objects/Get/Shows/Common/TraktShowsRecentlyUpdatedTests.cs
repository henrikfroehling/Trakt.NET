namespace TraktApiSharp.Tests.Objects.Shows.Common
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using TraktApiSharp.Objects.Get.Shows.Common;
    using Utils;

    [TestClass]
    public class TraktShowsRecentlyUpdatedTests
    {
        [TestMethod]
        public void TestTraktShowsRecentlyUpdatedDefaultConstructor()
        {
            var updatedShow = new TraktRecentlyUpdatedShow();

            updatedShow.UpdatedAt.Should().NotHaveValue();
            updatedShow.Show.Should().BeNull();
        }

        [TestMethod]
        public void TestTraktShowsRecentlyUpdatedReadFromJson()
        {
            var jsonFile = TestUtility.ReadFileContents(@"Objects\Get\Shows\Common\ShowsRecentlyUpdated.json");

            jsonFile.Should().NotBeNullOrEmpty();

            var updatedShows = JsonConvert.DeserializeObject<IEnumerable<TraktRecentlyUpdatedShow>>(jsonFile);

            updatedShows.Should().NotBeNull().And.HaveCount(2);

            var shows = updatedShows.ToArray();

            shows[0].UpdatedAt.Should().Be(DateTime.Parse("2016-04-07T15:24:24Z").ToUniversalTime());
            shows[0].Show.Should().NotBeNull();

            shows[1].UpdatedAt.Should().Be(DateTime.Parse("2016-04-07T15:31:48Z").ToUniversalTime());
            shows[1].Show.Should().NotBeNull();
        }
    }
}
