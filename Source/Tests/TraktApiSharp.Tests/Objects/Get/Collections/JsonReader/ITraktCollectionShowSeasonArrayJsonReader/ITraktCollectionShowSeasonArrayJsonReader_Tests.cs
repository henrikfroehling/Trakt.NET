namespace TraktApiSharp.Tests.Objects.Get.Collections.JsonReader
{
    using FluentAssertions;
    using Traits;
    using TraktApiSharp.Objects.Get.Collections;
    using TraktApiSharp.Objects.Get.Collections.JsonReader;
    using TraktApiSharp.Objects.JsonReader;
    using Xunit;

    [Category("Objects.Get.Collections.JsonReader")]
    public partial class ITraktCollectionShowSeasonArrayJsonReader_Tests
    {
        [Fact]
        public void Test_ITraktCollectionShowSeasonArrayJsonReader_Implements_ITraktArrayJsonReader_Interface()
        {
            typeof(ITraktCollectionShowSeasonArrayJsonReader).GetInterfaces().Should().Contain(typeof(ITraktArrayJsonReader<ITraktCollectionShowSeason>));
        }
    }
}
