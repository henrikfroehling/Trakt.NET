namespace TraktApiSharp.Tests.Objects.Get.Users.Statistics.JsonReader
{
    using FluentAssertions;
    using Traits;
    using TraktApiSharp.Objects.Get.Users.Statistics;
    using TraktApiSharp.Objects.Get.Users.Statistics.JsonReader;
    using TraktApiSharp.Objects.JsonReader;
    using Xunit;

    [Category("Objects.Get.Users.Statistics.JsonReader")]
    public partial class UserNetworkStatisticsObjectJsonReader_Tests
    {
        [Fact]
        public void Test_UserNetworkStatisticsObjectJsonReader_Implements_IObjectJsonReader_Interface()
        {
            typeof(UserNetworkStatisticsObjectJsonReader).GetInterfaces().Should().Contain(typeof(IObjectJsonReader<ITraktUserNetworkStatistics>));
        }
    }
}
