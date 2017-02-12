namespace TraktApiSharp.Tests.Objects.Get.Movies
{
    using FluentAssertions;
    using Traits;
    using TraktApiSharp.Objects.Get.Movies;
    using Xunit;

    [Category("Objects.Get.Movies")]
    public class TraktMostPWCMovie_Tests
    {
        [Fact]
        public void Test_TraktMostPWCMovie_Implements_ITraktMostPWCMovie_Interface()
        {
            typeof(TraktMostPWCMovie).GetInterfaces().Should().Contain(typeof(ITraktMostPWCMovie));
        }
    }
}
