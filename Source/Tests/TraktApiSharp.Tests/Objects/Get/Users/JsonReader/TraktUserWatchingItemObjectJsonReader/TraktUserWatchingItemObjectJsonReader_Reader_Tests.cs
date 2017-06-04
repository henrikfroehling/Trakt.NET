namespace TraktApiSharp.Tests.Objects.Get.Users.JsonReader
{
    using FluentAssertions;
    using Newtonsoft.Json;
    using System.IO;
    using System.Threading.Tasks;
    using Traits;
    using TraktApiSharp.Objects.Get.Users.JsonReader;
    using Xunit;

    [Category("Objects.Get.Users.JsonReader")]
    public partial class TraktUserWatchingItemObjectJsonReader_Tests
    {
        [Fact]
        public async Task Test_TraktUserWatchingItemObjectJsonReader_ReadObject_From_JsonReader_Null()
        {
            var traktJsonReader = new TraktUserWatchingItemObjectJsonReader();

            var traktUserWatchingItem = await traktJsonReader.ReadObjectAsync(default(JsonTextReader));
            traktUserWatchingItem.Should().BeNull();
        }

        [Fact]
        public async Task Test_TraktUserWatchingItemObjectJsonReader_ReadObject_From_JsonReader_Empty()
        {
            var traktJsonReader = new TraktUserWatchingItemObjectJsonReader();

            using (var reader = new StringReader(string.Empty))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktUserWatchingItem = await traktJsonReader.ReadObjectAsync(jsonReader);
                traktUserWatchingItem.Should().BeNull();
            }
        }
    }
}
