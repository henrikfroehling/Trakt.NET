namespace TraktNET.Json
{
    public sealed class TMDBShowImagesTests
    {
        [Fact]
        public void TestTMDBShowImagesConstructor()
        {
            var showImages = new TMDBShowImages();

            showImages.Id.ShouldBeNull();
            showImages.Posters.ShouldBeNull();
        }

        [Fact]
        public async Task TestTMDBShowImagesFromJson()
        {
            TMDBShowImages? showImages = await TMDBTestUtility.DeserializeJsonAsync<TMDBShowImages>("showimages.json");

            showImages.ShouldNotBeNull();

            showImages!.Id.ShouldBe(1399U);

            showImages!.Backdrops.ShouldNotBeNull();
            showImages!.Backdrops!.Count.ShouldBe(2);

            showImages!.Backdrops[0].ShouldNotBeNull();

            showImages!.Backdrops[0]!.FilePath.ShouldBe("/zZqpAXxVSBtxV9qPBcscfXBcL2w.jpg");
            showImages!.Backdrops[0]!.Width.ShouldBe(3840U);
            showImages!.Backdrops[0]!.Height.ShouldBe(2160U);
            showImages!.Backdrops[0]!.AspectRatio.ShouldBe(1.778f);
            showImages!.Backdrops[0]!.VoteCount.ShouldBe(7U);
            showImages!.Backdrops[0]!.VoteAverage.ShouldBe(7.19f);
            showImages!.Backdrops[0]!.ISO6391.ShouldBeNull();

            showImages!.Backdrops[1].ShouldNotBeNull();

            showImages!.Backdrops[1]!.FilePath.ShouldBe("/jJojoFmsuLPQz8AOdkeV0b686RN.jpg");
            showImages!.Backdrops[1]!.Width.ShouldBe(2650U);
            showImages!.Backdrops[1]!.Height.ShouldBe(1491U);
            showImages!.Backdrops[1]!.AspectRatio.ShouldBe(1.777f);
            showImages!.Backdrops[1]!.VoteCount.ShouldBe(12U);
            showImages!.Backdrops[1]!.VoteAverage.ShouldBe(5.25f);
            showImages!.Backdrops[1]!.ISO6391.ShouldBeNull();

            showImages!.Logos.ShouldNotBeNull();
            showImages!.Logos!.Count.ShouldBe(2);

            showImages!.Logos[0].ShouldNotBeNull();

            showImages!.Logos[0]!.FilePath.ShouldBe("/9h2EzzhkWyC5g305xDZnd0dp6Ac.png");
            showImages!.Logos[0]!.Width.ShouldBe(4256U);
            showImages!.Logos[0]!.Height.ShouldBe(525U);
            showImages!.Logos[0]!.AspectRatio.ShouldBe(8.107f);
            showImages!.Logos[0]!.VoteCount.ShouldBe(2U);
            showImages!.Logos[0]!.VoteAverage.ShouldBe(3.334f);
            showImages!.Logos[0]!.ISO6391.ShouldBe("en");

            showImages!.Logos[1].ShouldNotBeNull();

            showImages!.Logos[1]!.FilePath.ShouldBe("/huXYbSsXMKDStsP6EI0crRGG6Oz.svg");
            showImages!.Logos[1]!.Width.ShouldBe(907U);
            showImages!.Logos[1]!.Height.ShouldBe(404U);
            showImages!.Logos[1]!.AspectRatio.ShouldBe(2.245f);
            showImages!.Logos[1]!.VoteCount.ShouldBe(3U);
            showImages!.Logos[1]!.VoteAverage.ShouldBe(2.278f);
            showImages!.Logos[1]!.ISO6391.ShouldBe("en");

            showImages!.Posters.ShouldNotBeNull();
            showImages!.Posters!.Count.ShouldBe(2);

            showImages!.Posters[0].ShouldNotBeNull();

            showImages!.Posters[0]!.FilePath.ShouldBe("/1XS1oqL89opfnbLl8WnZY1O1uJx.jpg");
            showImages!.Posters[0]!.Width.ShouldBe(2000U);
            showImages!.Posters[0]!.Height.ShouldBe(3000U);
            showImages!.Posters[0]!.AspectRatio.ShouldBe(0.667f);
            showImages!.Posters[0]!.VoteCount.ShouldBe(26U);
            showImages!.Posters[0]!.VoteAverage.ShouldBe(7.442f);
            showImages!.Posters[0]!.ISO6391.ShouldBe("en");

            showImages!.Posters[1].ShouldNotBeNull();

            showImages!.Posters[1]!.FilePath.ShouldBe("/tFCX1cXH4vO8i2oGINdgRgkFZMg.jpg");
            showImages!.Posters[1]!.Width.ShouldBe(750U);
            showImages!.Posters[1]!.Height.ShouldBe(1125U);
            showImages!.Posters[1]!.AspectRatio.ShouldBe(0.667f);
            showImages!.Posters[1]!.VoteCount.ShouldBe(8U);
            showImages!.Posters[1]!.VoteAverage.ShouldBe(8.77f);
            showImages!.Posters[1]!.ISO6391.ShouldBe("en");
        }
    }
}
