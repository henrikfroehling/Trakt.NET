namespace TraktApiSharp.Tests.Objects.Get.Watched.JsonReader
{
    using FluentAssertions;
    using Traits;
    using TraktApiSharp.Objects.Get.Watched;
    using TraktApiSharp.Objects.Get.Watched.JsonReader;
    using TraktApiSharp.Objects.JsonReader;
    using Xunit;

    [Category("Objects.Get.Watched.JsonReader")]
    public partial class TraktWatchedShowEpisodeArrayJsonReader_Tests
    {
        [Fact]
        public void Test_TraktWatchedShowEpisodeArrayJsonReader_Implements_ITraktArrayJsonReader_Interface()
        {
            typeof(TraktWatchedShowEpisodeArrayJsonReader).GetInterfaces().Should().Contain(typeof(ITraktArrayJsonReader<ITraktWatchedShowEpisode>));
        }
    }
}
