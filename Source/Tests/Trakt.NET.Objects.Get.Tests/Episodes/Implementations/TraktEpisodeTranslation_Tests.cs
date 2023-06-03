namespace TraktNet.Objects.Get.Tests.Episodes.Implementations
{
    using FluentAssertions;
    using System.Threading.Tasks;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Objects.Get.Episodes;
    using TraktNet.Objects.Get.Episodes.Json.Reader;
    using Xunit;

    [TestCategory("Objects.Get.Episodes.Implementations")]
    public class TraktEpisodeTranslation_Tests
    {
        [Fact]
        public void Test_TraktEpisodeTranslation_Default_Constructor()
        {
            var episodeTranslation = new TraktEpisodeTranslation();

            episodeTranslation.Title.Should().BeNull();
            episodeTranslation.Overview.Should().BeNull();
            episodeTranslation.LanguageCode.Should().BeNull();
            episodeTranslation.CountryCode.Should().BeNull();
        }

        [Fact]
        public async Task Test_TraktEpisodeTranslation_From_Json()
        {
            var jsonReader = new EpisodeTranslationObjectJsonReader();
            var episodeTranslation = await jsonReader.ReadObjectAsync(JSON) as TraktEpisodeTranslation;

            episodeTranslation.Should().NotBeNull();
            episodeTranslation.Title.Should().Be("Winter Is Coming");
            episodeTranslation.Overview.Should().Be("Jon Arryn, the Hand of the King, is dead...");
            episodeTranslation.LanguageCode.Should().Be("en");
            episodeTranslation.CountryCode.Should().Be("us");
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
                ""overview"": ""Jon Arryn, the Hand of the King, is dead..."",
                ""language"": ""en"",
                ""country"": ""us""
              }";
    }
}
