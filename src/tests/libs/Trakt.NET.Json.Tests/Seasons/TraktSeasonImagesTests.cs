namespace TraktNET.Json.Seasons
{
    public sealed class TraktSeasonImagesTests
    {
        [Fact]
        public void TestTraktSeasonImagesConstructor()
        {
            var seasonImages = new TraktSeasonImages();

            seasonImages.Poster.ShouldBeNull();
            seasonImages.Thumb.ShouldBeNull();
        }

        [Fact]
        public async Task TestTraktSeasonImagesFromJson()
        {
            TraktSeasonImages? seasonImages = await TestUtility.DeserializeJsonAsync<TraktSeasonImages>("Seasons\\seasonimages.json");

            seasonImages.ShouldNotBeNull();

            seasonImages!.Poster.ShouldNotBeNull();
            seasonImages!.Poster!.Count.ShouldBe(1);
            seasonImages!.Poster!.ShouldBe([ "walter-r2.trakt.tv/images/seasons/000/003/963/posters/thumb/15e611179e.jpg.webp" ]);

            seasonImages!.Thumb.ShouldNotBeNull();
            seasonImages!.Thumb!.Count.ShouldBe(1);
            seasonImages!.Thumb!.ShouldBe([ "walter-r2.trakt.tv/images/seasons/000/003/963/thumbs/medium/6c996deed7.jpg.webp" ]);
        }
    }
}
