namespace TraktApiSharp.Tests.Objects.Get.Users.Lists.JsonReader
{
    using FluentAssertions;
    using Traits;
    using TraktApiSharp.Objects.Get.Users.Lists;
    using TraktApiSharp.Objects.Get.Users.Lists.JsonReader;
    using TraktApiSharp.Objects.JsonReader;
    using Xunit;

    [Category("Objects.Get.Users.Lists.JsonReader")]
    public partial class ListIdsObjectJsonReader_Tests
    {
        [Fact]
        public void Test_ListIdsObjectJsonReader_Implements_IObjectJsonReader_Interface()
        {
            typeof(ListIdsObjectJsonReader).GetInterfaces().Should().Contain(typeof(IObjectJsonReader<ITraktListIds>));
        }
    }
}
