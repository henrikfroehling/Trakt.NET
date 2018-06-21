namespace TraktNet.Tests.Objects.Get.Episodes.Implementations
{
    using FluentAssertions;
    using System.Threading.Tasks;
    using Traits;
    using TraktNet.Objects.Get.Episodes;
    using TraktNet.Objects.Get.Episodes.Json.Reader;
    using Xunit;

    [Category("Objects.Get.Episodes.Implementations")]
    public class TraktEpisodeTranslation_Tests
    {
        [Fact]
        public void Test_TraktEpisodeTranslation_Default_Constructor()
        {
            var episodeTranslation = new TraktEpisodeTranslation();

            episodeTranslation.Title.Should().BeNullOrEmpty();
            episodeTranslation.Overview.Should().BeNullOrEmpty();
            episodeTranslation.LanguageCode.Should().BeNullOrEmpty();
        }

        [Fact]
        public async Task Test_TraktEpisodeTranslation_From_Json()
        {
            var jsonReader = new EpisodeTranslationObjectJsonReader();
            var episodeTranslation = await jsonReader.ReadObjectAsync(JSON) as TraktEpisodeTranslation;

            episodeTranslation.Should().NotBeNull();
            episodeTranslation.Title.Should().Be("Winter Is Coming");
            episodeTranslation.Overview.Should().Be("Jon Arryn, the Hand of the King, is dead. King Robert Baratheon plans to ask his oldest friend, Eddard Stark, to take Jon's place. Across the sea, Viserys Targaryen plans to wed his sister to a nomadic warlord in exchange for an army.");
            episodeTranslation.LanguageCode.Should().Be("en");
        }

        [Fact]
        public void Test_TraktEpisodeTranslation_ToString()
        {
            var episodeTranslation = new TraktEpisodeTranslation();
            episodeTranslation.ToString().Should().Be("no title set");

            episodeTranslation.Title = "Winter Is Coming";
            episodeTranslation.ToString().Should().Be("Winter Is Coming");
        }

        private const string JSON =
            @"{
                ""title"": ""Winter Is Coming"",
                ""overview"": ""Jon Arryn, the Hand of the King, is dead. King Robert Baratheon plans to ask his oldest friend, Eddard Stark, to take Jon's place. Across the sea, Viserys Targaryen plans to wed his sister to a nomadic warlord in exchange for an army."",
                ""language"": ""en""
              }";
    }
}
