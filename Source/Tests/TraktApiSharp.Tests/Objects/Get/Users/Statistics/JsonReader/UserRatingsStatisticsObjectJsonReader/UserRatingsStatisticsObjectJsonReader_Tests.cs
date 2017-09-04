namespace TraktApiSharp.Tests.Objects.Get.Users.Statistics.JsonReader
{
    using FluentAssertions;
    using Traits;
    using TraktApiSharp.Objects.Get.Users.Statistics;
    using TraktApiSharp.Objects.Get.Users.Statistics.JsonReader;
    using TraktApiSharp.Objects.JsonReader;
    using Xunit;

    [Category("Objects.Get.Users.Statistics.JsonReader")]
    public partial class UserRatingsStatisticsObjectJsonReader_Tests
    {
        [Fact]
        public void Test_UserRatingsStatisticsObjectJsonReader_Implements_IObjectJsonReader_Interface()
        {
            typeof(UserRatingsStatisticsObjectJsonReader).GetInterfaces().Should().Contain(typeof(IObjectJsonReader<ITraktUserRatingsStatistics>));
        }
    }
}
