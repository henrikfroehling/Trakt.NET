namespace TraktNET.Json.Seasons
{
    public sealed class TraktSeasonIDsTests
    {
        [Fact]
        public void TestTraktSeasonIDsConstructor()
        {
            var seasonIDs = new TraktSeasonIDs();

            seasonIDs.Trakt.ShouldBeNull();
            seasonIDs.TVDB.ShouldBeNull();
            seasonIDs.TMDB.ShouldBeNull();

            seasonIDs.HasAnyID.ShouldBe(false);
            seasonIDs.BestID.ShouldBeEmpty();
        }

        [Fact]
        public async Task TestTraktSeasonIDsFromJson()
        {
            TraktSeasonIDs? seasonIDs = await TraktTestUtility.DeserializeJsonAsync<TraktSeasonIDs>("Seasons\\seasonids.json");

            seasonIDs.ShouldNotBeNull();

            seasonIDs!.Trakt.ShouldBe(3963U);
            seasonIDs!.TVDB.ShouldBe(364731U);
            seasonIDs!.TMDB.ShouldBe(3624U);

            seasonIDs!.HasAnyID.ShouldBe(true);
            seasonIDs!.BestID.ShouldBe("3963");
        }
    }
}
