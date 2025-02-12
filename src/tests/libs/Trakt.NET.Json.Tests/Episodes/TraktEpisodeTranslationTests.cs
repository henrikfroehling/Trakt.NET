namespace TraktNET.Json.Episodes
{
    public sealed class TraktEpisodeTranslationTests
    {
        [Fact]
        public void TestTraktEpisodeTranslationConstructor()
        {
            var episodeTranslation = new TraktEpisodeTranslation();

            episodeTranslation.Title.ShouldBeNull();
            episodeTranslation.Overview.ShouldBeNull();
            episodeTranslation.Language.ShouldBeNull();
            episodeTranslation.Country.ShouldBeNull();

            episodeTranslation.ToString().ShouldBe("no title set");
        }

        [Fact]
        public async Task TestTraktEpisodeTranslationFromJson()
        {
            TraktEpisodeTranslation? episodeTranslation = await TraktTestUtility.DeserializeJsonAsync<TraktEpisodeTranslation>("Episodes\\episodetranslation.json");

            episodeTranslation.ShouldNotBeNull();

            episodeTranslation!.Title.ShouldBe("Winter Is Coming");
            episodeTranslation!.Overview.ShouldBe("Jon Arryn, the Hand of the King, is dead.");
            episodeTranslation!.Language.ShouldBe("en");
            episodeTranslation!.Country.ShouldBe("us");

            episodeTranslation!.ToString().ShouldBe("en-US=Winter Is Coming");
        }
    }
}
