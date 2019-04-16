namespace TraktNet.Objects.Tests.Get.Users.Json.Reader
{
    using FluentAssertions;
    using System.Threading.Tasks;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Objects.Get.Users.Json.Reader;
    using Xunit;

    [Category("Objects.Get.Users.JsonReader")]
    public partial class UserImagesObjectJsonReader_Tests
    {
        [Fact]
        public async Task Test_UserImagesObjectJsonReader_ReadObject_From_Json_String_Complete()
        {
            var jsonReader = new UserImagesObjectJsonReader();

            var userImages = await jsonReader.ReadObjectAsync(JSON_COMPLETE);

            userImages.Should().NotBeNull();
            userImages.Avatar.Should().NotBeNull();
            userImages.Avatar.Full.Should().Be("https://walter.trakt.us/images/users/000/359/474/avatars/large/58cc281a20.gif");
        }

        [Fact]
        public async Task Test_UserImagesObjectJsonReader_ReadObject_From_Json_String_Not_Valid()
        {
            var jsonReader = new UserImagesObjectJsonReader();

            var userImages = await jsonReader.ReadObjectAsync(JSON_NOT_VALID);

            userImages.Should().NotBeNull();
            userImages.Avatar.Should().BeNull();
        }

        [Fact]
        public async Task Test_UserImagesObjectJsonReader_ReadObject_From_Json_String_Null()
        {
            var jsonReader = new UserImagesObjectJsonReader();

            var userImages = await jsonReader.ReadObjectAsync(default(string));
            userImages.Should().BeNull();
        }

        [Fact]
        public async Task Test_UserImagesObjectJsonReader_ReadObject_From_Json_String_Empty()
        {
            var jsonReader = new UserImagesObjectJsonReader();

            var userImages = await jsonReader.ReadObjectAsync(string.Empty);
            userImages.Should().BeNull();
        }
    }
}
