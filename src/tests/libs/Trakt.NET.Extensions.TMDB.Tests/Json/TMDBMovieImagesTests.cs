namespace TraktNET.Json
{
    public sealed class TMDBMovieImagesTests
    {
        [Fact]
        public void TestTMDBMovieImagesConstructor()
        {
            var movieImages = new TMDBMovieImages();

            movieImages.Id.ShouldBeNull();
            movieImages.Posters.ShouldBeNull();
        }

        [Fact]
        public async Task TestTMDBMovieImagesFromJson()
        {
            TMDBMovieImages? movieImages = await TMDBTestUtility.DeserializeJsonAsync<TMDBMovieImages>("movieimages.json");

            movieImages.ShouldNotBeNull();

            movieImages!.Id.ShouldBe(85U);

            movieImages!.Backdrops.ShouldNotBeNull();
            movieImages!.Backdrops!.Count.ShouldBe(2);

            movieImages!.Backdrops[0].ShouldNotBeNull();

            movieImages!.Backdrops[0]!.FilePath.ShouldBe("/ueDw7djPgKPZfph0vC43aD2EMyF.jpg");
            movieImages!.Backdrops[0]!.Width.ShouldBe(3840U);
            movieImages!.Backdrops[0]!.Height.ShouldBe(2160U);
            movieImages!.Backdrops[0]!.AspectRatio.ShouldBe(1.778f);
            movieImages!.Backdrops[0]!.VoteCount.ShouldBe(13U);
            movieImages!.Backdrops[0]!.VoteAverage.ShouldBe(6.346f);
            movieImages!.Backdrops[0]!.ISO6391.ShouldBeNull();

            movieImages!.Backdrops[1].ShouldNotBeNull();

            movieImages!.Backdrops[1]!.FilePath.ShouldBe("/odblUdMERDmhQ4ei9Ja8tRZ4br6.jpg");
            movieImages!.Backdrops[1]!.Width.ShouldBe(2880U);
            movieImages!.Backdrops[1]!.Height.ShouldBe(1620U);
            movieImages!.Backdrops[1]!.AspectRatio.ShouldBe(1.778f);
            movieImages!.Backdrops[1]!.VoteCount.ShouldBe(7U);
            movieImages!.Backdrops[1]!.VoteAverage.ShouldBe(5.786f);
            movieImages!.Backdrops[1]!.ISO6391.ShouldBeNull();

            movieImages!.Logos.ShouldNotBeNull();
            movieImages!.Logos!.Count.ShouldBe(2);

            movieImages!.Logos[0].ShouldNotBeNull();

            movieImages!.Logos[0]!.FilePath.ShouldBe("/yCZMIJaNriW79rR8NL4Kiq1mvWr.png");
            movieImages!.Logos[0]!.Width.ShouldBe(784U);
            movieImages!.Logos[0]!.Height.ShouldBe(271U);
            movieImages!.Logos[0]!.AspectRatio.ShouldBe(2.893f);
            movieImages!.Logos[0]!.VoteCount.ShouldBe(2U);
            movieImages!.Logos[0]!.VoteAverage.ShouldBe(3.334f);
            movieImages!.Logos[0]!.ISO6391.ShouldBe("en");

            movieImages!.Logos[1].ShouldNotBeNull();

            movieImages!.Logos[1]!.FilePath.ShouldBe("/hZMakoW3Uh8ZGDMYVFMuj7KoaLa.png");
            movieImages!.Logos[1]!.Width.ShouldBe(780U);
            movieImages!.Logos[1]!.Height.ShouldBe(269U);
            movieImages!.Logos[1]!.AspectRatio.ShouldBe(2.9f);
            movieImages!.Logos[1]!.VoteCount.ShouldBe(1U);
            movieImages!.Logos[1]!.VoteAverage.ShouldBe(3.334f);
            movieImages!.Logos[1]!.ISO6391.ShouldBe("en");

            movieImages!.Posters.ShouldNotBeNull();
            movieImages!.Posters!.Count.ShouldBe(2);

            movieImages!.Posters[0].ShouldNotBeNull();

            movieImages!.Posters[0]!.FilePath.ShouldBe("/ceG9VzoRAVGwivFU403Wc3AHRys.jpg");
            movieImages!.Posters[0]!.Width.ShouldBe(2000U);
            movieImages!.Posters[0]!.Height.ShouldBe(3000U);
            movieImages!.Posters[0]!.AspectRatio.ShouldBe(0.667f);
            movieImages!.Posters[0]!.VoteCount.ShouldBe(48U);
            movieImages!.Posters[0]!.VoteAverage.ShouldBe(4.854f);
            movieImages!.Posters[0]!.ISO6391.ShouldBe("en");

            movieImages!.Posters[1].ShouldNotBeNull();

            movieImages!.Posters[1]!.FilePath.ShouldBe("/6vyOkDUnxzJsoJWlX6TwzfxekeJ.jpg");
            movieImages!.Posters[1]!.Width.ShouldBe(1200U);
            movieImages!.Posters[1]!.Height.ShouldBe(1800U);
            movieImages!.Posters[1]!.AspectRatio.ShouldBe(0.667f);
            movieImages!.Posters[1]!.VoteCount.ShouldBe(12U);
            movieImages!.Posters[1]!.VoteAverage.ShouldBe(5.25f);
            movieImages!.Posters[1]!.ISO6391.ShouldBe("en");
        }
    }
}
