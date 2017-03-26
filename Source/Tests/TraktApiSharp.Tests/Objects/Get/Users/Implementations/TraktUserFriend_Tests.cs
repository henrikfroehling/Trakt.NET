namespace TraktApiSharp.Tests.Objects.Get.Users.Implementations
{
    using FluentAssertions;
    using Traits;
    using TraktApiSharp.Objects.Get.Users;
    using TraktApiSharp.Objects.Get.Users.Implementations;
    using Xunit;

    [Category("Objects.Get.Users.Implementations")]
    public class TraktUserFriend_Tests
    {
        [Fact]
        public void Test_TraktUserFriend_Implements_ITraktUserFriend_Interface()
        {
            typeof(TraktUserFriend).GetInterfaces().Should().Contain(typeof(ITraktUserFriend));
        }
    }
}
