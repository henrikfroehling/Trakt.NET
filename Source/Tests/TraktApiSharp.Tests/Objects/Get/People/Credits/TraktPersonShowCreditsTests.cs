namespace TraktApiSharp.Tests.Objects.Get.People.Credits
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Newtonsoft.Json;
    using System.Linq;
    using TraktApiSharp.Objects.Get.People.Credits;
    using Utils;

    [TestClass]
    public class TraktPersonShowCreditsTests
    {
        [TestMethod]
        public void TestTraktPersonShowCreditsDefaultConstructor()
        {
            var showCredits = new TraktPersonShowCredits();

            showCredits.Cast.Should().BeNull();
            showCredits.Crew.Should().BeNull();
        }

        [TestMethod]
        public void TestTraktPersonShowCreditsReadFromJson()
        {
            var jsonFile = TestUtility.ReadFileContents(@"Objects\Get\People\Credits\PersonShowCredits.json");

            jsonFile.Should().NotBeNullOrEmpty();

            var showCredits = JsonConvert.DeserializeObject<TraktPersonShowCredits>(jsonFile);

            showCredits.Should().NotBeNull();

            showCredits.Cast.Should().NotBeNull().And.HaveCount(2);

            var cast = showCredits.Cast.ToArray();

            cast[0].Character.Should().Be("Walter White");
            cast[0].Show.Should().NotBeNull();
            cast[0].Show.Title.Should().Be("Breaking Bad");
            cast[0].Show.Year.Should().Be(2008);
            cast[0].Show.Ids.Should().NotBeNull();
            cast[0].Show.Ids.Trakt.Should().Be(1U);
            cast[0].Show.Ids.Slug.Should().Be("breaking-bad");
            cast[0].Show.Ids.Tvdb.Should().Be(81189U);
            cast[0].Show.Ids.Imdb.Should().Be("tt0903747");
            cast[0].Show.Ids.Tmdb.Should().Be(1396U);
            cast[0].Show.Ids.TvRage.Should().Be(18164U);

            cast[1].Character.Should().Be("Hal");
            cast[1].Show.Should().NotBeNull();
            cast[1].Show.Title.Should().Be("Malcolm in the Middle");
            cast[1].Show.Year.Should().Be(2000);
            cast[1].Show.Ids.Should().NotBeNull();
            cast[1].Show.Ids.Trakt.Should().Be(1991U);
            cast[1].Show.Ids.Slug.Should().Be("malcolm-in-the-middle");
            cast[1].Show.Ids.Tvdb.Should().Be(73838U);
            cast[1].Show.Ids.Imdb.Should().Be("tt0212671");
            cast[1].Show.Ids.Tmdb.Should().Be(2004U);
            cast[1].Show.Ids.TvRage.Should().BeNull();

            showCredits.Crew.Should().NotBeNull();
            showCredits.Crew.Art.Should().BeNull();
            showCredits.Crew.Camera.Should().BeNull();
            showCredits.Crew.CostumeAndMakeup.Should().BeNull();
            showCredits.Crew.Crew.Should().BeNull();
            showCredits.Crew.Directing.Should().BeNull();
            showCredits.Crew.Editing.Should().BeNull();
            showCredits.Crew.Lighting.Should().BeNull();
            showCredits.Crew.Production.Should().NotBeNull().And.HaveCount(1);

            var production = showCredits.Crew.Production.ToArray();

            production[0].Job.Should().Be("Producer");
            production[0].Show.Should().NotBeNull();
            production[0].Show.Title.Should().Be("Breaking Bad");
            production[0].Show.Year.Should().Be(2008);
            production[0].Show.Ids.Should().NotBeNull();
            production[0].Show.Ids.Trakt.Should().Be(1U);
            production[0].Show.Ids.Slug.Should().Be("breaking-bad");
            production[0].Show.Ids.Tvdb.Should().Be(81189U);
            production[0].Show.Ids.Imdb.Should().Be("tt0903747");
            production[0].Show.Ids.Tmdb.Should().Be(1396U);
            production[0].Show.Ids.TvRage.Should().Be(18164U);

            showCredits.Crew.Sound.Should().BeNull();
            showCredits.Crew.VisualEffects.Should().BeNull();
            showCredits.Crew.Writing.Should().BeNull();
        }
    }
}
