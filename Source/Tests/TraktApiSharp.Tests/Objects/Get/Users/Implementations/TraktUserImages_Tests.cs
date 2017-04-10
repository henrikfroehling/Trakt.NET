namespace TraktApiSharp.Tests.Objects.Get.Users.Implementations
{
    using FluentAssertions;
    using Traits;
    using TraktApiSharp.Objects.Get.Users;
    using TraktApiSharp.Objects.Get.Users.Implementations;
    using Xunit;

    [Category("Objects.Get.Users.Implementations")]
    public class TraktUserImages_Tests
    {
        [Fact]
        public void Test_TraktUserImages_Implements_ITraktUserImages_Interface()
        {
            typeof(TraktUserImages).GetInterfaces().Should().Contain(typeof(ITraktUserImages));
        }
    }
}
