namespace TraktApiSharp.Tests.Objects.Get.Watched.JsonReader
{
    using FluentAssertions;
    using Traits;
    using TraktApiSharp.Objects.Get.Watched;
    using TraktApiSharp.Objects.Get.Watched.JsonReader;
    using TraktApiSharp.Objects.JsonReader;
    using Xunit;

    [Category("Objects.Get.Watched.JsonReader")]
    public partial class WatchedShowEpisodeObjectJsonReader_Tests
    {
        [Fact]
        public void Test_WatchedShowEpisodeObjectJsonReader_Implements_IObjectJsonReader_Interface()
        {
            typeof(WatchedShowEpisodeObjectJsonReader).GetInterfaces().Should().Contain(typeof(IObjectJsonReader<ITraktWatchedShowEpisode>));
        }
    }
}
