namespace TraktNET.Json.Users
{
    public sealed class TraktUserTests
    {
        [Fact]
        public void TestTraktUserConstructor()
        {
            var user = new TraktUser();

            user.Username.ShouldBeNull();
            user.Private.ShouldBeNull();
            user.Name.ShouldBeNull();
            user.VIP.ShouldBeNull();
            user.VIPEP.ShouldBeNull();
            user.IDs.ShouldBeNull();
            user.JoinedAt.ShouldBeNull();
            user.Location.ShouldBeNull();
            user.About.ShouldBeNull();
            user.Gender.ShouldBeNull();
            user.Age.ShouldBeNull();
            user.Images.ShouldBeNull();
            user.VIPOG.ShouldBeNull();
            user.VIPYears.ShouldBeNull();
            user.VIPCoverImage.ShouldBeNull();
        }

        [Fact]
        public async Task TestTraktUserFromJsonMinimal()
        {
            TraktUserMinimal? user = await TraktTestUtility.DeserializeJsonAsync<TraktUserMinimal>("Users\\user_minimal.json");

            user.ShouldNotBeNull();

            user!.Username.ShouldBe("ixxus");
            user!.Private.ShouldBe(false);
            user!.Name.ShouldBe("Henrik");
            user!.VIP.ShouldBe(true);
            user!.VIPEP.ShouldBe(false);

            user!.IDs.ShouldNotBeNull();
            user!.IDs!.Slug.ShouldBe("ixxus");
            user!.IDs!.UUID.ShouldBe("jljgsagj092ß9u0294jlgalngoi0t0qntggnafng82");
            user!.IDs!.HasAnyID.ShouldBe(true);
            user!.IDs!.BestID.ShouldBe("ixxus");
        }

        [Fact]
        public async Task TestTraktUserFromJson()
        {
            TraktUser? user = await TraktTestUtility.DeserializeJsonAsync<TraktUser>("Users\\user.json");

            user.ShouldNotBeNull();

            user!.Username.ShouldBe("ixxus");
            user!.Private.ShouldBe(false);
            user!.Name.ShouldBe("Henrik");
            user!.VIP.ShouldBe(true);
            user!.VIPEP.ShouldBe(false);

            user!.IDs.ShouldNotBeNull();
            user!.IDs!.Slug.ShouldBe("ixxus");
            user!.IDs!.UUID.ShouldBe("jljgsagj092ß9u0294jlgalngoi0t0qntggnafng82");
            user!.IDs!.HasAnyID.ShouldBe(true);
            user!.IDs!.BestID.ShouldBe("ixxus");

            user!.JoinedAt.ShouldBe(TestUtility.ParseUTCDateTime("2015-02-18T12:54:39.000Z"));
            user!.Location.ShouldBe("Germany");
            user!.About.ShouldBeEmpty();
            user!.Gender.ShouldBe(TraktGender.Male);
            user!.Age.ShouldBe(36U);

            user!.Images.ShouldNotBeNull();
            user!.Images!.Avatar.ShouldNotBeNull();
            user!.Images!.Avatar!.Full.ShouldBe("https://walter.trakt.tv/images/users/000/894/246/avatars/large/754b7e3761.png");

            user!.VIPOG.ShouldBe(false);
            user!.VIPYears.ShouldBe(6U);
            user!.VIPCoverImage.ShouldBe("https://walter.trakt.tv/images/shows/000/043/973/fanarts/full/eb3a126015.jpg");
        }
    }
}
