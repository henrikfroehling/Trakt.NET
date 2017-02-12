namespace TraktApiSharp.Tests.Objects.Get.Movies
{
    using FluentAssertions;
    using Traits;
    using TraktApiSharp.Objects.Get.Movies;
    using Xunit;

    [Category("Objects.Get.Movies")]
    public class TraktRecentlyUpdatedMovie_Tests
    {
        [Fact]
        public void Test_TraktRecentlyUpdatedMovie_Implements_ITraktRecentlyUpdatedMovie_Interface()
        {
            typeof(TraktRecentlyUpdatedMovie).GetInterfaces().Should().Contain(typeof(ITraktRecentlyUpdatedMovie));
        }
    }
}
