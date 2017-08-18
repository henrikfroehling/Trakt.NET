namespace TraktApiSharp.Tests.Objects.Get.Users.Lists.JsonReader
{
    using FluentAssertions;
    using Traits;
    using TraktApiSharp.Objects.Get.Users.Lists;
    using TraktApiSharp.Objects.Get.Users.Lists.JsonReader;
    using TraktApiSharp.Objects.JsonReader;
    using Xunit;

    [Category("Objects.Get.Users.Lists.JsonReader")]
    public partial class TraktListObjectJsonReader_Tests
    {
        [Fact]
        public void Test_TraktListObjectJsonReader_Implements_ITraktObjectJsonReader_Interface()
        {
            typeof(TraktListObjectJsonReader).GetInterfaces().Should().Contain(typeof(IObjectJsonReader<ITraktList>));
        }
    }
}
