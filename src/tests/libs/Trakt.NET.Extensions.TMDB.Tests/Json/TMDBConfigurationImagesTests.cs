namespace TraktNET.Json
{
    public sealed class TMDBConfigurationImagesTests
    {
        [Fact]
        public void TestTMDBConfigurationImagesConstructor()
        {
            var configurationImages = new TMDBConfigurationImages();

            configurationImages.BaseUrl.ShouldBeNull();
            configurationImages.SecureBaseUrl.ShouldBeNull();
            configurationImages.BackdropSizes.ShouldBeNull();
            configurationImages.LogoSizes.ShouldBeNull();
            configurationImages.PosterSizes.ShouldBeNull();
            configurationImages.ProfileSizes.ShouldBeNull();
            configurationImages.StillSizes.ShouldBeNull();
        }

        [Fact]
        public async Task TestTMDBConfigurationImagesFromJson()
        {
            TMDBConfigurationImages? configurationImages = await TMDBTestUtility.DeserializeJsonAsync<TMDBConfigurationImages>("configurationimages.json");

            configurationImages.ShouldNotBeNull();

            configurationImages!.BaseUrl.ShouldBe("http://image.tmdb.org/t/p/");
            configurationImages!.SecureBaseUrl.ShouldBe("https://image.tmdb.org/t/p/");

            configurationImages!.BackdropSizes.ShouldNotBeNull();
            configurationImages!.BackdropSizes!.Count.ShouldBe(4);

            configurationImages!.BackdropSizes![0].ShouldBe(TMDBBackdropSize.Width300);
            configurationImages!.BackdropSizes![1].ShouldBe(TMDBBackdropSize.Width780);
            configurationImages!.BackdropSizes![2].ShouldBe(TMDBBackdropSize.Width1280);
            configurationImages!.BackdropSizes![3].ShouldBe(TMDBBackdropSize.Original);

            configurationImages!.LogoSizes.ShouldNotBeNull();
            configurationImages!.LogoSizes!.Count.ShouldBe(7);

            configurationImages!.LogoSizes![0].ShouldBe(TMDBLogoSize.Width45);
            configurationImages!.LogoSizes![1].ShouldBe(TMDBLogoSize.Width92);
            configurationImages!.LogoSizes![2].ShouldBe(TMDBLogoSize.Width154);
            configurationImages!.LogoSizes![3].ShouldBe(TMDBLogoSize.Width185);
            configurationImages!.LogoSizes![4].ShouldBe(TMDBLogoSize.Width300);
            configurationImages!.LogoSizes![5].ShouldBe(TMDBLogoSize.Width500);
            configurationImages!.LogoSizes![6].ShouldBe(TMDBLogoSize.Original);

            configurationImages!.PosterSizes.ShouldNotBeNull();
            configurationImages!.PosterSizes!.Count.ShouldBe(7);

            configurationImages!.PosterSizes![0].ShouldBe(TMDBPosterSize.Width92);
            configurationImages!.PosterSizes![1].ShouldBe(TMDBPosterSize.Width154);
            configurationImages!.PosterSizes![2].ShouldBe(TMDBPosterSize.Width185);
            configurationImages!.PosterSizes![3].ShouldBe(TMDBPosterSize.Width342);
            configurationImages!.PosterSizes![4].ShouldBe(TMDBPosterSize.Width500);
            configurationImages!.PosterSizes![5].ShouldBe(TMDBPosterSize.Width780);
            configurationImages!.PosterSizes![6].ShouldBe(TMDBPosterSize.Original);

            configurationImages!.ProfileSizes.ShouldNotBeNull();
            configurationImages!.ProfileSizes!.Count.ShouldBe(4);

            configurationImages!.ProfileSizes![0].ShouldBe(TMDBProfileSize.Width45);
            configurationImages!.ProfileSizes![1].ShouldBe(TMDBProfileSize.Width185);
            configurationImages!.ProfileSizes![2].ShouldBe(TMDBProfileSize.Height632);
            configurationImages!.ProfileSizes![3].ShouldBe(TMDBProfileSize.Original);

            configurationImages!.StillSizes.ShouldNotBeNull();
            configurationImages!.StillSizes!.Count.ShouldBe(4);

            configurationImages!.StillSizes![0].ShouldBe(TMDBStillSize.Width92);
            configurationImages!.StillSizes![1].ShouldBe(TMDBStillSize.Width185);
            configurationImages!.StillSizes![2].ShouldBe(TMDBStillSize.Width300);
            configurationImages!.StillSizes![3].ShouldBe(TMDBStillSize.Original);
        }
    }
}
