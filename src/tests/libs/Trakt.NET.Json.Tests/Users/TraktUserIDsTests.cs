namespace TraktNET.Json.Users
{
    public sealed class TraktUserIDsTests
    {
        [Fact]
        public void TestTraktUserIDsConstructor()
        {
            var userIDs = new TraktUserIDs();

            userIDs.Slug.ShouldBeNull();
            userIDs.UUID.ShouldBeNull();

            userIDs.HasAnyID.ShouldBe(false);
            userIDs.BestID.ShouldBeEmpty();
        }

        [Fact]
        public async Task TestTraktUserIDsFromJson()
        {
            TraktUserIDs? userIDs = await TraktTestUtility.DeserializeJsonAsync<TraktUserIDs>("Users\\userids.json");

            userIDs.ShouldNotBeNull();

            userIDs!.Slug.ShouldBe("ixxus");
            userIDs!.UUID.ShouldBe("jljgsagj092ß9u0294jlgalngoi0t0qntggnafng82");

            userIDs!.HasAnyID.ShouldBe(true);
            userIDs!.BestID.ShouldBe("ixxus");
        }
    }
}
