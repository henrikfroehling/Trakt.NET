namespace TraktApiSharp.Tests.Objects.Get.Users.Implementations
{
    using FluentAssertions;
    using Traits;
    using TraktApiSharp.Objects.Get.Users;
    using TraktApiSharp.Objects.Get.Users.Implementations;
    using Xunit;

    [Category("Objects.Get.Users.Implementations")]
    public class TraktUserSettings_Tests
    {
        [Fact]
        public void Test_TraktUserSettings_Implements_ITraktUserSettings_Interface()
        {
            typeof(TraktUserSettings).GetInterfaces().Should().Contain(typeof(ITraktUserSettings));
        }
    }
}
