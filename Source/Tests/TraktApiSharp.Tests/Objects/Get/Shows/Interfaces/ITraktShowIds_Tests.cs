namespace TraktApiSharp.Tests.Objects.Get.Shows.Interfaces
{
    using FluentAssertions;
    using Traits;
    using TraktApiSharp.Objects.Basic;
    using TraktApiSharp.Objects.Get.Shows;
    using Xunit;

    [Category("Objects.Get.Shows.Interfaces")]
    public class ITraktShowIds_Tests
    {
        [Fact]
        public void Test_ITraktShowIds_Is_Interface()
        {
            typeof(ITraktShowIds).IsInterface.Should().BeTrue();
        }

        [Fact]
        public void Test_ITraktShowIds_Inherits_ITraktIds_Interface()
        {
            typeof(ITraktShowIds).GetInterfaces().Should().Contain(typeof(ITraktIds));
        }
    }
}
