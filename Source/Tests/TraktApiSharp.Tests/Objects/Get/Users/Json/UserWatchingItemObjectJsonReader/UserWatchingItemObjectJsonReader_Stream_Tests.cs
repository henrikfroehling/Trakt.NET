namespace TraktApiSharp.Tests.Objects.Get.Users.Json
{
    using FluentAssertions;
    using System.IO;
    using System.Threading.Tasks;
    using TestUtils;
    using Traits;
    using TraktApiSharp.Objects.Get.Users.Json;
    using Xunit;

    [Category("Objects.Get.Users.JsonReader")]
    public partial class UserWatchingItemObjectJsonReader_Tests
    {
        [Fact]
        public async Task Test_UserWatchingItemObjectJsonReader_ReadObject_From_Stream_Null()
        {
            var jsonReader = new UserWatchingItemObjectJsonReader();

            var traktUserWatchingItem = await jsonReader.ReadObjectAsync(default(Stream));
            traktUserWatchingItem.Should().BeNull();
        }

        [Fact]
        public async Task Test_UserWatchingItemObjectJsonReader_ReadObject_From_Stream_Empty()
        {
            var jsonReader = new UserWatchingItemObjectJsonReader();

            using (var stream = string.Empty.ToStream())
            {
                var traktUserWatchingItem = await jsonReader.ReadObjectAsync(stream);
                traktUserWatchingItem.Should().BeNull();
            }
        }
    }
}
