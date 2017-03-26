namespace TraktApiSharp.Tests.Objects.Get.Users.Implementations
{
    using FluentAssertions;
    using Traits;
    using TraktApiSharp.Objects.Get.Users;
    using TraktApiSharp.Objects.Get.Users.Implementations;
    using Xunit;

    [Category("Objects.Get.Users.Implementations")]
    public class TraktUserHiddenItem_Tests
    {
        [Fact]
        public void Test_TraktUserHiddenItem_Implements_ITraktUserHiddenItem_Interface()
        {
            typeof(TraktUserHiddenItem).GetInterfaces().Should().Contain(typeof(ITraktUserHiddenItem));
        }
    }
}
