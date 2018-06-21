namespace TraktNet.Tests.Objects.Get.Users.Json.Reader
{
    using FluentAssertions;
    using System.Threading.Tasks;
    using Traits;
    using TraktNet.Objects.Get.Users.Json.Reader;
    using Xunit;

    [Category("Objects.Get.Users.JsonReader")]
    public partial class UserLikeItemObjectJsonReader_Tests
    {
        [Fact]
        public async Task Test_UserLikeItemObjectJsonReader_ReadObject_From_Json_String_Null()
        {
            var jsonReader = new UserLikeItemObjectJsonReader();

            var traktUserLikeItem = await jsonReader.ReadObjectAsync(default(string));
            traktUserLikeItem.Should().BeNull();
        }

        [Fact]
        public async Task Test_UserLikeItemObjectJsonReader_ReadObject_From_Json_String_Empty()
        {
            var jsonReader = new UserLikeItemObjectJsonReader();

            var traktUserLikeItem = await jsonReader.ReadObjectAsync(string.Empty);
            traktUserLikeItem.Should().BeNull();
        }
    }
}
