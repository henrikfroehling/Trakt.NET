namespace TraktApiSharp.Tests.Objects.Get.Users.Lists.Implementations
{
    using FluentAssertions;
    using Traits;
    using TraktApiSharp.Objects.Get.Users.Lists;
    using TraktApiSharp.Objects.Get.Users.Lists.Implementations;
    using Xunit;

    [Category("Objects.Get.Users.Lists.Implementations")]
    public class TraktListIds_Tests
    {
        [Fact]
        public void Test_TraktListIds_Implements_ITraktListIds_Interface()
        {
            typeof(TraktListIds).GetInterfaces().Should().Contain(typeof(ITraktListIds));
        }
    }
}
