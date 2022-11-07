namespace TraktNet.Objects.Get.Tests.Syncs.Playback.Json.Reader
{
    using FluentAssertions;
    using System;
    using System.IO;
    using System.Threading.Tasks;
    using Trakt.NET.Tests.Utility;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Objects.Get.Syncs.Playback;
    using TraktNet.Objects.Get.Syncs.Playback.Json.Reader;
    using Xunit;

    [TestCategory("Objects.Get.Syncs.Playback.JsonReader")]
    public partial class SyncPlaybackProgressItemObjectJsonReader_Tests
    {
        [Fact]
        public async Task Test_SyncPlaybackProgressItemObjectJsonReader_ReadObject_From_Stream_Null()
        {
            var jsonReader = new SyncPlaybackProgressItemObjectJsonReader();
            Func<Task<ITraktSyncPlaybackProgressItem>> traktPlaybackProgressItem = () => jsonReader.ReadObjectAsync(default(Stream));
            await traktPlaybackProgressItem.Should().ThrowAsync<ArgumentNullException>();
        }

        [Fact]
        public async Task Test_SyncPlaybackProgressItemObjectJsonReader_ReadObject_From_Stream_Empty()
        {
            var jsonReader = new SyncPlaybackProgressItemObjectJsonReader();

            using (var stream = string.Empty.ToStream())
            {
                var traktPlaybackProgressItem = await jsonReader.ReadObjectAsync(stream);
                traktPlaybackProgressItem.Should().BeNull();
            }
        }
    }
}
