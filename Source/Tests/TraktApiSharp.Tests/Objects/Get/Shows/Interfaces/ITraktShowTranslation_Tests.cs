namespace TraktApiSharp.Tests.Objects.Get.Shows.Interfaces
{
    using FluentAssertions;
    using Traits;
    using TraktApiSharp.Objects.Basic;
    using TraktApiSharp.Objects.Get.Shows;
    using Xunit;

    [Category("Objects.Get.Shows.Interfaces")]
    public class ITraktShowTranslation_Tests
    {
        [Fact]
        public void Test_ITraktShowTranslation_Is_Interface()
        {
            typeof(ITraktShowTranslation).IsInterface.Should().BeTrue();
        }

        [Fact]
        public void Test_ITraktShowTranslation_Inherits_ITraktTranslation_Interface()
        {
            typeof(ITraktShowTranslation).GetInterfaces().Should().Contain(typeof(ITraktTranslation));
        }
    }
}
