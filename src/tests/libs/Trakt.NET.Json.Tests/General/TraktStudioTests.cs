namespace TraktNET.Json.General
{
    public sealed class TraktStudioTests
    {
        [Fact]
        public void TestTraktStudioConstructor()
        {
            var studio = new TraktStudio();

            studio.Name.ShouldBeNull();
            studio.Country.ShouldBeNull();
            studio.IDs.ShouldBeNull();
        }

        [Fact]
        public async Task TestTraktStudioFromJson()
        {
            TraktStudio? studio = await TraktTestUtility.DeserializeJsonAsync<TraktStudio>("General\\studio.json");

            studio.ShouldNotBeNull();

            studio!.Name.ShouldBe("Marvel Studios");
            studio!.Country.ShouldBe("us");

            studio!.IDs!.Trakt.ShouldBe(181U);
            studio!.IDs!.Slug.ShouldBe("marvel-studios");
            studio!.IDs!.TMDB.ShouldBe(420U);
            studio!.IDs!.HasAnyID.ShouldBe(true);
            studio!.IDs!.BestID.ShouldBe("marvel-studios");
        }
    }
}
