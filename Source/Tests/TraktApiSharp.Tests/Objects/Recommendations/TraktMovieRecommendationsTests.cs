namespace TraktApiSharp.Tests.Objects.Recommendations
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Newtonsoft.Json;
    using System.Collections.Generic;
    using System.Linq;
    using TraktApiSharp.Objects.Recommendations;
    using Utils;

    [TestClass]
    public class TraktMovieRecommendationsTests
    {
        [TestMethod]
        public void TestTraktMovieRecommendationsReadFromJson()
        {
            var jsonFile = TestUtility.ReadFileContents(@"Recommendations\MovieRecommendations.json");

            jsonFile.Should().NotBeNullOrEmpty();

            var movieRecommendations = JsonConvert.DeserializeObject<IEnumerable<TraktMovieRecommendation>>(jsonFile);

            movieRecommendations.Should().NotBeNull().And.HaveCount(3);

            var movieRecommendationsArray = movieRecommendations.ToArray();

            movieRecommendationsArray[0].Should().NotBeNull();
            movieRecommendationsArray[0].Title.Should().Be("Blackfish");
            movieRecommendationsArray[0].Year.Should().Be(2013);
            movieRecommendationsArray[0].Ids.Should().NotBeNull();
            movieRecommendationsArray[0].Ids.Trakt.Should().Be(58);
            movieRecommendationsArray[0].Ids.Slug.Should().Be("blackfish-2013");
            movieRecommendationsArray[0].Ids.Imdb.Should().Be("tt2545118");
            movieRecommendationsArray[0].Ids.Tmdb.Should().Be(158999);

            movieRecommendationsArray[1].Should().NotBeNull();
            movieRecommendationsArray[1].Title.Should().Be("Waiting for Superman");
            movieRecommendationsArray[1].Year.Should().Be(2010);
            movieRecommendationsArray[1].Ids.Should().NotBeNull();
            movieRecommendationsArray[1].Ids.Trakt.Should().Be(289);
            movieRecommendationsArray[1].Ids.Slug.Should().Be("waiting-for-superman-2010");
            movieRecommendationsArray[1].Ids.Imdb.Should().Be("tt1566648");
            movieRecommendationsArray[1].Ids.Tmdb.Should().Be(39440);

            movieRecommendationsArray[2].Should().NotBeNull();
            movieRecommendationsArray[2].Title.Should().Be("Inside Job");
            movieRecommendationsArray[2].Year.Should().Be(2010);
            movieRecommendationsArray[2].Ids.Should().NotBeNull();
            movieRecommendationsArray[2].Ids.Trakt.Should().Be(329);
            movieRecommendationsArray[2].Ids.Slug.Should().Be("inside-job-2010");
            movieRecommendationsArray[2].Ids.Imdb.Should().Be("tt1645089");
            movieRecommendationsArray[2].Ids.Tmdb.Should().Be(44639);
        }
    }
}
