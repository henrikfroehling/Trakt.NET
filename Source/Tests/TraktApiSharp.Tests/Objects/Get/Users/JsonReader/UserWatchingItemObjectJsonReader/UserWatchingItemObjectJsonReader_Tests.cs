namespace TraktApiSharp.Tests.Objects.Get.Users.JsonReader
{
    using FluentAssertions;
    using Traits;
    using TraktApiSharp.Objects.Get.Users;
    using TraktApiSharp.Objects.Get.Users.JsonReader;
    using TraktApiSharp.Objects.JsonReader;
    using Xunit;

    [Category("Objects.Get.Users.JsonReader")]
    public partial class UserWatchingItemObjectJsonReader_Tests
    {
        [Fact]
        public void Test_UserWatchingItemObjectJsonReader_Implements_IObjectJsonReader_Interface()
        {
            typeof(UserWatchingItemObjectJsonReader).GetInterfaces().Should().Contain(typeof(IObjectJsonReader<ITraktUserWatchingItem>));
        }
    }
}
