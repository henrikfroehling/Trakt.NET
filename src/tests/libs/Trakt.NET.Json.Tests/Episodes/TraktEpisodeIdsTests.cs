namespace TraktNET.Json.Episodes
{
    public partial class TraktEpisodeIdsTests
    {
        [Fact]
        public void TestTraktEpisodeIdsConstructor()
        {
            var episodeIds = new TraktEpisodeIds();

            episodeIds.Trakt.Should().BeNull();
            episodeIds.TVDB.Should().BeNull();
            episodeIds.IMDB.Should().BeNull();
            episodeIds.TMDB.Should().BeNull();

            episodeIds.HasAnyID.Should().BeFalse();
            episodeIds.BestID.Should().BeEmpty();
        }

        [Fact]
        public async Task TestTraktEpisodeIdsFromJson()
        {
            TraktEpisodeIds? episodeIds = await TestUtility.DeserializeJsonAsync<TraktEpisodeIds>("Episodes\\episodeids.json");

            episodeIds.Should().NotBeNull();

            episodeIds!.Trakt.Should().Be(73640U);
            episodeIds!.TVDB.Should().Be(3254641U);
            episodeIds!.IMDB.Should().Be("tt1480055");
            episodeIds!.TMDB.Should().Be(63056U);

            episodeIds!.HasAnyID.Should().BeTrue();
            episodeIds!.BestID.Should().Be("73640");
        }
    }
}
