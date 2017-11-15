namespace TraktApiSharp.Tests.Objects.Get.Users.Json
{
    using FluentAssertions;
    using System.Threading.Tasks;
    using Traits;
    using TraktApiSharp.Objects.Get.Users.Json;
    using Xunit;

    [Category("Objects.Get.Users.JsonReader")]
    public partial class UserWatchingItemObjectJsonReader_Tests
    {
        [Fact]
        public async Task Test_UserWatchingItemObjectJsonReader_ReadObject_From_Json_String_Null()
        {
            var jsonReader = new UserWatchingItemObjectJsonReader();

            var traktUserWatchingItem = await jsonReader.ReadObjectAsync(default(string));
            traktUserWatchingItem.Should().BeNull();
        }

        [Fact]
        public async Task Test_UserWatchingItemObjectJsonReader_ReadObject_From_Json_String_Empty()
        {
            var jsonReader = new UserWatchingItemObjectJsonReader();

            var traktUserWatchingItem = await jsonReader.ReadObjectAsync(string.Empty);
            traktUserWatchingItem.Should().BeNull();
        }
    }
}
