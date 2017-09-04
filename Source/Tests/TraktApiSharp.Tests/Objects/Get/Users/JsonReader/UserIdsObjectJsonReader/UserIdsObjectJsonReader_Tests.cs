namespace TraktApiSharp.Tests.Objects.Get.Users.JsonReader
{
    using FluentAssertions;
    using Traits;
    using TraktApiSharp.Objects.Get.Users;
    using TraktApiSharp.Objects.Get.Users.JsonReader;
    using TraktApiSharp.Objects.JsonReader;
    using Xunit;

    [Category("Objects.Get.Users.JsonReader")]
    public partial class UserIdsObjectJsonReader_Tests
    {
        [Fact]
        public void Test_UserIdsObjectJsonReader_Implements_IObjectJsonReader_Interface()
        {
            typeof(UserIdsObjectJsonReader).GetInterfaces().Should().Contain(typeof(IObjectJsonReader<ITraktUserIds>));
        }
    }
}
