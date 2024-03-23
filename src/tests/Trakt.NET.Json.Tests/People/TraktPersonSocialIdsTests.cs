namespace TraktNET.Json.People
{
    public sealed class TraktPersonSocialIdsTests
    {
        [Fact]
        public void TestTraktPersonSocialIdsConstructor()
        {
            var personSocialIds = new TraktPersonSocialIds();

            personSocialIds.Twitter.Should().BeNull();
            personSocialIds.Facebook.Should().BeNull();
            personSocialIds.Instagram.Should().BeNull();
            personSocialIds.Wikipedia.Should().BeNull();
        }

        [Fact]
        public async Task TestTraktPersonSocialIdsFromJson()
        {
            TraktPersonSocialIds? personSocialIds = await TestUtility.DeserializeJsonAsync<TraktPersonSocialIds>("People\\personsocialids.json");

            personSocialIds.Should().NotBeNull();

            personSocialIds!.Twitter.Should().Be("BryanCranston");
            personSocialIds!.Facebook.Should().Be("thebryancranston");
            personSocialIds!.Instagram.Should().Be("bryancranston");
            personSocialIds!.Wikipedia.Should().Be("test-data");
        }
    }
}
