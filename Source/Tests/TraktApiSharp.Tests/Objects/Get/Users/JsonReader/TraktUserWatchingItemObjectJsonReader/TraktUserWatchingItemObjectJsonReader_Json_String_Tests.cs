namespace TraktApiSharp.Tests.Objects.Get.Users.JsonReader
{
    using FluentAssertions;
    using System.Threading.Tasks;
    using Traits;
    using TraktApiSharp.Objects.Get.Users.JsonReader;
    using Xunit;

    [Category("Objects.Get.Users.JsonReader")]
    public partial class TraktUserWatchingItemObjectJsonReader_Tests
    {
        [Fact]
        public async Task Test_TraktUserWatchingItemObjectJsonReader_ReadObject_From_Json_String_Null()
        {
            var jsonReader = new TraktUserWatchingItemObjectJsonReader();

            var traktUserWatchingItem = await jsonReader.ReadObjectAsync(default(string));
            traktUserWatchingItem.Should().BeNull();
        }

        [Fact]
        public async Task Test_TraktUserWatchingItemObjectJsonReader_ReadObject_From_Json_String_Empty()
        {
            var jsonReader = new TraktUserWatchingItemObjectJsonReader();

            var traktUserWatchingItem = await jsonReader.ReadObjectAsync(string.Empty);
            traktUserWatchingItem.Should().BeNull();
        }
    }
}
