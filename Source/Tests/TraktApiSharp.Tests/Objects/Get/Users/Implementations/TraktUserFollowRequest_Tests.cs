namespace TraktApiSharp.Tests.Objects.Get.Users.Implementations
{
    using FluentAssertions;
    using Traits;
    using TraktApiSharp.Objects.Get.Users;
    using TraktApiSharp.Objects.Get.Users.Implementations;
    using Xunit;

    [Category("Objects.Get.Users.Implementations")]
    public class TraktUserFollowRequest_Tests
    {
        [Fact]
        public void Test_TraktUserFollowRequest_Implements_ITraktUserFollowRequest_Interface()
        {
            typeof(TraktUserFollowRequest).GetInterfaces().Should().Contain(typeof(ITraktUserFollowRequest));
        }
    }
}
