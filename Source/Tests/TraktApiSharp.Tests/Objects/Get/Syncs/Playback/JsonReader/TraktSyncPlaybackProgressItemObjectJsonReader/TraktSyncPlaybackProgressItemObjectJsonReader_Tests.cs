namespace TraktApiSharp.Tests.Objects.Get.Syncs.Playback.JsonReader
{
    using FluentAssertions;
    using Traits;
    using TraktApiSharp.Objects.Get.Syncs.Playback;
    using TraktApiSharp.Objects.Get.Syncs.Playback.JsonReader;
    using TraktApiSharp.Objects.JsonReader;
    using Xunit;

    [Category("Objects.Get.Syncs.Playback.JsonReader")]
    public partial class TraktSyncPlaybackProgressItemObjectJsonReader_Tests
    {
        [Fact]
        public void Test_TraktSyncPlaybackProgressItemObjectJsonReader_Implements_ITraktObjectJsonReader_Interface()
        {
            typeof(TraktSyncPlaybackProgressItemObjectJsonReader).GetInterfaces().Should().Contain(typeof(ITraktObjectJsonReader<ITraktSyncPlaybackProgressItem>));
        }
    }
}
