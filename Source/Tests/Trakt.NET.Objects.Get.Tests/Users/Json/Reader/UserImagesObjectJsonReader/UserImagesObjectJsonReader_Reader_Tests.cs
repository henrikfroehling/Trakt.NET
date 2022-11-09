namespace TraktNet.Objects.Get.Tests.Users.Json.Reader
{
    using FluentAssertions;
    using Newtonsoft.Json;
    using System;
    using System.IO;
    using System.Threading.Tasks;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Objects.Get.Users;
    using TraktNet.Objects.Get.Users.Json.Reader;
    using Xunit;

    [TestCategory("Objects.Get.Users.JsonReader")]
    public partial class UserImagesObjectJsonReader_Tests
    {
        [Fact]
        public async Task Test_UserImagesObjectJsonReader_ReadObject_From_JsonReader_Complete()
        {
            var traktJsonReader = new UserImagesObjectJsonReader();

            using (var reader = new StringReader(JSON_COMPLETE))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var userImages = await traktJsonReader.ReadObjectAsync(jsonReader);

                userImages.Should().NotBeNull();
                userImages.Avatar.Should().NotBeNull();
                userImages.Avatar.Full.Should().Be("https://walter.trakt.us/images/users/000/359/474/avatars/large/58cc281a20.gif");
            }
        }

        [Fact]
        public async Task Test_UserImagesObjectJsonReader_ReadObject_From_JsonReader_Not_Valid()
        {
            var traktJsonReader = new UserImagesObjectJsonReader();

            using (var reader = new StringReader(JSON_NOT_VALID))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var userImages = await traktJsonReader.ReadObjectAsync(jsonReader);

                userImages.Should().NotBeNull();
                userImages.Avatar.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_UserImagesObjectJsonReader_ReadObject_From_JsonReader_Null()
        {
            var traktJsonReader = new UserImagesObjectJsonReader();
            Func<Task<ITraktUserImages>> userImages = () => traktJsonReader.ReadObjectAsync(default(JsonTextReader));
            await userImages.Should().ThrowAsync<ArgumentNullException>();
        }

        [Fact]
        public async Task Test_UserImagesObjectJsonReader_ReadObject_From_JsonReader_Empty()
        {
            var traktJsonReader = new UserImagesObjectJsonReader();

            using (var reader = new StringReader(string.Empty))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var userImages = await traktJsonReader.ReadObjectAsync(jsonReader);
                userImages.Should().BeNull();
            }
        }
    }
}
