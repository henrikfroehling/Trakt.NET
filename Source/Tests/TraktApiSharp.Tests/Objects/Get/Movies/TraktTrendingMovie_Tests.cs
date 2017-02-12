namespace TraktApiSharp.Tests.Objects.Get.Movies
{
    using FluentAssertions;
    using Traits;
    using TraktApiSharp.Objects.Get.Movies;
    using Xunit;

    [Category("Objects.Get.Movies")]
    public class TraktTrendingMovie_Tests
    {
        [Fact]
        public void Test_TraktTrendingMovie_Implements_ITraktTrendingMovie_Interface()
        {
            typeof(TraktTrendingMovie).GetInterfaces().Should().Contain(typeof(ITraktTrendingMovie));
        }
    }
}
