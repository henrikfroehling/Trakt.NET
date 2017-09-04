namespace TraktApiSharp.Tests.Objects.Get.Users.Lists.JsonReader
{
    using FluentAssertions;
    using Traits;
    using TraktApiSharp.Objects.Get.Users.Lists;
    using TraktApiSharp.Objects.Get.Users.Lists.JsonReader;
    using TraktApiSharp.Objects.JsonReader;
    using Xunit;

    [Category("Objects.Get.Users.Lists.JsonReader")]
    public partial class ListItemObjectJsonReader_Tests
    {
        [Fact]
        public void Test_ListItemObjectJsonReader_Implements_IObjectJsonReader_Interface()
        {
            typeof(ListItemObjectJsonReader).GetInterfaces().Should().Contain(typeof(IObjectJsonReader<ITraktListItem>));
        }
    }
}
