namespace TraktApiSharp.Tests.Objects.Get.Shows
{
    using FluentAssertions;
    using Traits;
    using TraktApiSharp.Objects.Get.Shows;
    using TraktApiSharp.Objects.Get.Shows.Common;
    using Xunit;

    [Category("Objects.Get.Shows")]
    public class TraktTrendingShow_Tests
    {
        [Fact]
        public void Test_TraktTrendingShow_Implements_ITraktTrendingShow_Interface()
        {
            typeof(TraktTrendingShow).GetInterfaces().Should().Contain(typeof(ITraktTrendingShow));
        }
    }
}
