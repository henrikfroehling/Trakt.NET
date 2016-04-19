namespace TraktApiSharp.Tests.Objects.Shows.Episodes
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Newtonsoft.Json;
    using System.Collections.Generic;
    using TraktApiSharp.Objects.Get.Shows.Episodes;
    using Utils;

    [TestClass]
    public class TraktEpisodeRatingTests
    {
        [TestMethod]
        public void TestTraktEpisodeRatingDefaultConstructor()
        {
            var episodeRating = new TraktEpisodeRating();

            episodeRating.Rating.Should().NotHaveValue();
            episodeRating.Votes.Should().NotHaveValue();
            episodeRating.Distribution.Should().BeNull();
        }

        [TestMethod]
        public void TestTraktEpisodeRatingReadFromJson()
        {
            var jsonFile = TestUtility.ReadFileContents(@"Shows\Episodes\EpisodeRatings.json");

            jsonFile.Should().NotBeNullOrEmpty();

            var episodeRating = JsonConvert.DeserializeObject<TraktEpisodeRating>(jsonFile);

            var distribution = new Dictionary<string, int>()
            {
                { "1",  59 }, { "2", 11 }, { "3", 2 }, { "4", 14 }, { "5", 58 },
                { "6",  233 }, { "7", 492 }, { "8", 835 }, { "9", 635 }, { "10", 1580 }
            };

            episodeRating.Should().NotBeNull();
            episodeRating.Rating.Should().Be(8.54044m);
            episodeRating.Votes.Should().Be(3919);
            episodeRating.Distribution.Should().HaveCount(10).And.Contain(distribution);
        }
    }
}
