namespace TraktApiSharp.Tests.Objects.Get.Users.Json.Reader
{
    using FluentAssertions;
    using Newtonsoft.Json;
    using System.IO;
    using System.Threading.Tasks;
    using Traits;
    using TraktApiSharp.Objects.Get.Users.Json.Reader;
    using Xunit;

    [Category("Objects.Get.Users.JsonReader")]
    public partial class UserWatchingItemObjectJsonReader_Tests
    {
        [Fact]
        public async Task Test_UserWatchingItemObjectJsonReader_ReadObject_From_JsonReader_Null()
        {
            var traktJsonReader = new UserWatchingItemObjectJsonReader();

            var traktUserWatchingItem = await traktJsonReader.ReadObjectAsync(default(JsonTextReader));
            traktUserWatchingItem.Should().BeNull();
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
