namespace TraktNET.Json.Users
{
    public sealed class TraktUserImagesTests
    {
        [Fact]
        public void TestTraktUserImagesConstructor()
        {
            var userImages = new TraktUserImages();

            userImages.Avatar.ShouldBeNull();
        }

        [Fact]
        public async Task TestTraktUserImagesFromJson()
        {
            TraktUserImages? userImages = await TraktTestUtility.DeserializeJsonAsync<TraktUserImages>("Users\\userimages.json");

            userImages.ShouldNotBeNull();

            userImages!.Avatar.ShouldNotBeNull();
            userImages!.Avatar!.Full.ShouldBe("https://walter.trakt.tv/images/users/000/894/246/avatars/large/754b7e3761.png");
        }
    }
}
