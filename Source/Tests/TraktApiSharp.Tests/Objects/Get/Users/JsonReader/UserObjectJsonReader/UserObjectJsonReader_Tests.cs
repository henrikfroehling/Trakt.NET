namespace TraktApiSharp.Tests.Objects.Get.Users.JsonReader
{
    using FluentAssertions;
    using Traits;
    using TraktApiSharp.Objects.Get.Users;
    using TraktApiSharp.Objects.Get.Users.JsonReader;
    using TraktApiSharp.Objects.JsonReader;
    using Xunit;

    [Category("Objects.Get.Users.JsonReader")]
    public partial class UserObjectJsonReader_Tests
    {
        [Fact]
        public void Test_UserObjectJsonReader_Implements_IObjectJsonReader_Interface()
        {
            typeof(UserObjectJsonReader).GetInterfaces().Should().Contain(typeof(IObjectJsonReader<ITraktUser>));
        }
    }
}
