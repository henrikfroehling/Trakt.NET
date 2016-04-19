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
    public class TraktShowsPopularTests
    {
        [TestMethod]
        public void TestTraktShowsPopularDefaultConstructor()
        {
            var popularShow = new TraktShowsPopularItem();

            popularShow.Title.Should().BeNullOrEmpty();
            popularShow.Year.Should().NotHaveValue();
            popularShow.Ids.Should().BeNull();
        }

        [TestMethod]
        public void TestTraktShowsPopularReadFromJson()
        {
            var jsonFile = TestUtility.ReadFileContents(@"Shows\Common\ShowsPopular.json");

            jsonFile.Should().NotBeNullOrEmpty();

            var popularShows = JsonConvert.DeserializeObject<IEnumerable<TraktShowsPopularItem>>(jsonFile);

            popularShows.Should().NotBeNull().And.HaveCount(2);

            var shows = popularShows.ToArray();

            shows[0].Title.Should().Be("Game of Thrones");
            shows[0].Year.Should().Be(2011);
            shows[0].Ids.Should().NotBeNull();
            shows[0].Ids.Trakt.Should().Be(1390);
            shows[0].Ids.Slug.Should().Be("game-of-thrones");
            shows[0].Ids.Tvdb.Should().Be(121361);
            shows[0].Ids.Imdb.Should().Be("tt0944947");
            shows[0].Ids.Tmdb.Should().Be(1399);
            shows[0].Ids.TvRage.Should().Be(24493);

            shows[1].Title.Should().Be("Breaking Bad");
            shows[1].Year.Should().Be(2008);
            shows[1].Ids.Should().NotBeNull();
            shows[1].Ids.Trakt.Should().Be(1388);
            shows[1].Ids.Slug.Should().Be("breaking-bad");
            shows[1].Ids.Tvdb.Should().Be(81189);
            shows[1].Ids.Imdb.Should().Be("tt0903747");
            shows[1].Ids.Tmdb.Should().Be(1396);
            shows[1].Ids.TvRage.Should().Be(18164);
        }
    }
}
