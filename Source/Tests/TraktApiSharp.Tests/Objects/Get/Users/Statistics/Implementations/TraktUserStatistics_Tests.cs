namespace TraktApiSharp.Tests.Objects.Get.Users.Statistics.Implementations
{
    using FluentAssertions;
    using Traits;
    using TraktApiSharp.Objects.Get.Users.Statistics;
    using TraktApiSharp.Objects.Get.Users.Statistics.Implementations;
    using Xunit;

    [Category("Objects.Get.Users.Statistics.Implementations")]
    public class TraktUserStatistics_Tests
    {
        [Fact]
        public void Test_TraktUserStatistics_Implements_ITraktUserStatistics_Interface()
        {
            typeof(TraktUserStatistics).GetInterfaces().Should().Contain(typeof(ITraktUserStatistics));
        }
    }
}
