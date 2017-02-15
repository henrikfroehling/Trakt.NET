namespace TraktApiSharp.Tests.Objects.Get.Watched
{
    using FluentAssertions;
    using Traits;
    using TraktApiSharp.Objects.Get.Watched;
    using Xunit;

    [Category("Objects.Get.Watched")]
    public class TraktWatchedShow_Tests
    {
        [Fact]
        public void Test_TraktWatchedShow_Implements_ITraktWatchedShow_Interface()
        {
            typeof(TraktWatchedShow).GetInterfaces().Should().Contain(typeof(ITraktWatchedShow));
        }
    }
}
