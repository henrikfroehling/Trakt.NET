namespace TraktApiSharp.Tests.Objects.Get.Users.JsonReader
{
    using FluentAssertions;
    using System.Threading.Tasks;
    using Traits;
    using TraktApiSharp.Objects.Get.Users.JsonReader;
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
        }

        [Fact]
        public async Task Test_UserIdsObjectJsonReader_ReadObject_From_Json_String_Not_Valid()
        {
            var jsonReader = new UserIdsObjectJsonReader();

            var userIds = await jsonReader.ReadObjectAsync(JSON_NOT_VALID);

            userIds.Should().NotBeNull();
            userIds.Slug.Should().BeNull();
        }

        [Fact]
        public async Task Test_UserIdsObjectJsonReader_ReadObject_From_Json_String_Null()
        {
            var jsonReader = new UserIdsObjectJsonReader();

            var userIds = await jsonReader.ReadObjectAsync(default(string));
            userIds.Should().BeNull();
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
