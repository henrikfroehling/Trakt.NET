namespace TraktApiSharp.Tests.Objects.Get.Collections.JsonReader
{
    using FluentAssertions;
    using Traits;
    using TraktApiSharp.Objects.Get.Collections;
    using TraktApiSharp.Objects.Get.Collections.JsonReader;
    using TraktApiSharp.Objects.JsonReader;
    using Xunit;

    [Category("Objects.Get.Collections.JsonReader")]
    public partial class ITraktCollectionShowSeasonObjectJsonReader_Tests
    {
        [Fact]
        public void Test_ITraktCollectionShowSeasonObjectJsonReader_Implements_ITraktObjectJsonReader_Interface()
        {
            typeof(ITraktCollectionShowSeasonObjectJsonReader).GetInterfaces().Should().Contain(typeof(ITraktObjectJsonReader<ITraktCollectionShowSeason>));
        }
    }
}
