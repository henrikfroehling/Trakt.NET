namespace TraktApiSharp.Tests.Objects.Get.Users.Statistics.Implementations
{
    using FluentAssertions;
    using Traits;
    using TraktApiSharp.Objects.Get.Users.Statistics;
    using TraktApiSharp.Objects.Get.Users.Statistics.Implementations;
    using Xunit;

    [Category("Objects.Get.Users.Statistics.Implementations")]
    public class TraktUserSeasonsStatistics_Tests
    {
        [Fact]
        public void Test_TraktUserSeasonsStatistics_Implements_ITraktUserSeasonsStatistics_Interface()
        {
            typeof(TraktUserSeasonsStatistics).GetInterfaces().Should().Contain(typeof(ITraktUserSeasonsStatistics));
        }
    }
}
