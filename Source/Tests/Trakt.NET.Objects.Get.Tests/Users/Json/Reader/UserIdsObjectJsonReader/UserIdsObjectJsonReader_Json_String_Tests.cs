namespace TraktNet.Objects.Get.Tests.Users.Json.Reader
{
    using FluentAssertions;
    using System;
    using System.Threading.Tasks;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Objects.Get.Users;
    using TraktNet.Objects.Get.Users.Json.Reader;
    using Xunit;

    [Category("Objects.Get.Users.JsonReader")]
    public partial class UserIdsObjectJsonReader_Tests
    {
        [Fact]
        public async Task Test_UserIdsObjectJsonReader_ReadObject_From_Json_String_Complete()
        {
            var jsonReader = new UserIdsObjectJsonReader();

            var userIds = await jsonReader.ReadObjectAsync(JSON_COMPLETE);

            userIds.Should().NotBeNull();
            userIds.Slug.Should().Be("sean");
            userIds.UUID.Should().Be("b6589fc6ab0dc82cf12099d1c2d40ab994e8410c");
        }

        [Fact]
        public async Task Test_UserIdsObjectJsonReader_ReadObject_From_Json_String_Not_Valid()
        {
            var jsonReader = new UserIdsObjectJsonReader();

            var userIds = await jsonReader.ReadObjectAsync(JSON_NOT_VALID);

            userIds.Should().NotBeNull();
            userIds.Slug.Should().BeNull();
            userIds.UUID.Should().BeNull();
        }

        [Fact]
        public async Task Test_UserIdsObjectJsonReader_ReadObject_From_Json_String_Null()
        {
            var jsonReader = new UserIdsObjectJsonReader();
            Func<Task<ITraktUserIds>> userIds = () => jsonReader.ReadObjectAsync(default(string));
            await userIds.Should().ThrowAsync<ArgumentNullException>();
        }

        [Fact]
        public async Task Test_UserIdsObjectJsonReader_ReadObject_From_Json_String_Empty()
        {
            var jsonReader = new UserIdsObjectJsonReader();

            var userIds = await jsonReader.ReadObjectAsync(string.Empty);
            userIds.Should().BeNull();
        }
    }
}
