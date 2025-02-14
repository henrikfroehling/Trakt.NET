namespace TraktNET.Json
{
    public sealed class TMDBSeasonImagesTests
    {
        [Fact]
        public void TestTMDBSeasonImagesConstructor()
        {
            var seasonImages = new TMDBSeasonImages();

            seasonImages.Id.ShouldBeNull();
            seasonImages.Posters.ShouldBeNull();
        }

        [Fact]
        public async Task TestTMDBSeasonImagesFromJson()
        {
            TMDBSeasonImages? seasonImages = await TMDBTestUtility.DeserializeJsonAsync<TMDBSeasonImages>("seasonimages.json");

            seasonImages.ShouldNotBeNull();

            seasonImages!.Id.ShouldBe(3624U);
            seasonImages!.Posters.ShouldNotBeNull();
            seasonImages!.Posters!.Count.ShouldBe(2);

            seasonImages!.Posters[0].ShouldNotBeNull();

            seasonImages!.Posters[0]!.FilePath.ShouldBe("/wgfKiqzuMrFIkU1M68DDDY8kGC1.jpg");
            seasonImages!.Posters[0]!.Width.ShouldBe(1000U);
            seasonImages!.Posters[0]!.Height.ShouldBe(1500U);
            seasonImages!.Posters[0]!.AspectRatio.ShouldBe(0.667f);
            seasonImages!.Posters[0]!.VoteCount.ShouldBe(19U);
            seasonImages!.Posters[0]!.VoteAverage.ShouldBe(6.0f);
            seasonImages!.Posters[0]!.ISO6391.ShouldBe("en");

            seasonImages!.Posters[1].ShouldNotBeNull();

            seasonImages!.Posters[1]!.FilePath.ShouldBe("/zwaj4egrhnXOBIit1tyb4Sbt3KP.jpg");
            seasonImages!.Posters[1]!.Width.ShouldBe(400U);
            seasonImages!.Posters[1]!.Height.ShouldBe(578U);
            seasonImages!.Posters[1]!.AspectRatio.ShouldBe(0.692f);
            seasonImages!.Posters[1]!.VoteCount.ShouldBe(33U);
            seasonImages!.Posters[1]!.VoteAverage.ShouldBe(5.45f);
            seasonImages!.Posters[1]!.ISO6391.ShouldBe("en");
        }
    }
}
