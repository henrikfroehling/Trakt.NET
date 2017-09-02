namespace TraktApiSharp.Tests.Objects.Get.Syncs.Playback.JsonReader
{
    using FluentAssertions;
    using Traits;
    using TraktApiSharp.Objects.Get.Syncs.Playback;
    using TraktApiSharp.Objects.Get.Syncs.Playback.JsonReader;
    using TraktApiSharp.Objects.JsonReader;
    using Xunit;

    [Category("Objects.Get.Syncs.Playback.JsonReader")]
    public partial class SyncPlaybackProgressItemObjectJsonReader_Tests
    {
        [Fact]
        public void Test_SyncPlaybackProgressItemObjectJsonReader_Implements_IObjectJsonReader_Interface()
        {
            typeof(SyncPlaybackProgressItemObjectJsonReader).GetInterfaces().Should().Contain(typeof(IObjectJsonReader<ITraktSyncPlaybackProgressItem>));
        }
    }
}
