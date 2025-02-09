namespace TraktNET.Json.Episodes
{
    public sealed class TraktEpisodeImagesTests
    {
        [Fact]
        public void TestTraktEpisodeImagesConstructor()
        {
            var episodeImages = new TraktEpisodeImages();

            episodeImages.Screenshot.ShouldBeNull();
        }

        [Fact]
        public async Task TestTraktEpisodeImagesFromJson()
        {
            TraktEpisodeImages? episodeImages = await TestUtility.DeserializeJsonAsync<TraktEpisodeImages>("Episodes\\episodeimages.json");

            episodeImages.ShouldNotBeNull();

            episodeImages!.Screenshot.ShouldNotBeNull();
            episodeImages!.Screenshot!.Count.ShouldBe(1);
            episodeImages!.Screenshot!.ShouldBe([ "walter-r2.trakt.tv/images/episodes/000/073/640/screenshots/medium/66c1ba1793.jpg.webp" ]);
        }
    }
}
