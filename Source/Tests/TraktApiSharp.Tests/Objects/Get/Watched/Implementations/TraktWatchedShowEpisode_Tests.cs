namespace TraktApiSharp.Tests.Objects.Get.Watched.Implementations
{
    using FluentAssertions;
    using Traits;
    using TraktApiSharp.Objects.Get.Watched;
    using TraktApiSharp.Objects.Get.Watched.Implementations;
    using Xunit;

    [Category("Objects.Get.Watched.Implementations")]
    public class TraktWatchedShowEpisode_Tests
    {
        [Fact]
        public void Test_TraktWatchedShowEpisode_Implements_ITraktWatchedShowEpisode_Interface()
        {
            typeof(TraktWatchedShowEpisode).GetInterfaces().Should().Contain(typeof(ITraktWatchedShowEpisode));
        }
    }
}
