namespace TraktNET.Json.Users
{
    public sealed class TraktUserIdsTests
    {
        [Fact]
        public void TestTraktUserIdsConstructor()
        {
            var userIds = new TraktUserIds();

            userIds.Slug.Should().BeNull();
            userIds.UUID.Should().BeNull();

            userIds.HasAnyID.Should().BeFalse();
            userIds.BestID.Should().BeEmpty();
        }

        [Fact]
        public async Task TestTraktUserIdsFromJson()
        {
            TraktUserIds? userIds = await TestUtility.DeserializeJsonAsync<TraktUserIds>("Users\\userids.json");

            userIds.Should().NotBeNull();

            userIds!.Slug.Should().Be("ixxus");
            userIds!.UUID.Should().Be("jljgsagj092ß9u0294jlgalngoi0t0qntggnafng82");

            userIds!.HasAnyID.Should().BeTrue();
            userIds!.BestID.Should().Be("ixxus");
        }
    }
}
