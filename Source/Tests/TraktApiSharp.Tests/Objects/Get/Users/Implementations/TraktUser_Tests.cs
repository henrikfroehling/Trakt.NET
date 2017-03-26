namespace TraktApiSharp.Tests.Objects.Get.Users.Implementations
{
    using FluentAssertions;
    using Traits;
    using TraktApiSharp.Objects.Get.Users;
    using TraktApiSharp.Objects.Get.Users.Implementations;
    using Xunit;

    [Category("Objects.Get.Users.Implementations")]
    public class TraktUser_Tests
    {
        [Fact]
        public void Test_TraktUser_Implements_ITraktUser_Interface()
        {
            typeof(TraktUser).GetInterfaces().Should().Contain(typeof(ITraktUser));
        }
    }
}
