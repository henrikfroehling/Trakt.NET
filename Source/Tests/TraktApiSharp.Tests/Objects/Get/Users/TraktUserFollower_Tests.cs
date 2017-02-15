namespace TraktApiSharp.Tests.Objects.Get.Users
{
    using FluentAssertions;
    using Traits;
    using TraktApiSharp.Objects.Get.Users;
    using Xunit;

    [Category("Objects.Get.Users")]
    public class TraktUserFollower_Tests
    {
        [Fact]
        public void Test_TraktUserFollower_Implements_ITraktUserFollower_Interface()
        {
            typeof(TraktUserFollower).GetInterfaces().Should().Contain(typeof(ITraktUserFollower));
        }
    }
}
