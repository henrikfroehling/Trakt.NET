namespace TraktApiSharp.Tests.Objects.Get.Users.JsonReader
{
    using FluentAssertions;
    using System.IO;
    using System.Threading.Tasks;
    using TestUtils;
    using Traits;
    using TraktApiSharp.Objects.Get.Users.JsonReader;
    using Xunit;

    [Category("Objects.Get.Users.JsonReader")]
    public partial class TraktUserWatchingItemObjectJsonReader_Tests
    {
        [Fact]
        public async Task Test_TraktUserWatchingItemObjectJsonReader_ReadObject_From_Stream_Null()
        {
            var jsonReader = new TraktUserWatchingItemObjectJsonReader();

            var traktUserWatchingItem = await jsonReader.ReadObjectAsync(default(Stream));
            traktUserWatchingItem.Should().BeNull();
        }

        [Fact]
        public async Task Test_TraktUserWatchingItemObjectJsonReader_ReadObject_From_Stream_Empty()
        {
            var jsonReader = new TraktUserWatchingItemObjectJsonReader();

            using (var stream = string.Empty.ToStream())
            {
                var traktUserWatchingItem = await jsonReader.ReadObjectAsync(stream);
                traktUserWatchingItem.Should().BeNull();
            }
        }
    }
}
