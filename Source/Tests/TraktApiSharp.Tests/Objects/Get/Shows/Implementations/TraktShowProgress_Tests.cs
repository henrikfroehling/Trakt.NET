namespace TraktApiSharp.Tests.Objects.Get.Shows.Implementations
{
    using FluentAssertions;
    using Traits;
    using TraktApiSharp.Objects.Get.Shows;
    using TraktApiSharp.Objects.Get.Shows.Implementations;
    using Xunit;

    [Category("Objects.Get.Shows.Implementations")]
    public class TraktShowProgress_Tests
    {
        [Fact]
        public void Test_TraktShowProgress_Implements_ITraktShowProgress_Interface()
        {
            typeof(TraktShowProgress).GetInterfaces().Should().Contain(typeof(ITraktShowProgress));
        }
    }
}
