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
    public partial class UserWatchingItemObjectJsonReader_Tests
    {
        [Fact]
        public async Task Test_UserWatchingItemObjectJsonReader_ReadObject_From_JsonReader_Null()
        {
            var traktJsonReader = new UserWatchingItemObjectJsonReader();
            Func<Task<ITraktUserWatchingItem>> traktUserWatchingItem = () => traktJsonReader.ReadObjectAsync(default(JsonTextReader));
            await traktUserWatchingItem.Should().ThrowAsync<ArgumentNullException>();
        }

        [Fact]
        public async Task Test_UserWatchingItemObjectJsonReader_ReadObject_From_JsonReader_Empty()
        {
            var traktJsonReader = new UserWatchingItemObjectJsonReader();

            using (var reader = new StringReader(string.Empty))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktUserWatchingItem = await traktJsonReader.ReadObjectAsync(jsonReader);
                traktUserWatchingItem.Should().BeNull();
            }
        }
    }
}
