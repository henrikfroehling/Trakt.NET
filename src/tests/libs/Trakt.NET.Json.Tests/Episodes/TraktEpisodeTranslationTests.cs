namespace TraktNET.Json.Episodes
{
    public partial class TraktEpisodeTranslationTests
    {
        [Fact]
        public void TestTraktEpisodeTranslationConstructor()
        {
            var episodeTranslation = new TraktEpisodeTranslation();

            episodeTranslation.Title.Should().BeNull();
            episodeTranslation.Overview.Should().BeNull();
            episodeTranslation.Language.Should().BeNull();
            episodeTranslation.Country.Should().BeNull();
        }

        [Fact]
        public async Task TestTraktEpisodeTranslationFromJson()
        {
            TraktEpisodeTranslation? episodeTranslation = await TestUtility.DeserializeJsonAsync<TraktEpisodeTranslation>("Episodes\\episodetranslation.json");

            episodeTranslation.Should().NotBeNull();

            episodeTranslation!.Title.Should().Be("Winter Is Coming");
            episodeTranslation!.Overview.Should().Be("Jon Arryn, the Hand of the King, is dead.");
            episodeTranslation!.Language.Should().Be("en");
            episodeTranslation!.Country.Should().Be("us");
        }
    }
}
