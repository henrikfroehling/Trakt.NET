namespace TraktApiSharp.Tests.Objects.Get.Movies
{
    using FluentAssertions;
    using Traits;
    using TraktApiSharp.Objects.Get.Movies;
    using TraktApiSharp.Objects.Get.Movies.Common;
    using Xunit;

    [Category("Objects.Get.Movies")]
    public class TraktMostPlayedMovie_Tests
    {
        [Fact]
        public void Test_TraktMostPlayedMovie_Implements_ITraktMostPWCMovie_Interface()
        {
            typeof(TraktMostPlayedMovie).GetInterfaces().Should().Contain(typeof(ITraktMostPWCMovie));
        }
    }
}
