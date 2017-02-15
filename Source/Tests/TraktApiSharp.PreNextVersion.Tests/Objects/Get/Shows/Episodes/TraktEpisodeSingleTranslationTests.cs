namespace TraktApiSharp.Tests.Objects.Shows
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Newtonsoft.Json;
    using TraktApiSharp.Objects.Get.Episodes;
    using Utils;

    [TestClass]
    public class TraktEpisodeSingleTranslationTests
    {
        [TestMethod]
        public void TestTraktEpisodeSingleTranslationDefaultConstructor()
        {
            var translation = new TraktEpisodeTranslation();

            translation.Title.Should().BeNullOrEmpty();
            translation.Overview.Should().BeNullOrEmpty();
            translation.LanguageCode.Should().BeNullOrEmpty();
        }

        [TestMethod]
        public void TestTraktEpisodeSingleTranslationReadFromJson()
        {
            var jsonFile = TestUtility.ReadFileContents(@"Objects\Get\Shows\Episodes\EpisodeSingleTranslation.json");

            jsonFile.Should().NotBeNullOrEmpty();

            var translation = JsonConvert.DeserializeObject<TraktEpisodeTranslation>(jsonFile);

            translation.Should().NotBeNull();
            translation.Title.Should().Be("Winter Is Coming");
            translation.Overview.Should().Be("Jon Arryn, the Hand of the King, is dead. King Robert Baratheon plans to ask his oldest friend, Eddard Stark, to take Jon's place. Across the sea, Viserys Targaryen plans to wed his sister to a nomadic warlord in exchange for an army.");
            translation.LanguageCode.Should().Be("en");
        }
    }
}
