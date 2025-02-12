namespace TraktNET.Json.People
{
    public sealed class TraktPersonSocialIDsTests
    {
        [Fact]
        public void TestTraktPersonSocialIDsConstructor()
        {
            var personSocialIDs = new TraktPersonSocialIDs();

            personSocialIDs.Twitter.ShouldBeNull();
            personSocialIDs.Facebook.ShouldBeNull();
            personSocialIDs.Instagram.ShouldBeNull();
            personSocialIDs.Wikipedia.ShouldBeNull();
        }

        [Fact]
        public async Task TestTraktPersonSocialIDsFromJson()
        {
            TraktPersonSocialIDs? personSocialIDs = await TraktTestUtility.DeserializeJsonAsync<TraktPersonSocialIDs>("People\\personsocialids.json");

            personSocialIDs.ShouldNotBeNull();

            personSocialIDs!.Twitter.ShouldBe("BryanCranston");
            personSocialIDs!.Facebook.ShouldBe("thebryancranston");
            personSocialIDs!.Instagram.ShouldBe("bryancranston");
            personSocialIDs!.Wikipedia.ShouldBe("test-data");
        }
    }
}
