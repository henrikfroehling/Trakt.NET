namespace TraktApiSharp.Tests.Objects.Get.Collections.Implementations
{
    using FluentAssertions;
    using Traits;
    using TraktApiSharp.Objects.Get.Collections;
    using TraktApiSharp.Objects.Get.Collections.Implementations;
    using Xunit;

    [Category("Objects.Get.Collections.Implementations")]
    public class TraktCollectionShowSeason_Tests
    {
        [Fact]
        public void Test_TraktCollectionShowSeason_Implements_ITraktCollectionShowSeason_Interface()
        {
            typeof(TraktCollectionShowSeason).GetInterfaces().Should().Contain(typeof(ITraktCollectionShowSeason));
        }
    }
}
