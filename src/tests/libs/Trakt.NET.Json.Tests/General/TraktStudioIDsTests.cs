namespace TraktNET.Json.General
{
    public sealed class TraktStudioIDsTests
    {
        [Fact]
        public void TestTraktStudioIDsConstructor()
        {
            var studioIDs = new TraktStudioIDs();

            studioIDs.Trakt.ShouldBeNull();
            studioIDs.Slug.ShouldBeNull();
            studioIDs.TMDB.ShouldBeNull();

            studioIDs.HasAnyID.ShouldBe(false);
            studioIDs.BestID.ShouldBeEmpty();
        }

        [Fact]
        public async Task TestTraktStudioIDsFromJson()
        {
            TraktStudioIDs? studioIDs = await TraktTestUtility.DeserializeJsonAsync<TraktStudioIDs>("General\\studioids.json");

            studioIDs.ShouldNotBeNull();

            studioIDs!.Trakt.ShouldBe(181U);
            studioIDs!.Slug.ShouldBe("marvel-studios");
            studioIDs!.TMDB.ShouldBe(420U);

            studioIDs!.HasAnyID.ShouldBe(true);
            studioIDs!.BestID.ShouldBe("marvel-studios");
        }
    }
}
