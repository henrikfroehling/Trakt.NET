namespace TraktApiSharp.Tests.Objects.Get.Collections.JsonReader
{
    using FluentAssertions;
    using Traits;
    using TraktApiSharp.Objects.Get.Collections;
    using TraktApiSharp.Objects.Get.Collections.JsonReader;
    using TraktApiSharp.Objects.JsonReader;
    using Xunit;

    [Category("Objects.Get.Collections.JsonReader")]
    public partial class TraktCollectionShowSeasonObjectJsonReader_Tests
    {
        [Fact]
        public void Test_TraktCollectionShowSeasonObjectJsonReader_Implements_ITraktObjectJsonReader_Interface()
        {
            typeof(TraktCollectionShowSeasonObjectJsonReader).GetInterfaces().Should().Contain(typeof(ITraktObjectJsonReader<ITraktCollectionShowSeason>));
        }
    }
}
