namespace TraktApiSharp.Tests.Objects.Get.Users.Implementations
{
    using FluentAssertions;
    using Traits;
    using TraktApiSharp.Objects.Get.Users;
    using TraktApiSharp.Objects.Get.Users.Implementations;
    using Xunit;

    [Category("Objects.Get.Users.Implementations")]
    public class TraktUserWatchingItem_Tests
    {
        [Fact]
        public void Test_TraktUserWatchingItem_Implements_ITraktUserWatchingItem_Interface()
        {
            typeof(TraktUserWatchingItem).GetInterfaces().Should().Contain(typeof(ITraktUserWatchingItem));
        }
    }
}
