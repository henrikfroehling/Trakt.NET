namespace TraktApiSharp.Tests.Objects.Get.Users.Statistics.Implementations
{
    using FluentAssertions;
    using Traits;
    using TraktApiSharp.Objects.Get.Users.Statistics;
    using TraktApiSharp.Objects.Get.Users.Statistics.Implementations;
    using Xunit;

    [Category("Objects.Get.Users.Statistics.Implementations")]
    public class TraktUserRatingsStatistics_Tests
    {
        [Fact]
        public void Test_TraktUserRatingsStatistics_Implements_ITraktUserRatingsStatistics_Interface()
        {
            typeof(TraktUserRatingsStatistics).GetInterfaces().Should().Contain(typeof(ITraktUserRatingsStatistics));
        }
    }
}
