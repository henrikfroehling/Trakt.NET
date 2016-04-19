namespace TraktApiSharp.Tests.Objects.Movies
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Newtonsoft.Json;
    using System.Collections.Generic;
    using TraktApiSharp.Objects.Get.Movies;
    using Utils;

    [TestClass]
    public class TraktMovieRatingTests
    {
        [TestMethod]
        public void TestTraktMovieRatingDefaultConstructor()
        {
            var movieRating = new TraktMovieRating();

            movieRating.Rating.Should().NotHaveValue();
            movieRating.Votes.Should().NotHaveValue();
            movieRating.Distribution.Should().BeNull();
        }

        [TestMethod]
        public void TestTraktMovieRatingReadFromJson()
        {
            var jsonFile = TestUtility.ReadFileContents(@"Movies\MovieRatings.json");

            jsonFile.Should().NotBeNullOrEmpty();

            var movieRating = JsonConvert.DeserializeObject<TraktMovieRating>(jsonFile);

            var distribution = new Dictionary<string, int>()
            {
                { "1",  185 }, { "2", 28 }, { "3", 34 }, { "4", 89 }, { "5", 184 },
                { "6",  630 }, { "7", 1244 }, { "8", 2509 }, { "9", 2622 }, { "10", 2834 }
            };

            movieRating.Should().NotBeNull();
            movieRating.Rating.Should().Be(8.31325m);
            movieRating.Votes.Should().Be(10359);
            movieRating.Distribution.Should().HaveCount(10).And.Contain(distribution);
        }
    }
}
