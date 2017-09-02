namespace TraktApiSharp.Tests.Objects.Get.Watched.JsonReader
{
    using FluentAssertions;
    using Traits;
    using TraktApiSharp.Objects.Get.Watched;
    using TraktApiSharp.Objects.Get.Watched.JsonReader;
    using TraktApiSharp.Objects.JsonReader;
    using Xunit;

    [Category("Objects.Get.Watched.JsonReader")]
    public partial class WatchedShowEpisodeArrayJsonReader_Tests
    {
        [Fact]
        public void Test_WatchedShowEpisodeArrayJsonReader_Implements_IArrayJsonReader_Interface()
        {
            typeof(WatchedShowEpisodeArrayJsonReader).GetInterfaces().Should().Contain(typeof(IArrayJsonReader<ITraktWatchedShowEpisode>));
        }
    }
}
