namespace TraktApiSharp.Tests.Objects
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Newtonsoft.Json;
    using System.Collections.Generic;
    using TraktApiSharp.Objects.Basic;
    using Utils;

    [TestClass]
    public class TraktRatingTests
    {
        [TestMethod]
        public void TestTraktRatingDefaultConstructor()
        {
            var rating = new TraktRating();

            rating.Rating.Should().NotHaveValue();
            rating.Votes.Should().NotHaveValue();
            rating.Distribution.Should().BeNull();
        }

        [TestMethod]
        public void TestTraktRatingReadFromJson()
        {
            var jsonFile = TestUtility.ReadFileContents(@"Objects\Basic\Rating.json");

            jsonFile.Should().NotBeNullOrEmpty();

            var rating = JsonConvert.DeserializeObject<TraktRating>(jsonFile);

            var distribution = new Dictionary<string, int>()
            {
                { "1",  78 }, { "2", 45 }, { "3", 55 }, { "4", 96 }, { "5", 183 },
                { "6",  545 }, { "7", 1361 }, { "8", 2259 }, { "9", 1772 }, { "10", 2863 }
            };

            rating.Should().NotBeNull();
            rating.Rating.Should().Be(8.32715f);
            rating.Votes.Should().Be(9274);
            rating.Distribution.Should().HaveCount(10).And.Contain(distribution);
        }
    }
}
