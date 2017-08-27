namespace TraktApiSharp.Tests.Objects.Get.Collections.JsonReader
{
    using FluentAssertions;
    using Traits;
    using TraktApiSharp.Objects.Get.Collections;
    using TraktApiSharp.Objects.Get.Collections.JsonReader;
    using TraktApiSharp.Objects.JsonReader;
    using Xunit;

    [Category("Objects.Get.Collections.JsonReader")]
    public partial class CollectionShowSeasonObjectJsonReader_Tests
    {
        [Fact]
        public void Test_CollectionShowSeasonObjectJsonReader_Implements_IObjectJsonReader_Interface()
        {
            typeof(CollectionShowSeasonObjectJsonReader).GetInterfaces().Should().Contain(typeof(IObjectJsonReader<ITraktCollectionShowSeason>));
        }
    }
}
