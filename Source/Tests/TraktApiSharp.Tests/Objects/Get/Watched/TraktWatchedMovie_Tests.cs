namespace TraktApiSharp.Tests.Objects.Get.Watched
{
    using FluentAssertions;
    using Traits;
    using TraktApiSharp.Objects.Get.Watched;
    using Xunit;

    [Category("Objects.Get.Watched")]
    public class TraktWatchedMovie_Tests
    {
        [Fact]
        public void Test_TraktWatchedMovie_Implements_ITraktWatchedMovie_Interface()
        {
            typeof(TraktWatchedMovie).GetInterfaces().Should().Contain(typeof(ITraktWatchedMovie));
        }
    }
}
