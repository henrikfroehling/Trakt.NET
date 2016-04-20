namespace TraktApiSharp.Tests.Objects.Movies
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Newtonsoft.Json;
    using System.Collections.Generic;
    using System.Linq;
    using TraktApiSharp.Objects.Get.Movies;
    using Utils;

    [TestClass]
    public class TraktMovieTranslationsTests
    {
        [TestMethod]
        public void TestTraktMovieTranslationsReadFromJson()
        {
            var jsonFile = TestUtility.ReadFileContents(@"Objects\Get\Movies\MovieTranslations.json");

            jsonFile.Should().NotBeNullOrEmpty();

            var translations = JsonConvert.DeserializeObject<IEnumerable<TraktMovieTranslation>>(jsonFile);

            translations.Should().NotBeNull();
            translations.Should().HaveCount(3);

            var translationsArray = translations.ToArray();

            translationsArray[0].Title.Should().Be("Star Wars: Episode VII - The Force Awakens");
            translationsArray[0].Overview.Should().Be("A continuation of the saga created by George Lucas, set thirty years after Star Wars: Episode VI – Return of the Jedi.");
            translationsArray[0].Tagline.Should().Be("The Force Lives On...");
            translationsArray[0].LanguageCode.Should().Be("en");

            translationsArray[1].Title.Should().Be("Star Wars: Episode VII - Das Erwachen der Macht");
            translationsArray[1].Overview.Should().Be("Erster Teil der von Walt Disney angekündigten dritten \"Star Wars\"-Trilogie, die im Jahr 2015 ihren Anfang nehmen soll.");
            translationsArray[1].Tagline.Should().BeEmpty();
            translationsArray[1].LanguageCode.Should().Be("de");

            translationsArray[2].Title.Should().Be("Star Wars: The Force Awakens");
            translationsArray[2].Overview.Should().Be("Thirty years after defeating the Galactic Empire, Han Solo and his allies face a new threat from the evil Kylo Ren and his army of Stormtroopers.");
            translationsArray[2].Tagline.Should().Be("Every generation has a story.");
            translationsArray[2].LanguageCode.Should().Be("en");
        }
    }
}
