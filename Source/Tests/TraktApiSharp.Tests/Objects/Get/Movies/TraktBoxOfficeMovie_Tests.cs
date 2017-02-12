namespace TraktApiSharp.Tests.Objects.Get.Movies
{
    using FluentAssertions;
    using Traits;
    using TraktApiSharp.Objects.Get.Movies;
    using Xunit;

    [Category("Objects.Get.Movies")]
    public class TraktBoxOfficeMovie_Tests
    {
        [Fact]
        public void Test_TraktBoxOfficeMovie_Implements_ITraktBoxOfficeMovie_Interface()
        {
            typeof(TraktBoxOfficeMovie).GetInterfaces().Should().Contain(typeof(ITraktBoxOfficeMovie));
        }
    }
}
