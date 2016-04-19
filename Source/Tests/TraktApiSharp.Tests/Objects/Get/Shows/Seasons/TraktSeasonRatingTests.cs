namespace TraktApiSharp.Tests.Objects.Shows.Seasons
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Newtonsoft.Json;
    using System.Collections.Generic;
    using TraktApiSharp.Objects.Get.Shows.Seasons;
    using Utils;

    [TestClass]
    public class TraktSeasonRatingTests
    {
        [TestMethod]
        public void TestTraktSeasonRatingDefaultConstructor()
        {
            var seasonRating = new TraktSeasonRating();

            seasonRating.Rating.Should().NotHaveValue();
            seasonRating.Votes.Should().NotHaveValue();
            seasonRating.Distribution.Should().BeNull();
        }

        [TestMethod]
        public void TestTraktSeasonRatingReadFromJson()
        {
            var jsonFile = TestUtility.ReadFileContents(@"Objects\Get\Shows\Seasons\Single\SeasonRatings.json");

            jsonFile.Should().NotBeNullOrEmpty();

            var seasonRating = JsonConvert.DeserializeObject<TraktSeasonRating>(jsonFile);

            var distribution = new Dictionary<string, int>()
            {
                { "1",  7 }, { "2", 5 }, { "3", 4 }, { "4", 2 }, { "5", 9 },
                { "6",  23 }, { "7", 45 }, { "8", 152 }, { "9", 282 }, { "10", 620 }
            };

            seasonRating.Should().NotBeNull();
            seasonRating.Rating.Should().Be(9.12881m);
            seasonRating.Votes.Should().Be(1149);
            seasonRating.Distribution.Should().HaveCount(10).And.Contain(distribution);
        }
    }
}
