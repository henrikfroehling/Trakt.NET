namespace TraktApiSharp.Tests.Objects.Get.Users.Statistics.Implementations
{
    using FluentAssertions;
    using Traits;
    using TraktApiSharp.Objects.Get.Users.Statistics;
    using TraktApiSharp.Objects.Get.Users.Statistics.Implementations;
    using Xunit;

    [Category("Objects.Get.Users.Statistics.Implementations")]
    public class TraktUserNetworkStatistics_Tests
    {
        [Fact]
        public void Test_TraktUserNetworkStatistics_Implements_ITraktUserNetworkStatistics_Interface()
        {
            typeof(TraktUserNetworkStatistics).GetInterfaces().Should().Contain(typeof(ITraktUserNetworkStatistics));
        }
    }
}
