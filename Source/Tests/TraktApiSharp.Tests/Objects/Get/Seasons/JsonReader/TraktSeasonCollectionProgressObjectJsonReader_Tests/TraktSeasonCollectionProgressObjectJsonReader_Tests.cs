namespace TraktApiSharp.Tests.Objects.Get.Seasons.JsonReader
{
    using FluentAssertions;
    using Traits;
    using TraktApiSharp.Objects.Get.Seasons;
    using TraktApiSharp.Objects.Get.Seasons.JsonReader;
    using TraktApiSharp.Objects.JsonReader;
    using Xunit;

    [Category("Objects.Get.Seasons.JsonReader")]
    public partial class TraktSeasonCollectionProgressObjectJsonReader_Tests
    {
        [Fact]
        public void Test_TraktSeasonCollectionProgressObjectJsonReader_Implements_ITraktObjectJsonReader_Interface()
        {
            typeof(TraktSeasonCollectionProgressObjectJsonReader).GetInterfaces().Should().Contain(typeof(ITraktObjectJsonReader<ITraktSeasonCollectionProgress>));
        }
    }
}
