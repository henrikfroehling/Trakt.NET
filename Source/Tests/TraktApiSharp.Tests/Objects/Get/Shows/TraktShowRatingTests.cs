namespace TraktApiSharp.Tests.Objects.Shows
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Newtonsoft.Json;
    using System.Collections.Generic;
    using TraktApiSharp.Objects.Get.Shows;
    using Utils;

    [TestClass]
    public class TraktShowRatingTests
    {
        [TestMethod]
        public void TestTraktShowRatingDefaultConstructor()
        {
            var showRating = new TraktShowRating();

            showRating.Rating.Should().Be(0.0f);
            showRating.Votes.Should().Be(0);
            showRating.Distribution.Should().BeNull();
        }

        [TestMethod]
        public void TestTraktShowRatingReadFromJson()
        {
            var jsonFile = TestUtility.ReadFileContents(@"Objects\Get\Shows\ShowRatings.json");

            jsonFile.Should().NotBeNullOrEmpty();

            var showRating = JsonConvert.DeserializeObject<TraktShowRating>(jsonFile);

            var distribution = new Dictionary<string, int>()
            {
                { "1",  258 }, { "2", 57 }, { "3", 59 }, { "4", 116 }, { "5", 262 },
                { "6",  448 }, { "7", 1427 }, { "8", 3893 }, { "9", 8467 }, { "10", 29590 }
            };

            showRating.Should().NotBeNull();
            showRating.Rating.Should().Be(9.38231f);
            showRating.Votes.Should().Be(44590);
            showRating.Distribution.Should().HaveCount(10).And.Contain(distribution);
        }
    }
}
