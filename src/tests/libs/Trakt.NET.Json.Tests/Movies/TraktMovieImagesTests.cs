namespace TraktNET.Json.Movies
{
    public sealed class TraktMovieImagesTests
    {
        [Fact]
        public void TestTraktMovieImagesConstructor()
        {
            var movieImages = new TraktMovieImages();

            movieImages.Fanart.ShouldBeNull();
            movieImages.Poster.ShouldBeNull();
            movieImages.Logo.ShouldBeNull();
            movieImages.Clearart.ShouldBeNull();
            movieImages.Banner.ShouldBeNull();
            movieImages.Thumb.ShouldBeNull();
        }

        [Fact]
        public async Task TestTraktMovieImagesFromJson()
        {
            TraktMovieImages? movieImages = await TestUtility.DeserializeJsonAsync<TraktMovieImages>("Movies\\movieimages.json");

            movieImages.ShouldNotBeNull();

            movieImages!.Fanart.ShouldNotBeNull();
            movieImages!.Fanart!.Count.ShouldBe(1);
            movieImages!.Fanart!.ShouldBe([ "walter-r2.trakt.tv/images/movies/000/293/990/fanarts/medium/2ea7854adf.jpg.webp" ]);

            movieImages!.Poster.ShouldNotBeNull();
            movieImages!.Poster!.Count.ShouldBe(1);
            movieImages!.Poster!.ShouldBe([ "walter-r2.trakt.tv/images/movies/000/293/990/posters/thumb/61ceb0624b.jpg.webp" ]);

            movieImages!.Logo.ShouldNotBeNull();
            movieImages!.Logo!.Count.ShouldBe(1);
            movieImages!.Logo!.ShouldBe([ "walter-r2.trakt.tv/images/movies/000/293/990/logos/medium/9021d3352d.png.webp" ]);

            movieImages!.Clearart.ShouldNotBeNull();
            movieImages!.Clearart!.Count.ShouldBe(1);
            movieImages!.Clearart!.ShouldBe([ "walter-r2.trakt.tv/images/movies/000/293/990/cleararts/medium/719bb7c638.png.webp" ]);

            movieImages!.Banner.ShouldNotBeNull();
            movieImages!.Banner!.Count.ShouldBe(1);
            movieImages!.Banner!.ShouldBe([ "walter-r2.trakt.tv/images/movies/000/293/990/banners/medium/aadecf57bf.jpg.webp" ]);

            movieImages!.Thumb.ShouldNotBeNull();
            movieImages!.Thumb!.Count.ShouldBe(1);
            movieImages!.Thumb!.ShouldBe([ "walter-r2.trakt.tv/images/movies/000/293/990/thumbs/medium/6d944d9545.jpg.webp" ]);
        }
    }
}
