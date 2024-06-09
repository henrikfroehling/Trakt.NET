namespace TraktNET.Json.Users
{
    public sealed class TraktUserImagesTests
    {
        [Fact]
        public void TestTraktUserImagesConstructor()
        {
            var userImages = new TraktUserImages();

            userImages.Avatar.Should().BeNull();
        }

        [Fact]
        public async Task TestTraktUserImagesFromJson()
        {
            TraktUserImages? userImages = await TestUtility.DeserializeJsonAsync<TraktUserImages>("Users\\userimages.json");

            userImages.Should().NotBeNull();

            userImages!.Avatar.Should().NotBeNull();
            userImages!.Avatar!.Full.Should().Be("https://walter.trakt.tv/images/users/000/894/246/avatars/large/754b7e3761.png");
        }
    }
}
