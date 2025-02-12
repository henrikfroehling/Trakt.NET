namespace TraktNET.Json.Lists
{
    public sealed class TraktListIDsTests
    {
        [Fact]
        public void TestTraktListIDsConstructor()
        {
            var listIDs = new TraktListIDs();

            listIDs.Trakt.ShouldBeNull();
            listIDs.Slug.ShouldBeNull();

            listIDs.HasAnyID.ShouldBe(false);
            listIDs.BestID.ShouldBeEmpty();
        }

        [Fact]
        public async Task TestTraktListIDsFromJson()
        {
            TraktListIDs? listIDs = await TraktTestUtility.DeserializeJsonAsync<TraktListIDs>("Lists\\listids.json");

            listIDs.ShouldNotBeNull();

            listIDs!.Trakt.ShouldBe(1248149U);
            listIDs!.Slug.ShouldBe("marvel-cinematic-universe");

            listIDs!.HasAnyID.ShouldBe(true);
            listIDs!.BestID.ShouldBe("marvel-cinematic-universe");
        }
    }
}
