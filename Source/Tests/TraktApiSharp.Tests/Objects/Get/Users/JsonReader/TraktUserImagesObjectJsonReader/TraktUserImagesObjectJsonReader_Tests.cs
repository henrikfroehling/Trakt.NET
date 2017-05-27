namespace TraktApiSharp.Tests.Objects.Get.Users.JsonReader
{
    using FluentAssertions;
    using Traits;
    using TraktApiSharp.Objects.Get.Users;
    using TraktApiSharp.Objects.Get.Users.JsonReader;
    using TraktApiSharp.Objects.JsonReader;
    using Xunit;

    [Category("Objects.Get.Users.JsonReader")]
    public partial class TraktUserImagesObjectJsonReader_Tests
    {
        [Fact]
        public void Test_TraktUserImagesObjectJsonReader_Implements_ITraktObjectJsonReader_Interface()
        {
            typeof(TraktUserImagesObjectJsonReader).GetInterfaces().Should().Contain(typeof(ITraktObjectJsonReader<ITraktUserImages>));
        }
    }
}
