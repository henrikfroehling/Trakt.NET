namespace TraktApiSharp.Tests.Objects.Get.Users.Lists.Implementations
{
    using FluentAssertions;
    using Traits;
    using TraktApiSharp.Objects.Get.Users.Lists;
    using TraktApiSharp.Objects.Get.Users.Lists.Implementations;
    using Xunit;

    [Category("Objects.Get.Users.Lists.Implementations")]
    public class TraktList_Tests
    {
        [Fact]
        public void Test_TraktList_Implements_ITraktList_Interface()
        {
            typeof(TraktList).GetInterfaces().Should().Contain(typeof(ITraktList));
        }
    }
}
