namespace TraktApiSharp.Tests.Objects.Get.Users.JsonReader
{
    using FluentAssertions;
    using Traits;
    using TraktApiSharp.Objects.Get.Users;
    using TraktApiSharp.Objects.Get.Users.JsonReader;
    using TraktApiSharp.Objects.JsonReader;
    using Xunit;

    [Category("Objects.Get.Users.JsonReader")]
    public partial class TraktUserWatchingItemObjectJsonReader_Tests
    {
        [Fact]
        public void Test_TraktUserWatchingItemObjectJsonReader_Implements_ITraktObjectJsonReader_Interface()
        {
            typeof(TraktUserWatchingItemObjectJsonReader).GetInterfaces().Should().Contain(typeof(IObjectJsonReader<ITraktUserWatchingItem>));
        }
    }
}
