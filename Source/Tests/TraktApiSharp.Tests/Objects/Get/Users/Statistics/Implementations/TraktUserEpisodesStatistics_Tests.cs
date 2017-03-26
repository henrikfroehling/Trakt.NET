namespace TraktApiSharp.Tests.Objects.Get.Users.Statistics.Implementations
{
    using FluentAssertions;
    using Traits;
    using TraktApiSharp.Objects.Get.Users.Statistics;
    using TraktApiSharp.Objects.Get.Users.Statistics.Implementations;
    using Xunit;

    [Category("Objects.Get.Users.Statistics.Implementations")]
    public class TraktUserEpisodesStatistics_Tests
    {
        [Fact]
        public void Test_TraktUserEpisodesStatistics_Implements_ITraktUserEpisodesStatistics_Interface()
        {
            typeof(TraktUserEpisodesStatistics).GetInterfaces().Should().Contain(typeof(ITraktUserEpisodesStatistics));
        }
    }
}
