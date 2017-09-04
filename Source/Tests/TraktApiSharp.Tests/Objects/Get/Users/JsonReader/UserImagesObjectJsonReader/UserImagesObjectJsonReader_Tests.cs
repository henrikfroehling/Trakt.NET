namespace TraktApiSharp.Tests.Objects.Get.Users.JsonReader
{
    using FluentAssertions;
    using Traits;
    using TraktApiSharp.Objects.Get.Users;
    using TraktApiSharp.Objects.Get.Users.JsonReader;
    using TraktApiSharp.Objects.JsonReader;
    using Xunit;

    [Category("Objects.Get.Users.JsonReader")]
    public partial class UserImagesObjectJsonReader_Tests
    {
        [Fact]
        public void Test_UserImagesObjectJsonReader_Implements_IObjectJsonReader_Interface()
        {
            typeof(UserImagesObjectJsonReader).GetInterfaces().Should().Contain(typeof(IObjectJsonReader<ITraktUserImages>));
        }
    }
}
