namespace TraktApiSharp.Tests.Objects.Get.Users.Json
{
    using FluentAssertions;
    using System.IO;
    using System.Threading.Tasks;
    using TestUtils;
    using Traits;
    using TraktApiSharp.Objects.Get.Users.Json;
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
