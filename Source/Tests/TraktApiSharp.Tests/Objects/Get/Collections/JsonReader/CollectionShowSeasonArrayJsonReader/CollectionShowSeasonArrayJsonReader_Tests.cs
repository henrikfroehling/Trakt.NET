namespace TraktApiSharp.Tests.Objects.Get.Collections.JsonReader
{
    using FluentAssertions;
    using Traits;
    using TraktApiSharp.Objects.Get.Collections;
    using TraktApiSharp.Objects.Get.Collections.JsonReader;
    using TraktApiSharp.Objects.JsonReader;
    using Xunit;

    [Category("Objects.Get.Collections.JsonReader")]
    public partial class CollectionShowSeasonArrayJsonReader_Tests
    {
        [Fact]
        public void Test_CollectionShowSeasonArrayJsonReader_Implements_IArrayJsonReader_Interface()
        {
            typeof(CollectionShowSeasonArrayJsonReader).GetInterfaces().Should().Contain(typeof(IArrayJsonReader<ITraktCollectionShowSeason>));
        }
    }
}
