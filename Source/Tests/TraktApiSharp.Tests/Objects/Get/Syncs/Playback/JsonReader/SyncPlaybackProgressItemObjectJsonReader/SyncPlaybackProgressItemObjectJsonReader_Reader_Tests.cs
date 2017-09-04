namespace TraktApiSharp.Tests.Objects.Get.Syncs.Playback.JsonReader
{
    using FluentAssertions;
    using Newtonsoft.Json;
    using System.IO;
    using System.Threading.Tasks;
    using Traits;
    using TraktApiSharp.Objects.Get.Syncs.Playback.JsonReader;
    using Xunit;

    [Category("Objects.Get.Syncs.Playback.JsonReader")]
    public partial class SyncPlaybackProgressItemObjectJsonReader_Tests
    {
        [Fact]
        public async Task Test_SyncPlaybackProgressItemObjectJsonReader_ReadObject_From_JsonReader_Null()
        {
            var traktJsonReader = new SyncPlaybackProgressItemObjectJsonReader();

            var traktPlaybackProgressItem = await traktJsonReader.ReadObjectAsync(default(JsonTextReader));
            traktPlaybackProgressItem.Should().BeNull();
        }

        [Fact]
        public async Task Test_SyncPlaybackProgressItemObjectJsonReader_ReadObject_From_JsonReader_Empty()
        {
            var traktJsonReader = new SyncPlaybackProgressItemObjectJsonReader();

            using (var reader = new StringReader(string.Empty))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktPlaybackProgressItem = await traktJsonReader.ReadObjectAsync(jsonReader);
                traktPlaybackProgressItem.Should().BeNull();
            }
        }
    }
}
