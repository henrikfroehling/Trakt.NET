namespace TraktApiSharp.Tests.Objects.Get.Collection
{
    using FluentAssertions;
    using Traits;
    using TraktApiSharp.Objects.Get.Collection;
    using Xunit;

    [Category("Objects.Get.Collection")]
    public class TraktCollectionShow_Tests
    {
        [Fact]
        public void Test_TraktCollectionShow_Implements_ITraktCollectionShow_Interface()
        {
            typeof(TraktCollectionShow).GetInterfaces().Should().Contain(typeof(ITraktCollectionShow));
        }
    }
}
