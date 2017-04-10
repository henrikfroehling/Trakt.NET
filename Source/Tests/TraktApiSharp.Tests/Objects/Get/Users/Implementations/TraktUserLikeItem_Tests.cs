namespace TraktApiSharp.Tests.Objects.Get.Users.Implementations
{
    using FluentAssertions;
    using Traits;
    using TraktApiSharp.Objects.Get.Users;
    using TraktApiSharp.Objects.Get.Users.Implementations;
    using Xunit;

    [Category("Objects.Get.Users.Implementations")]
    public class TraktUserLikeItem_Tests
    {
        [Fact]
        public void Test_TraktUserLikeItem_Implements_ITraktUserLikeItem_Interface()
        {
            typeof(TraktUserLikeItem).GetInterfaces().Should().Contain(typeof(ITraktUserLikeItem));
        }
    }
}
