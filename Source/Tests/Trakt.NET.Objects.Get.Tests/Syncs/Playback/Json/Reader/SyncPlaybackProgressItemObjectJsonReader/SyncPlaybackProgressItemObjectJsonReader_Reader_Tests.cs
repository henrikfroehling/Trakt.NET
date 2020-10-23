namespace TraktNet.Objects.Get.Tests.Syncs.Playback.Json.Reader
{
    using FluentAssertions;
    using Newtonsoft.Json;
    using System;
    using System.IO;
    using System.Threading.Tasks;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Objects.Get.Syncs.Playback;
    using TraktNet.Objects.Get.Syncs.Playback.Json.Reader;
    using Xunit;

    [Category("Objects.Get.Syncs.Playback.JsonReader")]
    public partial class SyncPlaybackProgressItemObjectJsonReader_Tests
    {
        [Fact]
        public void Test_SyncPlaybackProgressItemObjectJsonReader_ReadObject_From_JsonReader_Null()
        {
            var traktJsonReader = new SyncPlaybackProgressItemObjectJsonReader();
            Func<Task<ITraktSyncPlaybackProgressItem>> traktPlaybackProgressItem = () => traktJsonReader.ReadObjectAsync(default(JsonTextReader));
            traktPlaybackProgressItem.Should().Throw<ArgumentNullException>();
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
