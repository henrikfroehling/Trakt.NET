namespace TraktApiSharp.Tests.Objects.Recommendations
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Newtonsoft.Json;
    using System.Collections.Generic;
    using System.Linq;
    using TraktApiSharp.Objects.Get.Recommendations;
    using Utils;

    [TestClass]
    public class TraktShowRecommendationsTests
    {
        [TestMethod]
        public void TestTraktShowRecommendationsReadFromJson()
        {
            var jsonFile = TestUtility.ReadFileContents(@"Recommendations\ShowRecommendations.json");

            jsonFile.Should().NotBeNullOrEmpty();

            var showRecommendations = JsonConvert.DeserializeObject<IEnumerable<TraktShowRecommendation>>(jsonFile);

            showRecommendations.Should().NotBeNull().And.HaveCount(3);

            var showRecommendationsArray = showRecommendations.ToArray();

            showRecommendationsArray[0].Should().NotBeNull();
            showRecommendationsArray[0].Title.Should().Be("The Biggest Loser");
            showRecommendationsArray[0].Year.Should().Be(2004);
            showRecommendationsArray[0].Ids.Should().NotBeNull();
            showRecommendationsArray[0].Ids.Trakt.Should().Be(9);
            showRecommendationsArray[0].Ids.Slug.Should().Be("the-biggest-loser");
            showRecommendationsArray[0].Ids.Tvdb.Should().Be(75166);
            showRecommendationsArray[0].Ids.Imdb.Should().Be("tt0429318");
            showRecommendationsArray[0].Ids.Tmdb.Should().Be(579);
            showRecommendationsArray[0].Ids.TvRage.Should().NotHaveValue();

            showRecommendationsArray[1].Should().NotBeNull();
            showRecommendationsArray[1].Title.Should().Be("Shark Tank");
            showRecommendationsArray[1].Year.Should().Be(2009);
            showRecommendationsArray[1].Ids.Should().NotBeNull();
            showRecommendationsArray[1].Ids.Trakt.Should().Be(36);
            showRecommendationsArray[1].Ids.Slug.Should().Be("shark-tank");
            showRecommendationsArray[1].Ids.Tvdb.Should().Be(100981);
            showRecommendationsArray[1].Ids.Imdb.Should().Be("tt1442550");
            showRecommendationsArray[1].Ids.Tmdb.Should().Be(30703);
            showRecommendationsArray[1].Ids.TvRage.Should().Be(22610);

            showRecommendationsArray[2].Should().NotBeNull();
            showRecommendationsArray[2].Title.Should().Be("Hell's Kitchen");
            showRecommendationsArray[2].Year.Should().Be(2005);
            showRecommendationsArray[2].Ids.Should().NotBeNull();
            showRecommendationsArray[2].Ids.Trakt.Should().Be(40);
            showRecommendationsArray[2].Ids.Slug.Should().Be("hell-s-kitchen");
            showRecommendationsArray[2].Ids.Tvdb.Should().Be(74897);
            showRecommendationsArray[2].Ids.Imdb.Should().Be("tt0437005");
            showRecommendationsArray[2].Ids.Tmdb.Should().Be(2370);
            showRecommendationsArray[2].Ids.TvRage.Should().NotHaveValue();
        }
    }
}
