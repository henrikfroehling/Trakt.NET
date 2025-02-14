namespace TraktNET.Json
{
    public sealed class TMDBConfigurationTests
    {
        [Fact]
        public void TestTMDBConfigurationConstructor()
        {
            var configuration = new TMDBConfiguration();

            configuration.ChangeKeys.ShouldBeNull();
            configuration.Images.ShouldBeNull();
        }

        [Fact]
        public async Task TestTMDBConfigurationFromJson()
        {
            TMDBConfiguration? configuration = await TMDBTestUtility.DeserializeJsonAsync<TMDBConfiguration>("configuration.json");

            configuration.ShouldNotBeNull();

            configuration.ChangeKeys.ShouldNotBeNull();
            configuration.ChangeKeys!.Count.ShouldBe(53);
            configuration.ChangeKeys!.ShouldBe([
                "adult", "air_date", "also_known_as", "alternative_titles", "biography", "birthday", "budget", "cast", "certifications",
                "character_names", "created_by", "crew", "deathday", "episode", "episode_number", "episode_run_time", "freebase_id",
                "freebase_mid", "general", "genres", "guest_stars", "homepage", "images", "imdb_id", "languages", "name", "network",
                "origin_country", "original_name", "original_title", "overview", "parts", "place_of_birth", "plot_keywords", "production_code",
                "production_companies", "production_countries", "releases", "revenue", "runtime", "season", "season_number", "season_regular",
                "spoken_languages", "status", "tagline", "title", "translations", "tvdb_id", "tvrage_id", "type", "video", "videos"
            ]);

            configuration.Images.ShouldNotBeNull();

            configuration.Images!.BaseUrl.ShouldBe("http://image.tmdb.org/t/p/");
            configuration.Images!.SecureBaseUrl.ShouldBe("https://image.tmdb.org/t/p/");

            configuration.Images!.BackdropSizes.ShouldNotBeNull();
            configuration.Images!.BackdropSizes!.Count.ShouldBe(4);

            configuration.Images!.BackdropSizes![0].ShouldBe(TMDBBackdropSize.Width300);
            configuration.Images!.BackdropSizes![1].ShouldBe(TMDBBackdropSize.Width780);
            configuration.Images!.BackdropSizes![2].ShouldBe(TMDBBackdropSize.Width1280);
            configuration.Images!.BackdropSizes![3].ShouldBe(TMDBBackdropSize.Original);

            configuration.Images!.LogoSizes.ShouldNotBeNull();
            configuration.Images!.LogoSizes!.Count.ShouldBe(7);

            configuration.Images!.LogoSizes![0].ShouldBe(TMDBLogoSize.Width45);
            configuration.Images!.LogoSizes![1].ShouldBe(TMDBLogoSize.Width92);
            configuration.Images!.LogoSizes![2].ShouldBe(TMDBLogoSize.Width154);
            configuration.Images!.LogoSizes![3].ShouldBe(TMDBLogoSize.Width185);
            configuration.Images!.LogoSizes![4].ShouldBe(TMDBLogoSize.Width300);
            configuration.Images!.LogoSizes![5].ShouldBe(TMDBLogoSize.Width500);
            configuration.Images!.LogoSizes![6].ShouldBe(TMDBLogoSize.Original);

            configuration.Images!.PosterSizes.ShouldNotBeNull();
            configuration.Images!.PosterSizes!.Count.ShouldBe(7);

            configuration.Images!.PosterSizes![0].ShouldBe(TMDBPosterSize.Width92);
            configuration.Images!.PosterSizes![1].ShouldBe(TMDBPosterSize.Width154);
            configuration.Images!.PosterSizes![2].ShouldBe(TMDBPosterSize.Width185);
            configuration.Images!.PosterSizes![3].ShouldBe(TMDBPosterSize.Width342);
            configuration.Images!.PosterSizes![4].ShouldBe(TMDBPosterSize.Width500);
            configuration.Images!.PosterSizes![5].ShouldBe(TMDBPosterSize.Width780);
            configuration.Images!.PosterSizes![6].ShouldBe(TMDBPosterSize.Original);

            configuration.Images!.ProfileSizes.ShouldNotBeNull();
            configuration.Images!.ProfileSizes!.Count.ShouldBe(4);

            configuration.Images!.ProfileSizes![0].ShouldBe(TMDBProfileSize.Width45);
            configuration.Images!.ProfileSizes![1].ShouldBe(TMDBProfileSize.Width185);
            configuration.Images!.ProfileSizes![2].ShouldBe(TMDBProfileSize.Height632);
            configuration.Images!.ProfileSizes![3].ShouldBe(TMDBProfileSize.Original);

            configuration.Images!.StillSizes.ShouldNotBeNull();
            configuration.Images!.StillSizes!.Count.ShouldBe(4);

            configuration.Images!.StillSizes![0].ShouldBe(TMDBStillSize.Width92);
            configuration.Images!.StillSizes![1].ShouldBe(TMDBStillSize.Width185);
            configuration.Images!.StillSizes![2].ShouldBe(TMDBStillSize.Width300);
            configuration.Images!.StillSizes![3].ShouldBe(TMDBStillSize.Original);
        }
    }
}
