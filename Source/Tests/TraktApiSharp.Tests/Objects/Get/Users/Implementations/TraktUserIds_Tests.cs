namespace TraktApiSharp.Tests.Objects.Get.Users.Implementations
{
    using FluentAssertions;
    using Traits;
    using TraktApiSharp.Objects.Get.Users;
    using TraktApiSharp.Objects.Get.Users.Implementations;
    using Xunit;

    [Category("Objects.Get.Users.Implementations")]
    public class TraktUserIds_Tests
    {
        [Fact]
        public void Test_TraktUserIds_Implements_ITraktUserIds_Interface()
        {
            typeof(TraktUserIds).GetInterfaces().Should().Contain(typeof(ITraktUserIds));
        }
    }
}
