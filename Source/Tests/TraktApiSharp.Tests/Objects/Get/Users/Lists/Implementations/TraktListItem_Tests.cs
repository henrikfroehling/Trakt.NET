namespace TraktApiSharp.Tests.Objects.Get.Users.Lists.Implementations
{
    using FluentAssertions;
    using Traits;
    using TraktApiSharp.Objects.Get.Users.Lists;
    using TraktApiSharp.Objects.Get.Users.Lists.Implementations;
    using Xunit;

    [Category("Objects.Get.Users.Lists.Implementations")]
    public class TraktListItem_Tests
    {
        [Fact]
        public void Test_TraktListItem_Implements_ITraktListItem_Interface()
        {
            typeof(TraktListItem).GetInterfaces().Should().Contain(typeof(ITraktListItem));
        }
    }
}
