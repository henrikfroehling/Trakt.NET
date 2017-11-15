namespace TraktApiSharp.Tests.Objects.Get.Users.Json
{
    using FluentAssertions;
    using Newtonsoft.Json;
    using System.IO;
    using System.Threading.Tasks;
    using Traits;
    using TraktApiSharp.Objects.Get.Users.Json;
    using Xunit;

    [Category("Objects.Get.Users.JsonReader")]
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
            }
        }

        [Fact]
        public async Task Test_UserIdsObjectJsonReader_ReadObject_From_JsonReader_Null()
        {
            var traktJsonReader = new UserIdsObjectJsonReader();

            var userIds = await traktJsonReader.ReadObjectAsync(default(JsonTextReader));
            userIds.Should().BeNull();
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
