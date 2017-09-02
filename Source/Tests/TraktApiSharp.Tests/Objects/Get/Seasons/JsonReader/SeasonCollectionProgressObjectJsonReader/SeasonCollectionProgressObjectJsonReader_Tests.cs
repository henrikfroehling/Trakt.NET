namespace TraktApiSharp.Tests.Objects.Get.Seasons.JsonReader
{
    using FluentAssertions;
    using Traits;
    using TraktApiSharp.Objects.Get.Seasons;
    using TraktApiSharp.Objects.Get.Seasons.JsonReader;
    using TraktApiSharp.Objects.JsonReader;
    using Xunit;

    [Category("Objects.Get.Seasons.JsonReader")]
    public partial class SeasonCollectionProgressObjectJsonReader_Tests
    {
        [Fact]
        public void Test_SeasonCollectionProgressObjectJsonReader_Implements_IObjectJsonReader_Interface()
        {
            typeof(SeasonCollectionProgressObjectJsonReader).GetInterfaces().Should().Contain(typeof(IObjectJsonReader<ITraktSeasonCollectionProgress>));
        }
    }
}
