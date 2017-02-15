namespace TraktApiSharp.Tests.Objects.Get.Collection
{
    using FluentAssertions;
    using Traits;
    using TraktApiSharp.Objects.Get.Collection;
    using Xunit;

    [Category("Objects.Get.Collection")]
    public class TraktCollectionMovie_Tests
    {
        [Fact]
        public void Test_TraktCollectionMovie_Implements_ITraktCollectionMovie_Interface()
        {
            typeof(TraktCollectionMovie).GetInterfaces().Should().Contain(typeof(ITraktCollectionMovie));
        }
    }
}
