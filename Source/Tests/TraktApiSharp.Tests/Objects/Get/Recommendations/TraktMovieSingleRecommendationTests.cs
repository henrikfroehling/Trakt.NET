namespace TraktApiSharp.Tests.Objects.Recommendations
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Newtonsoft.Json;
    using TraktApiSharp.Objects.Get.Recommendations;
    using Utils;

    [TestClass]
    public class TraktMovieSingleRecommendationTests
    {
        [TestMethod]
        public void TestTraktMovieSingleRecommendationDefaultConstructor()
        {
            var movieRecommendation = new TraktMovieRecommendation();

            movieRecommendation.Title.Should().BeNullOrEmpty();
            movieRecommendation.Year.Should().Be(0);
            movieRecommendation.Ids.Should().BeNull();
        }

        [TestMethod]
        public void TestTraktMovieSingleRecommendationReadFromJson()
        {
            var jsonFile = TestUtility.ReadFileContents(@"Objects\Get\Recommendations\MovieSingleRecommendation.json");

            jsonFile.Should().NotBeNullOrEmpty();

            var movieRecommendation = JsonConvert.DeserializeObject<TraktMovieRecommendation>(jsonFile);

            movieRecommendation.Should().NotBeNull();
            movieRecommendation.Title.Should().Be("Blackfish");
            movieRecommendation.Year.Should().Be(2013);
            movieRecommendation.Ids.Should().NotBeNull();
            movieRecommendation.Ids.Trakt.Should().Be(58);
            movieRecommendation.Ids.Slug.Should().Be("blackfish-2013");
            movieRecommendation.Ids.Imdb.Should().Be("tt2545118");
            movieRecommendation.Ids.Tmdb.Should().Be(158999);
        }
    }
}
