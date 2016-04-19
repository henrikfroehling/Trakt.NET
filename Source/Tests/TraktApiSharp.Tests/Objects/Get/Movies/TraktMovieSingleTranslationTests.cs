namespace TraktApiSharp.Tests.Objects.Movies
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Newtonsoft.Json;
    using TraktApiSharp.Objects.Get.Movies;
    using Utils;

    [TestClass]
    public class TraktMovieSingleTranslationTests
    {
        [TestMethod]
        public void TestTraktMovieSingleTranslationDefaultConstructor()
        {
            var translation = new TraktMovieTranslation();

            translation.Title.Should().BeNullOrEmpty();
            translation.Overview.Should().BeNullOrEmpty();
            translation.Tagline.Should().BeNullOrEmpty();
            translation.LanguageCode.Should().BeNullOrEmpty();
            translation.Language.Should().BeNull();
        }

        [TestMethod]
        public void TestTraktMovieSingleTranslationReadFromJson()
        {
            var jsonFile = TestUtility.ReadFileContents(@"Objects\Get\Movies\MovieSingleTranslation.json");

            jsonFile.Should().NotBeNullOrEmpty();

            var translation = JsonConvert.DeserializeObject<TraktMovieTranslation>(jsonFile);

            translation.Should().NotBeNull();
            translation.Title.Should().Be("Star Wars: Episode VII - The Force Awakens");
            translation.Overview.Should().Be("A continuation of the saga created by George Lucas, set thirty years after Star Wars: Episode VI – Return of the Jedi.");
            translation.Tagline.Should().Be("The Force Lives On...");
            translation.LanguageCode.Should().Be("en");
            translation.Language.Should().NotBeNull();
        }
    }
}
