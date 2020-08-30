namespace TraktNet.Objects.Get.Tests.Syncs.Playback.Json.Reader
{
    using FluentAssertions;
    using System;
    using System.Threading.Tasks;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Objects.Get.Syncs.Playback;
    using TraktNet.Objects.Get.Syncs.Playback.Json.Reader;
    using Xunit;

    [Category("Objects.Get.Syncs.Playback.JsonReader")]
    public partial class SyncPlaybackProgressItemObjectJsonReader_Tests
    {
        [Fact]
        public void Test_SyncPlaybackProgressItemObjectJsonReader_ReadObject_From_Json_String_Null()
        {
            var jsonReader = new SyncPlaybackProgressItemObjectJsonReader();
            Func<Task<ITraktSyncPlaybackProgressItem>> traktPlaybackProgressItem = () => jsonReader.ReadObjectAsync(default(string));
            traktPlaybackProgressItem.Should().Throw<ArgumentNullException>();
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
