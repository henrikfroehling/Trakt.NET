namespace TraktNET.Json.Episodes
{
    public sealed class TraktEpisodeIDsTests
    {
        [Fact]
        public void TestTraktEpisodeIDsConstructor()
        {
            var episodeIDs = new TraktEpisodeIDs();

            episodeIDs.Trakt.ShouldBeNull();
            episodeIDs.TVDB.ShouldBeNull();
            episodeIDs.IMDB.ShouldBeNull();
            episodeIDs.TMDB.ShouldBeNull();

            episodeIDs.HasAnyID.ShouldBe(false);
            episodeIDs.BestID.ShouldBeEmpty();
        }

        [Fact]
        public async Task TestTraktEpisodeIDsFromJson()
        {
            TraktEpisodeIDs? episodeIDs = await TraktTestUtility.DeserializeJsonAsync<TraktEpisodeIDs>("Episodes\\episodeids.json");

            episodeIDs.ShouldNotBeNull();

            episodeIDs!.Trakt.ShouldBe(73640U);
            episodeIDs!.TVDB.ShouldBe(3254641U);
            episodeIDs!.IMDB.ShouldBe("tt1480055");
            episodeIDs!.TMDB.ShouldBe(63056U);

            episodeIDs!.HasAnyID.ShouldBe(true);
            episodeIDs!.BestID.ShouldBe("73640");
        }
    }
}
