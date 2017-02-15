namespace TraktApiSharp.Tests.Objects.Get.Users
{
    using FluentAssertions;
    using Traits;
    using TraktApiSharp.Objects.Get.Users;
    using Xunit;

    [Category("Objects.Get.Users")]
    public class TraktUserFriend_Tests
    {
        [Fact]
        public void Test_TraktUserFriend_Implements_ITraktUserFriend_Interface()
        {
            typeof(TraktUserFriend).GetInterfaces().Should().Contain(typeof(ITraktUserFriend));
        }
    }
}
