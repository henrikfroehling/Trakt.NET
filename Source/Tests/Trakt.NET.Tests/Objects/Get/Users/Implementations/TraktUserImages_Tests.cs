namespace TraktNet.Tests.Objects.Get.Users.Implementations
{
    using FluentAssertions;
    using System.Threading.Tasks;
    using Traits;
    using TraktNet.Objects.Get.Users;
    using TraktNet.Objects.Get.Users.Json.Reader;
    using Xunit;

    [Category("Objects.Get.Users.Implementations")]
    public class TraktUserImages_Tests
    {
        [Fact]
        public void Test_TraktUserImages_Default_Constructor()
        {
            var userImages = new TraktUserImages();

            userImages.Avatar.Should().BeNull();
        }

        [Fact]
        public async Task Test_TraktUserImages_From_Json()
        {
            var jsonReader = new UserImagesObjectJsonReader();
            var userImages = await jsonReader.ReadObjectAsync(JSON) as TraktUserImages;

            userImages.Should().NotBeNull();
            userImages.Avatar.Should().NotBeNull();
            userImages.Avatar.Full.Should().Be("https://walter.trakt.us/images/users/000/359/474/avatars/large/58cc281a20.gif");
        }

        private const string JSON =
            @"{
                ""avatar"": {
                  ""full"": ""https://walter.trakt.us/images/users/000/359/474/avatars/large/58cc281a20.gif""
                }
              }";
    }
}
