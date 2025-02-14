namespace TraktNET.Json
{
    public sealed class TMDBVideosTests
    {
        [Fact]
        public void TestTMDBVideosConstructor()
        {
            var videos = new TMDBVideos();

            videos.Id.ShouldBeNull();
            videos.Results.ShouldBeNull();
        }

        [Fact]
        public async Task TestTMDBVideosFromJson()
        {
            TMDBVideos? videos = await TMDBTestUtility.DeserializeJsonAsync<TMDBVideos>("videos.json");

            videos.ShouldNotBeNull();

            videos!.Id.ShouldBe(85U);
            videos!.Results.ShouldNotBeNull();
            videos!.Results!.Count.ShouldBe(2);

            videos!.Results[0].ShouldNotBeNull();

            videos!.Results[0]!.Name.ShouldBe("Rolling Boulder Chase Scene");
            videos!.Results[0]!.Site.ShouldBe("YouTube");
            videos!.Results[0]!.Id.ShouldBe("649a4b90a6ddcb00ae67a724");
            videos!.Results[0]!.Key.ShouldBe("8bYvCSfd72A");
            videos!.Results[0]!.Official.ShouldBe(true);
            videos!.Results[0]!.Type.ShouldBe(TMDBVideoType.Clip);
            videos!.Results[0]!.Size.ShouldBe(1080U);
            videos!.Results[0]!.PublishedAt.ShouldBe(TestUtility.ParseUTCDateTime("2023-06-25T16:00:05.000Z"));
            videos!.Results[0]!.ISO6391.ShouldBe("en");
            videos!.Results[0]!.ISO31661.ShouldBe("US");

            videos!.Results[1].ShouldNotBeNull();

            videos!.Results[1]!.Name.ShouldBe("Fathom Events Spot");
            videos!.Results[1]!.Site.ShouldBe("YouTube");
            videos!.Results[1]!.Id.ShouldBe("645798c76aa8e001737f9fea");
            videos!.Results[1]!.Key.ShouldBe("w9YcGbOupgw");
            videos!.Results[1]!.Official.ShouldBe(true);
            videos!.Results[1]!.Type.ShouldBe(TMDBVideoType.Teaser);
            videos!.Results[1]!.Size.ShouldBe(1080U);
            videos!.Results[1]!.PublishedAt.ShouldBe(TestUtility.ParseUTCDateTime("2023-05-05T06:00:17.000Z"));
            videos!.Results[1]!.ISO6391.ShouldBe("en");
            videos!.Results[1]!.ISO31661.ShouldBe("US");
        }
    }
}
