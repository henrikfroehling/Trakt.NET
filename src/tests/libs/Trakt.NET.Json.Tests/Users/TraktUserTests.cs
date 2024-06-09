namespace TraktNET.Json.Users
{
    public sealed class TraktUserTests
    {
        [Fact]
        public void TestTraktUserConstructor()
        {
            var user = new TraktUser();

            user.Username.Should().BeNull();
            user.Private.Should().BeNull();
            user.Name.Should().BeNull();
            user.VIP.Should().BeNull();
            user.VIPEP.Should().BeNull();
            user.Ids.Should().BeNull();
            user.JoinedAt.Should().BeNull();
            user.Location.Should().BeNull();
            user.About.Should().BeNull();
            user.Gender.Should().BeNull();
            user.Age.Should().BeNull();
            user.Images.Should().BeNull();
            user.VIPOG.Should().BeNull();
            user.VIPYears.Should().BeNull();
            user.VIPCoverImage.Should().BeNull();
        }

        [Fact]
        public async Task TestTraktUserFromJsonMinimal()
        {
            TraktUserMinimal? user = await TestUtility.DeserializeJsonAsync<TraktUserMinimal>("Users\\user_minimal.json");

            user.Should().NotBeNull();

            user!.Username.Should().Be("ixxus");
            user!.Private.Should().BeFalse();
            user!.Name.Should().Be("Henrik");
            user!.VIP.Should().BeTrue();
            user!.VIPEP.Should().BeFalse();

            user!.Ids.Should().NotBeNull();
            user!.Ids!.Slug.Should().Be("ixxus");
            user!.Ids!.UUID.Should().Be("jljgsagj092ß9u0294jlgalngoi0t0qntggnafng82");
            user!.Ids!.HasAnyID.Should().BeTrue();
            user!.Ids!.BestID.Should().Be("ixxus");
        }

        [Fact]
        public async Task TestTraktUserFromJson()
        {
            TraktUser? user = await TestUtility.DeserializeJsonAsync<TraktUser>("Users\\user.json");

            user.Should().NotBeNull();

            user!.Username.Should().Be("ixxus");
            user!.Private.Should().BeFalse();
            user!.Name.Should().Be("Henrik");
            user!.VIP.Should().BeTrue();
            user!.VIPEP.Should().BeFalse();

            user!.Ids.Should().NotBeNull();
            user!.Ids!.Slug.Should().Be("ixxus");
            user!.Ids!.UUID.Should().Be("jljgsagj092ß9u0294jlgalngoi0t0qntggnafng82");
            user!.Ids!.HasAnyID.Should().BeTrue();
            user!.Ids!.BestID.Should().Be("ixxus");

            user!.JoinedAt.Should().Be(TestUtility.ParseUTCDateTime("2015-02-18T12:54:39.000Z"));
            user!.Location.Should().Be("Germany");
            user!.About.Should().BeEmpty();
            user!.Gender.Should().Be(TraktGender.Male);
            user!.Age.Should().Be(36U);

            user!.Images.Should().NotBeNull();
            user!.Images!.Avatar.Should().NotBeNull();
            user!.Images!.Avatar!.Full.Should().Be("https://walter.trakt.tv/images/users/000/894/246/avatars/large/754b7e3761.png");

            user!.VIPOG.Should().BeFalse();
            user!.VIPYears.Should().Be(6U);
            user!.VIPCoverImage.Should().Be("https://walter.trakt.tv/images/shows/000/043/973/fanarts/full/eb3a126015.jpg");
        }
    }
}
