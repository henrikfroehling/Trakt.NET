namespace TraktApiSharp.Tests.Objects.Get.Episodes.Implementations
{
    using FluentAssertions;
    using Traits;
    using TraktApiSharp.Objects.Get.Episodes;
    using TraktApiSharp.Objects.Get.Episodes.Implementations;
    using Xunit;

    [Category("Objects.Get.Episodes.Implementations")]
    public class TraktEpisodeProgress_Tests
    {
        [Fact]
        public void Test_TraktEpisodeProgress_Implements_ITraktEpisodeProgress_Interface()
        {
            typeof(TraktEpisodeProgress).GetInterfaces().Should().Contain(typeof(ITraktEpisodeProgress));
        }
    }
}
