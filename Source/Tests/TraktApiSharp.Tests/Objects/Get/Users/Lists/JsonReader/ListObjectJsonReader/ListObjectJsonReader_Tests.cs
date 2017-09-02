namespace TraktApiSharp.Tests.Objects.Get.Users.Lists.JsonReader
{
    using FluentAssertions;
    using Traits;
    using TraktApiSharp.Objects.Get.Users.Lists;
    using TraktApiSharp.Objects.Get.Users.Lists.JsonReader;
    using TraktApiSharp.Objects.JsonReader;
    using Xunit;

    [Category("Objects.Get.Users.Lists.JsonReader")]
    public partial class ListObjectJsonReader_Tests
    {
        [Fact]
        public void Test_ListObjectJsonReader_Implements_IObjectJsonReader_Interface()
        {
            typeof(ListObjectJsonReader).GetInterfaces().Should().Contain(typeof(IObjectJsonReader<ITraktList>));
        }
    }
}
