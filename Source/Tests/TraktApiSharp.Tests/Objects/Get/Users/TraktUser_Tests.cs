namespace TraktApiSharp.Tests.Objects.Get.Users
{
    using FluentAssertions;
    using Traits;
    using TraktApiSharp.Objects.Get.Users;
    using Xunit;

    [Category("Objects.Get.Users")]
    public class TraktUser_Tests
    {
        [Fact]
        public void Test_TraktUser_Implements_ITraktUser_Interface()
        {
            typeof(TraktUser).GetInterfaces().Should().Contain(typeof(ITraktUser));
        }
    }
}
