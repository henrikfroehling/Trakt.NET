namespace TraktApiSharp.Tests.Objects.Get.Users.Statistics.Implementations
{
    using FluentAssertions;
    using Traits;
    using TraktApiSharp.Objects.Get.Users.Statistics;
    using TraktApiSharp.Objects.Get.Users.Statistics.Implementations;
    using Xunit;

    [Category("Objects.Get.Users.Statistics.Implementations")]
    public class TraktUserShowsStatistics_Tests
    {
        [Fact]
        public void Test_TraktUserShowsStatistics_Implements_ITraktUserShowsStatistics_Interface()
        {
            typeof(TraktUserShowsStatistics).GetInterfaces().Should().Contain(typeof(ITraktUserShowsStatistics));
        }
    }
}
