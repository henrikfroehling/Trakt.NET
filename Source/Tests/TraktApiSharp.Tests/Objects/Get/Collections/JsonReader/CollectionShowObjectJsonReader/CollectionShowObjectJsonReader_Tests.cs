namespace TraktApiSharp.Tests.Objects.Get.Collections.JsonReader
{
    using FluentAssertions;
    using Traits;
    using TraktApiSharp.Objects.Get.Collections;
    using TraktApiSharp.Objects.Get.Collections.JsonReader;
    using TraktApiSharp.Objects.JsonReader;
    using Xunit;

    [Category("Objects.Get.Collections.JsonReader")]
    public partial class CollectionShowObjectJsonReader_Tests
    {
        [Fact]
        public void Test_CollectionShowObjectJsonReader_Implements_IObjectJsonReader_Interface()
        {
            typeof(CollectionShowObjectJsonReader).GetInterfaces().Should().Contain(typeof(IObjectJsonReader<ITraktCollectionShow>));
        }
    }
}
