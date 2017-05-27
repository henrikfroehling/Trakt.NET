namespace TraktApiSharp.Tests.Objects.Get.Users.JsonReader
{
    using FluentAssertions;
    using Traits;
    using TraktApiSharp.Objects.Get.Users;
    using TraktApiSharp.Objects.Get.Users.JsonReader;
    using TraktApiSharp.Objects.JsonReader;
    using Xunit;

    [Category("Objects.Get.Users.JsonReader")]
    public partial class TraktUserIdsObjectJsonReader_Tests
    {
        [Fact]
        public void Test_TraktUserIdsObjectJsonReader_Implements_ITraktObjectJsonReader_Interface()
        {
            typeof(TraktUserIdsObjectJsonReader).GetInterfaces().Should().Contain(typeof(ITraktObjectJsonReader<ITraktUserIds>));
        }
    }
}
