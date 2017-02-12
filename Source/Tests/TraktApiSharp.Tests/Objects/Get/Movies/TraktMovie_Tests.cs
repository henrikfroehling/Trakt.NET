namespace TraktApiSharp.Tests.Objects.Get.Movies
{
    using FluentAssertions;
    using Traits;
    using TraktApiSharp.Objects.Get.Movies;
    using Xunit;

    [Category("Objects.Get.Movies")]
    public class TraktMovie_Tests
    {
        [Fact]
        public void Test_TraktMovie_Implements_ITraktMovie_Interface()
        {
            typeof(TraktMovie).GetInterfaces().Should().Contain(typeof(ITraktMovie));
        }
    }
}
