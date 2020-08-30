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
    public partial class UserWatchingItemObjectJsonReader_Tests
    {
        [Fact]
        public void Test_UserWatchingItemObjectJsonReader_ReadObject_From_Json_String_Null()
        {
            var jsonReader = new UserWatchingItemObjectJsonReader();
            Func<Task<ITraktUserWatchingItem>> traktUserWatchingItem = () => jsonReader.ReadObjectAsync(default(string));
            traktUserWatchingItem.Should().Throw<ArgumentNullException>();
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
