namespace TraktNET.Json.Shows
{
    public sealed class TraktShowIDsTests
    {
        [Fact]
        public void TestTraktShowIDsConstructor()
        {
            var showIDs = new TraktShowIDs();

            showIDs.Trakt.ShouldBeNull();
            showIDs.Slug.ShouldBeNull();
            showIDs.TVDB.ShouldBeNull();
            showIDs.IMDB.ShouldBeNull();
            showIDs.TMDB.ShouldBeNull();

            showIDs.HasAnyID.ShouldBe(false);
            showIDs.BestID.ShouldBeEmpty();
        }

        [Fact]
        public async Task TestTraktShowIDsFromJson()
        {
            TraktShowIDs? showIDs = await TraktTestUtility.DeserializeJsonAsync<TraktShowIDs>("Shows\\showids.json");

            showIDs.ShouldNotBeNull();

            showIDs!.Trakt.ShouldBe(1390U);
            showIDs!.Slug.ShouldBe("game-of-thrones");
            showIDs!.TVDB.ShouldBe(121361U);
            showIDs!.IMDB.ShouldBe("tt0944947");
            showIDs!.TMDB.ShouldBe(1399U);

            showIDs!.HasAnyID.ShouldBe(true);
            showIDs!.BestID.ShouldBe("game-of-thrones");
        }
    }
}
