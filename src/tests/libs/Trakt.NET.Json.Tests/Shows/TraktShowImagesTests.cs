namespace TraktNET.Json.Shows
{
    public sealed class TraktShowImagesTests
    {
        [Fact]
        public void TestTraktShowImagesConstructor()
        {
            var showImages = new TraktShowImages();

            showImages.Fanart.ShouldBeNull();
            showImages.Poster.ShouldBeNull();
            showImages.Logo.ShouldBeNull();
            showImages.Clearart.ShouldBeNull();
            showImages.Banner.ShouldBeNull();
            showImages.Thumb.ShouldBeNull();
        }

        [Fact]
        public async Task TestTraktShowImagesFromJson()
        {
            TraktShowImages? showImages = await TestUtility.DeserializeJsonAsync<TraktShowImages>("Shows\\showimages.json");

            showImages.ShouldNotBeNull();

            showImages!.Fanart.ShouldNotBeNull();
            showImages!.Fanart!.Count.ShouldBe(1);
            showImages!.Fanart!.ShouldBe([ "walter-r2.trakt.tv/images/shows/000/001/390/fanarts/medium/76d5df8aed.jpg.webp" ]);

            showImages!.Poster.ShouldNotBeNull();
            showImages!.Poster!.Count.ShouldBe(1);
            showImages!.Poster!.ShouldBe([ "walter-r2.trakt.tv/images/shows/000/001/390/posters/thumb/93df9cd612.jpg.webp" ]);

            showImages!.Logo.ShouldNotBeNull();
            showImages!.Logo!.Count.ShouldBe(1);
            showImages!.Logo!.ShouldBe([ "walter-r2.trakt.tv/images/shows/000/001/390/logos/medium/13b614ad43.png.webp" ]);

            showImages!.Clearart.ShouldNotBeNull();
            showImages!.Clearart!.Count.ShouldBe(1);
            showImages!.Clearart!.ShouldBe([ "walter-r2.trakt.tv/images/shows/000/001/390/cleararts/medium/5cbde9e647.png.webp" ]);

            showImages!.Banner.ShouldNotBeNull();
            showImages!.Banner!.Count.ShouldBe(1);
            showImages!.Banner!.ShouldBe([ "walter-r2.trakt.tv/images/shows/000/001/390/banners/medium/9fefff703d.jpg.webp" ]);

            showImages!.Thumb.ShouldNotBeNull();
            showImages!.Thumb!.Count.ShouldBe(1);
            showImages!.Thumb!.ShouldBe([ "walter-r2.trakt.tv/images/shows/000/001/390/thumbs/medium/7beccbd5a1.jpg.webp" ]);
        }
    }
}
