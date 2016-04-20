namespace TraktApiSharp.Tests.Objects.Recommendations
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Newtonsoft.Json;
    using TraktApiSharp.Objects.Get.Recommendations;
    using Utils;

    [TestClass]
    public class TraktShowSingleRecommendationTests
    {
        [TestMethod]
        public void TestTraktShowSingleRecommendationDefaultConstructor()
        {
            var showRecommendation = new TraktShowRecommendation();

            showRecommendation.Title.Should().BeNullOrEmpty();
            showRecommendation.Year.Should().Be(0);
            showRecommendation.Ids.Should().BeNull();
        }

        [TestMethod]
        public void TestTraktShowSingleRecommendationReadFromJson()
        {
            var jsonFile = TestUtility.ReadFileContents(@"Objects\Get\Recommendations\ShowSingleRecommendation.json");

            jsonFile.Should().NotBeNullOrEmpty();

            var showRecommendation = JsonConvert.DeserializeObject<TraktShowRecommendation>(jsonFile);

            showRecommendation.Should().NotBeNull();
            showRecommendation.Title.Should().Be("The Biggest Loser");
            showRecommendation.Year.Should().Be(2004);
            showRecommendation.Ids.Should().NotBeNull();
            showRecommendation.Ids.Trakt.Should().Be(9);
            showRecommendation.Ids.Slug.Should().Be("the-biggest-loser");
            showRecommendation.Ids.Tvdb.Should().Be(75166);
            showRecommendation.Ids.Imdb.Should().Be("tt0429318");
            showRecommendation.Ids.Tmdb.Should().Be(579);
            showRecommendation.Ids.TvRage.Should().NotHaveValue();
        }
    }
}
