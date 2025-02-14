namespace TraktNET.Json
{
    public sealed class TMDBEpisodeImagesTests
    {
        [Fact]
        public void TestTMDBEpisodeImagesConstructor()
        {
            var episodeImages = new TMDBEpisodeImages();

            episodeImages.Id.ShouldBeNull();
            episodeImages.Stills.ShouldBeNull();
        }

        [Fact]
        public async Task TestTMDBEpisodeImagesFromJson()
        {
            TMDBEpisodeImages? episodeImages = await TMDBTestUtility.DeserializeJsonAsync<TMDBEpisodeImages>("episodeimages.json");

            episodeImages.ShouldNotBeNull();

            episodeImages!.Id.ShouldBe(63056U);
            episodeImages!.Stills.ShouldNotBeNull();
            episodeImages!.Stills!.Count.ShouldBe(2);

            episodeImages!.Stills[0].ShouldNotBeNull();

            episodeImages!.Stills[0]!.FilePath.ShouldBe("/9hGF3WUkBf7cSjMg0cdMDHJkByd.jpg");
            episodeImages!.Stills[0]!.Width.ShouldBe(1920U);
            episodeImages!.Stills[0]!.Height.ShouldBe(1080U);
            episodeImages!.Stills[0]!.AspectRatio.ShouldBe(1.778f);
            episodeImages!.Stills[0]!.VoteCount.ShouldBe(8U);
            episodeImages!.Stills[0]!.VoteAverage.ShouldBe(6.312f);
            episodeImages!.Stills[0]!.ISO6391.ShouldBeNull();

            episodeImages!.Stills[1].ShouldNotBeNull();

            episodeImages!.Stills[1]!.FilePath.ShouldBe("/wrGWeW4WKxnaeA8sxJb2T9O6ryo.jpg");
            episodeImages!.Stills[1]!.Width.ShouldBe(1920U);
            episodeImages!.Stills[1]!.Height.ShouldBe(1080U);
            episodeImages!.Stills[1]!.AspectRatio.ShouldBe(1.778f);
            episodeImages!.Stills[1]!.VoteCount.ShouldBe(11U);
            episodeImages!.Stills[1]!.VoteAverage.ShouldBe(5.06f);
            episodeImages!.Stills[1]!.ISO6391.ShouldBeNull();
        }
    }
}
