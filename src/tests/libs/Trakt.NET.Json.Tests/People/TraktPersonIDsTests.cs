namespace TraktNET.Json.People
{
    public sealed class TraktPersonIDsTests
    {
        [Fact]
        public void TestTraktPersonIDsConstructor()
        {
            var personIDs = new TraktPersonIDs();

            personIDs.Trakt.ShouldBeNull();
            personIDs.Slug.ShouldBeNull();
            personIDs.IMDB.ShouldBeNull();
            personIDs.TMDB.ShouldBeNull();

            personIDs.HasAnyID.ShouldBe(false);
            personIDs.BestID.ShouldBeEmpty();
        }

        [Fact]
        public async Task TestTraktPersonIDsFromJson()
        {
            TraktPersonIDs? personIDs = await TraktTestUtility.DeserializeJsonAsync<TraktPersonIDs>("People\\personids.json");

            personIDs.ShouldNotBeNull();

            personIDs!.Trakt.ShouldBe(297737U);
            personIDs!.Slug.ShouldBe("bryan-cranston");
            personIDs!.IMDB.ShouldBe("nm0186505");
            personIDs!.TMDB.ShouldBe(17419U);

            personIDs!.HasAnyID.ShouldBe(true);
            personIDs!.BestID.ShouldBe("bryan-cranston");
        }
    }
}
