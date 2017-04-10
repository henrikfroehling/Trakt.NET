namespace TraktApiSharp.Tests.Objects.Get.Episodes.Interfaces
{
    using FluentAssertions;
    using Traits;
    using TraktApiSharp.Objects.Basic;
    using TraktApiSharp.Objects.Get.Episodes;
    using Xunit;

    [Category("Objects.Get.Episodes.Interfaces")]
    public class ITraktEpisodeTranslation_Tests
    {
        [Fact]
        public void Test_ITraktEpisodeTranslation_Is_Interface()
        {
            typeof(ITraktEpisodeTranslation).IsInterface.Should().BeTrue();
        }

        [Fact]
        public void Test_ITraktEpisodeTranslation_Inherits_ITraktTranslation_Interface()
        {
            typeof(ITraktEpisodeTranslation).GetInterfaces().Should().Contain(typeof(ITraktTranslation));
        }
    }
}
