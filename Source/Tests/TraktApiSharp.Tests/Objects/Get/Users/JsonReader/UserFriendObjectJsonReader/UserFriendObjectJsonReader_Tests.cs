namespace TraktApiSharp.Tests.Objects.Get.Users.JsonReader
{
    using FluentAssertions;
    using Traits;
    using TraktApiSharp.Objects.Get.Users;
    using TraktApiSharp.Objects.Get.Users.JsonReader;
    using TraktApiSharp.Objects.JsonReader;
    using Xunit;

    [Category("Objects.Get.Users.JsonReader")]
    public partial class UserFriendObjectJsonReader_Tests
    {
        [Fact]
        public void Test_UserFriendObjectJsonReader_Implements_IObjectJsonReader_Interface()
        {
            typeof(UserFriendObjectJsonReader).GetInterfaces().Should().Contain(typeof(IObjectJsonReader<ITraktUserFriend>));
        }
    }
}
