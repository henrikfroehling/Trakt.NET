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
    public class TraktShowsMostAnticipatedTests
    {
        [TestMethod]
        public void TestTraktShowsMostAnticipatedDefaultConstructor()
        {
            var anticipatedShow = new TraktMostAnticipatedShow();

            anticipatedShow.ListCount.Should().NotHaveValue();
            anticipatedShow.Show.Should().BeNull();
        }

        [TestMethod]
        public void TestTraktShowsMostAnticipatedReadFromJson()
        {
            var jsonFile = TestUtility.ReadFileContents(@"Objects\Get\Shows\Common\ShowsMostAnticipated.json");

            jsonFile.Should().NotBeNullOrEmpty();

            var anticipatedShows = JsonConvert.DeserializeObject<IEnumerable<TraktMostAnticipatedShow>>(jsonFile);

            anticipatedShows.Should().NotBeNull().And.HaveCount(2);

            var shows = anticipatedShows.ToArray();

            shows[0].ListCount.Should().Be(5529);
            shows[0].Show.Should().NotBeNull();

            shows[1].ListCount.Should().Be(5034);
            shows[1].Show.Should().NotBeNull();
        }
    }
}
