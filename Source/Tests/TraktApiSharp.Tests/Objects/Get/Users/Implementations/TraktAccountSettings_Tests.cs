namespace TraktApiSharp.Tests.Objects.Get.Users.Implementations
{
    using FluentAssertions;
    using Traits;
    using TraktApiSharp.Objects.Get.Users;
    using TraktApiSharp.Objects.Get.Users.Implementations;
    using Xunit;

    [Category("Objects.Get.Users.Implementations")]
    public class TraktAccountSettings_Tests
    {
        [Fact]
        public void Test_TraktAccountSettings_Implements_ITraktAccountSettings_Interface()
        {
            typeof(TraktAccountSettings).GetInterfaces().Should().Contain(typeof(ITraktAccountSettings));
        }
    }
}
