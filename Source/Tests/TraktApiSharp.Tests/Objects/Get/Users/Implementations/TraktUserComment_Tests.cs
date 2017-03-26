namespace TraktApiSharp.Tests.Objects.Get.Users.Implementations
{
    using FluentAssertions;
    using Traits;
    using TraktApiSharp.Objects.Get.Users;
    using TraktApiSharp.Objects.Get.Users.Implementations;
    using Xunit;

    [Category("Objects.Get.Users.Implementations")]
    public class TraktUserComment_Tests
    {
        [Fact]
        public void Test_TraktUserComment_Implements_ITraktUserComment_Interface()
        {
            typeof(TraktUserComment).GetInterfaces().Should().Contain(typeof(ITraktUserComment));
        }
    }
}
