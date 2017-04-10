namespace TraktApiSharp.Tests.Objects.Get.Seasons.Implementations
{
    using FluentAssertions;
    using Traits;
    using TraktApiSharp.Objects.Get.Seasons;
    using TraktApiSharp.Objects.Get.Seasons.Implementations;
    using Xunit;

    [Category("Objects.Get.Seasons.Implementations")]
    public class TraktSeasonProgress_Tests
    {
        [Fact]
        public void Test_TraktSeasonProgress_Implements_ITraktSeasonProgress_Interface()
        {
            typeof(TraktSeasonProgress).GetInterfaces().Should().Contain(typeof(ITraktSeasonProgress));
        }
    }
}
