namespace TraktApiSharp.Tests.Objects.Get.Users.Implementations
{
    using FluentAssertions;
    using Traits;
    using TraktApiSharp.Objects.Get.Users;
    using TraktApiSharp.Objects.Get.Users.Implementations;
    using Xunit;

    [Category("Objects.Get.Users.Implementations")]
    public class TraktSharingText_Tests
    {
        [Fact]
        public void Test_TraktSharingText_Implements_ITraktSharingText_Interface()
        {
            typeof(TraktSharingText).GetInterfaces().Should().Contain(typeof(ITraktSharingText));
        }
    }
}
