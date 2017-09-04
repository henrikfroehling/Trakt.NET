namespace TraktApiSharp.Tests.Objects.Get.Syncs.Playback.JsonReader
{
    using FluentAssertions;
    using System.Threading.Tasks;
    using Traits;
    using TraktApiSharp.Objects.Get.Syncs.Playback.JsonReader;
    using Xunit;

    [Category("Objects.Get.Syncs.Playback.JsonReader")]
    public partial class SyncPlaybackProgressItemObjectJsonReader_Tests
    {
        [Fact]
        public async Task Test_SyncPlaybackProgressItemObjectJsonReader_ReadObject_From_Json_String_Null()
        {
            var jsonReader = new SyncPlaybackProgressItemObjectJsonReader();

            var traktPlaybackProgressItem = await jsonReader.ReadObjectAsync(default(string));
            traktPlaybackProgressItem.Should().BeNull();
        }

        [Fact]
        public async Task Test_SyncPlaybackProgressItemObjectJsonReader_ReadObject_From_Json_String_Empty()
        {
            var jsonReader = new SyncPlaybackProgressItemObjectJsonReader();

            var traktPlaybackProgressItem = await jsonReader.ReadObjectAsync(string.Empty);
            traktPlaybackProgressItem.Should().BeNull();
        }
    }
}
