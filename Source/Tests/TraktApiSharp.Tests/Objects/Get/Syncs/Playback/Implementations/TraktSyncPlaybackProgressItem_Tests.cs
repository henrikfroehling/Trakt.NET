namespace TraktApiSharp.Tests.Objects.Get.Syncs.Playback.Implementations
{
    using FluentAssertions;
    using Traits;
    using TraktApiSharp.Objects.Get.Syncs.Playback;
    using TraktApiSharp.Objects.Get.Syncs.Playback.Implementations;
    using Xunit;

    [Category("Objects.Get.Syncs.Playback.Implementations")]
    public class TraktSyncPlaybackProgressItem_Tests
    {
        [Fact]
        public void Test_TraktSyncPlaybackProgressItem_Implements_ITraktSyncPlaybackProgressItem_Interface()
        {
            typeof(TraktSyncPlaybackProgressItem).GetInterfaces().Should().Contain(typeof(ITraktSyncPlaybackProgressItem));
        }
    }
}
