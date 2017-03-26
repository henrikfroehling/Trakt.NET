namespace TraktApiSharp.Tests.Objects.Get.Users.Implementations
{
    using FluentAssertions;
    using Traits;
    using TraktApiSharp.Objects.Get.Users;
    using TraktApiSharp.Objects.Get.Users.Implementations;
    using Xunit;

    [Category("Objects.Get.Users.Implementations")]
    public class TraktUserFollower_Tests
    {
        [Fact]
        public void Test_TraktUserFollower_Implements_ITraktUserFollower_Interface()
        {
            typeof(TraktUserFollower).GetInterfaces().Should().Contain(typeof(ITraktUserFollower));
        }
    }
}
