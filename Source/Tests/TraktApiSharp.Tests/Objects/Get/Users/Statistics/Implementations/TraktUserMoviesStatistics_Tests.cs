namespace TraktApiSharp.Tests.Objects.Get.Users.Statistics.Implementations
{
    using FluentAssertions;
    using Traits;
    using TraktApiSharp.Objects.Get.Users.Statistics;
    using TraktApiSharp.Objects.Get.Users.Statistics.Implementations;
    using Xunit;

    [Category("Objects.Get.Users.Statistics.Implementations")]
    public class TraktUserMoviesStatistics_Tests
    {
        [Fact]
        public void Test_TraktUserMoviesStatistics_Implements_ITraktUserMoviesStatistics_Interface()
        {
            typeof(TraktUserMoviesStatistics).GetInterfaces().Should().Contain(typeof(ITraktUserMoviesStatistics));
        }
    }
}
