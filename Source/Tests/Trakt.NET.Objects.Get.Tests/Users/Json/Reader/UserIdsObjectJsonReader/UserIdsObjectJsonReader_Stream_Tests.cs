namespace TraktNet.Objects.Get.Tests.Users.Json.Reader
{
    using FluentAssertions;
    using System.IO;
    using System.Threading.Tasks;
    using Trakt.NET.Tests.Utility;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Objects.Get.Users.Json.Reader;
    using Xunit;

    [Category("Objects.Get.Users.JsonReader")]
    public partial class UserIdsObjectJsonReader_Tests
    {
        [Fact]
        public async Task Test_UserIdsObjectJsonReader_ReadObject_From_Stream_Complete()
        {
            var jsonReader = new UserIdsObjectJsonReader();

            using (var stream = JSON_COMPLETE.ToStream())
            {
                var userIds = await jsonReader.ReadObjectAsync(stream);

                userIds.Should().NotBeNull();
                userIds.Slug.Should().Be("sean");
                userIds.UUID.Should().Be("b6589fc6ab0dc82cf12099d1c2d40ab994e8410c");
            }
        }

        [Fact]
        public async Task Test_UserIdsObjectJsonReader_ReadObject_From_Stream_Not_Valid()
        {
            var jsonReader = new UserIdsObjectJsonReader();

            using (var stream = JSON_NOT_VALID.ToStream())
            {
                var userIds = await jsonReader.ReadObjectAsync(stream);

                userIds.Should().NotBeNull();
                userIds.Slug.Should().BeNull();
                userIds.UUID.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_UserIdsObjectJsonReader_ReadObject_From_Stream_Null()
        {
            var jsonReader = new UserIdsObjectJsonReader();

            var userIds = await jsonReader.ReadObjectAsync(default(Stream));
            userIds.Should().BeNull();
        }

        [Fact]
        public async Task Test_UserIdsObjectJsonReader_ReadObject_From_Stream_Empty()
        {
            var jsonReader = new UserIdsObjectJsonReader();

            using (var stream = string.Empty.ToStream())
            {
                var userIds = await jsonReader.ReadObjectAsync(stream);
                userIds.Should().BeNull();
            }
        }
    }
}
