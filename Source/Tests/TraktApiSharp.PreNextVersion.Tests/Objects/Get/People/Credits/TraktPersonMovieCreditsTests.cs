namespace TraktApiSharp.Tests.Objects.Get.People.Credits
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Newtonsoft.Json;
    using System.Linq;
    using TraktApiSharp.Objects.Get.People.Credits;
    using Utils;

    [TestClass]
    public class TraktPersonMovieCreditsTests
    {
        [TestMethod]
        public void TestTraktPersonMovieCreditsDefaultConstructor()
        {
            var movieCredits = new TraktPersonMovieCredits();

            movieCredits.Cast.Should().BeNull();
            movieCredits.Crew.Should().BeNull();
        }

        [TestMethod]
        public void TestTraktPersonMovieCreditsReadFromJson()
        {
            var jsonFile = TestUtility.ReadFileContents(@"Objects\Get\People\Credits\PersonMovieCredits.json");

            jsonFile.Should().NotBeNullOrEmpty();

            var movieCredits = JsonConvert.DeserializeObject<TraktPersonMovieCredits>(jsonFile);

            movieCredits.Should().NotBeNull();

            movieCredits.Cast.Should().NotBeNull().And.HaveCount(2);

            var cast = movieCredits.Cast.ToArray();

            cast[0].Character.Should().Be("Li (voice)");
            cast[0].Movie.Should().NotBeNull();
            cast[0].Movie.Title.Should().Be("Kung Fu Panda 3");
            cast[0].Movie.Year.Should().Be(2016);
            cast[0].Movie.Ids.Should().NotBeNull();
            cast[0].Movie.Ids.Trakt.Should().Be(93870U);
            cast[0].Movie.Ids.Slug.Should().Be("kung-fu-panda-3-2016");
            cast[0].Movie.Ids.Imdb.Should().Be("tt2267968");
            cast[0].Movie.Ids.Tmdb.Should().Be(140300U);

            cast[1].Character.Should().Be("Joe Brody");
            cast[1].Movie.Should().NotBeNull();
            cast[1].Movie.Title.Should().Be("Godzilla");
            cast[1].Movie.Year.Should().Be(2014);
            cast[1].Movie.Ids.Should().NotBeNull();
            cast[1].Movie.Ids.Trakt.Should().Be(24U);
            cast[1].Movie.Ids.Slug.Should().Be("godzilla-2014");
            cast[1].Movie.Ids.Imdb.Should().Be("tt0831387");
            cast[1].Movie.Ids.Tmdb.Should().Be(124905U);

            movieCredits.Crew.Should().NotBeNull();
            movieCredits.Crew.Art.Should().BeNull();
            movieCredits.Crew.Camera.Should().BeNull();
            movieCredits.Crew.CostumeAndMakeup.Should().BeNull();
            movieCredits.Crew.Crew.Should().BeNull();
            movieCredits.Crew.Directing.Should().NotBeNull().And.HaveCount(1);

            var directing = movieCredits.Crew.Directing.ToArray();

            directing[0].Job.Should().Be("Director");
            directing[0].Movie.Should().NotBeNull();
            directing[0].Movie.Title.Should().Be("Godzilla");
            directing[0].Movie.Year.Should().Be(2014);
            directing[0].Movie.Ids.Should().NotBeNull();
            directing[0].Movie.Ids.Trakt.Should().Be(24U);
            directing[0].Movie.Ids.Slug.Should().Be("godzilla-2014");
            directing[0].Movie.Ids.Imdb.Should().Be("tt0831387");
            directing[0].Movie.Ids.Tmdb.Should().Be(124905U);

            movieCredits.Crew.Editing.Should().BeNull();
            movieCredits.Crew.Lighting.Should().BeNull();
            movieCredits.Crew.Production.Should().NotBeNull().And.HaveCount(1);

            var production = movieCredits.Crew.Production.ToArray();

            production[0].Job.Should().Be("Producer");
            production[0].Movie.Should().NotBeNull();
            production[0].Movie.Title.Should().Be("Godzilla");
            production[0].Movie.Year.Should().Be(2014);
            production[0].Movie.Ids.Should().NotBeNull();
            production[0].Movie.Ids.Trakt.Should().Be(24U);
            production[0].Movie.Ids.Slug.Should().Be("godzilla-2014");
            production[0].Movie.Ids.Imdb.Should().Be("tt0831387");
            production[0].Movie.Ids.Tmdb.Should().Be(124905U);

            movieCredits.Crew.Sound.Should().BeNull();
            movieCredits.Crew.VisualEffects.Should().BeNull();
            movieCredits.Crew.Writing.Should().NotBeNull().And.HaveCount(1);

            var writing = movieCredits.Crew.Writing.ToArray();

            writing[0].Job.Should().Be("Screenplay");
            writing[0].Movie.Should().NotBeNull();
            writing[0].Movie.Title.Should().Be("Godzilla");
            writing[0].Movie.Year.Should().Be(2014);
            writing[0].Movie.Ids.Should().NotBeNull();
            writing[0].Movie.Ids.Trakt.Should().Be(24U);
            writing[0].Movie.Ids.Slug.Should().Be("godzilla-2014");
            writing[0].Movie.Ids.Imdb.Should().Be("tt0831387");
            writing[0].Movie.Ids.Tmdb.Should().Be(124905U);
        }
    }
}
