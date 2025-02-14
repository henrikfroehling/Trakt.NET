namespace TraktNET.Json
{
    public sealed class TMDBVideoTests
    {
        [Fact]
        public void TestTMDBVideoConstructor()
        {
            var video = new TMDBVideo();

            video.Name.ShouldBeNull();
            video.Site.ShouldBeNull();
            video.Id.ShouldBeNull();
            video.Key.ShouldBeNull();
            video.Official.ShouldBeNull();
            video.Type.ShouldBeNull();
            video.Size.ShouldBeNull();
            video.PublishedAt.ShouldBeNull();
            video.ISO6391.ShouldBeNull();
            video.ISO31661.ShouldBeNull();
        }

        [Fact]
        public async Task TestTMDBVideoFromJson()
        {
            TMDBVideo? video = await TMDBTestUtility.DeserializeJsonAsync<TMDBVideo>("video.json");

            video.ShouldNotBeNull();

            video!.Name.ShouldBe("Rolling Boulder Chase Scene");
            video!.Site.ShouldBe("YouTube");
            video!.Id.ShouldBe("649a4b90a6ddcb00ae67a724");
            video!.Key.ShouldBe("8bYvCSfd72A");
            video!.Official.ShouldBe(true);
            video!.Type.ShouldBe(TMDBVideoType.Clip);
            video!.Size.ShouldBe(1080U);
            video!.PublishedAt.ShouldBe(TestUtility.ParseUTCDateTime("2023-06-25T16:00:05.000Z"));
            video!.ISO6391.ShouldBe("en");
            video!.ISO31661.ShouldBe("US");
        }
    }
}
