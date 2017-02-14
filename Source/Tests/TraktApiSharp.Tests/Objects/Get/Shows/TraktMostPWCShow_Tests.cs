namespace TraktApiSharp.Tests.Objects.Get.Shows
{
    using FluentAssertions;
    using Traits;
    using TraktApiSharp.Objects.Get.Shows;
    using TraktApiSharp.Objects.Get.Shows.Common;
    using Xunit;

    [Category("Objects.Get.Shows")]
    public class TraktMostPWCShow_Tests
    {
        [Fact]
        public void Test_TraktMostPWCShow_Implements_ITraktMostPWCShow_Interface()
        {
            typeof(TraktMostPWCShow).GetInterfaces().Should().Contain(typeof(ITraktMostPWCShow));
        }
    }
}
