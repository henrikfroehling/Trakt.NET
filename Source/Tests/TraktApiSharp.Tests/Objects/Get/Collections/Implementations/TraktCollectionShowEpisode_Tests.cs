namespace TraktApiSharp.Tests.Objects.Get.Collections.Implementations
{
    using FluentAssertions;
    using Traits;
    using TraktApiSharp.Objects.Get.Collections;
    using TraktApiSharp.Objects.Get.Collections.Implementations;
    using Xunit;

    [Category("Objects.Get.Collections.Implementations")]
    public class TraktCollectionShowEpisode_Tests
    {
        [Fact]
        public void Test_TraktCollectionShowEpisode_Implements_ITraktCollectionShowEpisode_Interface()
        {
            typeof(TraktCollectionShowEpisode).GetInterfaces().Should().Contain(typeof(ITraktCollectionShowEpisode));
        }
    }
}
