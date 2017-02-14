namespace TraktApiSharp.Tests.Objects.Get.Shows
{
    using FluentAssertions;
    using Traits;
    using TraktApiSharp.Objects.Get.Shows;
    using Xunit;

    [Category("Objects.Get.Shows")]
    public class TraktRecentlyUpdatedShow_Tests
    {
        [Fact]
        public void Test_TraktRecentlyUpdatedShow_Implements_ITraktRecentlyUpdatedShow_Interface()
        {
            typeof(TraktRecentlyUpdatedShow).GetInterfaces().Should().Contain(typeof(ITraktRecentlyUpdatedShow));
        }
    }
}
