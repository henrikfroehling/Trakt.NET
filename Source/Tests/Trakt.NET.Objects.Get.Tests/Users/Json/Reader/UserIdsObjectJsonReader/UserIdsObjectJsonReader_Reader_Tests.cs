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
    public partial class UserIdsObjectJsonReader_Tests
    {
        [Fact]
        public async Task Test_UserIdsObjectJsonReader_ReadObject_From_JsonReader_Complete()
        {
            var traktJsonReader = new UserIdsObjectJsonReader();

            using (var reader = new StringReader(JSON_COMPLETE))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var userIds = await traktJsonReader.ReadObjectAsync(jsonReader);

                userIds.Should().NotBeNull();
                userIds.Slug.Should().Be("sean");
                userIds.UUID.Should().Be("b6589fc6ab0dc82cf12099d1c2d40ab994e8410c");
            }
        }

        [Fact]
        public async Task Test_UserIdsObjectJsonReader_ReadObject_From_JsonReader_Not_Valid()
        {
            var traktJsonReader = new UserIdsObjectJsonReader();

            using (var reader = new StringReader(JSON_NOT_VALID))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var userIds = await traktJsonReader.ReadObjectAsync(jsonReader);

                userIds.Should().NotBeNull();
                userIds.Slug.Should().BeNull();
                userIds.UUID.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_UserIdsObjectJsonReader_ReadObject_From_JsonReader_Null()
        {
            var traktJsonReader = new UserIdsObjectJsonReader();
            Func<Task<ITraktUserIds>> userIds = () => traktJsonReader.ReadObjectAsync(default(JsonTextReader));
            await userIds.Should().ThrowAsync<ArgumentNullException>();
        }

        [Fact]
        public async Task Test_UserIdsObjectJsonReader_ReadObject_From_JsonReader_Empty()
        {
            var traktJsonReader = new UserIdsObjectJsonReader();

            using (var reader = new StringReader(string.Empty))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var userIds = await traktJsonReader.ReadObjectAsync(jsonReader);
                userIds.Should().BeNull();
            }
        }
    }
}
