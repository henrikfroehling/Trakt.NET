namespace TraktApiSharp.Tests.Objects.Get.Watched.Implementations
{
    using FluentAssertions;
    using Traits;
    using TraktApiSharp.Objects.Get.Watched;
    using TraktApiSharp.Objects.Get.Watched.Implementations;
    using Xunit;

    [Category("Objects.Get.Watched.Implementations")]
    public class TraktWatchedShowSeason_Tests
    {
        [Fact]
        public void Test_TraktWatchedShowSeason_Implements_ITraktWatchedShowSeason_Interface()
        {
            typeof(TraktWatchedShowSeason).GetInterfaces().Should().Contain(typeof(ITraktWatchedShowSeason));
        }
    }
}
