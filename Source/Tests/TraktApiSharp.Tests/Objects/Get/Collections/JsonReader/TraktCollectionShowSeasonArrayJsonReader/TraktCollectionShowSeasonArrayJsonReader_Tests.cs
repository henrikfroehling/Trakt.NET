namespace TraktApiSharp.Tests.Objects.Get.Collections.JsonReader
{
    using FluentAssertions;
    using Traits;
    using TraktApiSharp.Objects.Get.Collections;
    using TraktApiSharp.Objects.Get.Collections.JsonReader;
    using TraktApiSharp.Objects.JsonReader;
    using Xunit;

    [Category("Objects.Get.Collections.JsonReader")]
    public partial class TraktCollectionShowSeasonArrayJsonReader_Tests
    {
        [Fact]
        public void Test_TraktCollectionShowSeasonArrayJsonReader_Implements_ITraktArrayJsonReader_Interface()
        {
            typeof(TraktCollectionShowSeasonArrayJsonReader).GetInterfaces().Should().Contain(typeof(IArrayJsonReader<ITraktCollectionShowSeason>));
        }
    }
}
