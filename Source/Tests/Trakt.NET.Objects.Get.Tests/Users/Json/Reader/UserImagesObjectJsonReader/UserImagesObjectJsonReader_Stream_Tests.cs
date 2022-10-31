namespace TraktNet.Objects.Get.Tests.Users.Json.Reader
{
    using FluentAssertions;
    using System;
    using System.IO;
    using System.Threading.Tasks;
    using Trakt.NET.Tests.Utility;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Objects.Get.Users;
    using TraktNet.Objects.Get.Users.Json.Reader;
    using Xunit;

    [TestCategory("Objects.Get.Users.JsonReader")]
    public partial class UserImagesObjectJsonReader_Tests
    {
        [Fact]
        public async Task Test_UserImagesObjectJsonReader_ReadObject_From_Stream_Complete()
        {
            var jsonReader = new UserImagesObjectJsonReader();

            using (var stream =  JSON_COMPLETE.ToStream())
            {
                var userImages = await jsonReader.ReadObjectAsync(stream);

                userImages.Should().NotBeNull();
                userImages.Avatar.Should().NotBeNull();
                userImages.Avatar.Full.Should().Be("https://walter.trakt.us/images/users/000/359/474/avatars/large/58cc281a20.gif");
            }
        }

        [Fact]
        public async Task Test_UserImagesObjectJsonReader_ReadObject_From_Stream_Not_Valid()
        {
            var jsonReader = new UserImagesObjectJsonReader();

            using (var stream =  JSON_NOT_VALID.ToStream())
            {
                var userImages = await jsonReader.ReadObjectAsync(stream);

                userImages.Should().NotBeNull();
                userImages.Avatar.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_UserImagesObjectJsonReader_ReadObject_From_Stream_Null()
        {
            var jsonReader = new UserImagesObjectJsonReader();
            Func<Task<ITraktUserImages>> userImages = () => jsonReader.ReadObjectAsync(default(Stream));
            await userImages.Should().ThrowAsync<ArgumentNullException>();
        }

        [Fact]
        public async Task Test_UserImagesObjectJsonReader_ReadObject_From_Stream_Empty()
        {
            var jsonReader = new UserImagesObjectJsonReader();

            using (var stream = string.Empty.ToStream())
            {
                var userImages = await jsonReader.ReadObjectAsync(stream);
                userImages.Should().BeNull();
            }
        }
    }
}
