namespace TraktApiSharp.Tests.Objects.Get.Shows
{
    using FluentAssertions;
    using Traits;
    using TraktApiSharp.Objects.Get.Shows;
    using Xunit;

    [Category("Objects.Get.Shows")]
    public class TraktShow_Tests
    {
        [Fact]
        public void Test_TraktShow_Implements_ITraktShow_Interface()
        {
            typeof(TraktShow).GetInterfaces().Should().Contain(typeof(ITraktShow));
        }
    }
}
