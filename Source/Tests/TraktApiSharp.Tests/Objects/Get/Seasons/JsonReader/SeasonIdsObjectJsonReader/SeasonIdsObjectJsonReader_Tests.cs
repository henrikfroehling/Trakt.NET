namespace TraktApiSharp.Tests.Objects.Get.Seasons.JsonReader
{
    using FluentAssertions;
    using Traits;
    using TraktApiSharp.Objects.Get.Seasons;
    using TraktApiSharp.Objects.Get.Seasons.JsonReader;
    using TraktApiSharp.Objects.JsonReader;
    using Xunit;

    [Category("Objects.Get.Seasons.JsonReader")]
    public partial class SeasonIdsObjectJsonReader_Tests
    {
        [Fact]
        public void Test_SeasonIdsObjectJsonReader_Implements_IObjectJsonReader_Interface()
        {
            typeof(SeasonIdsObjectJsonReader).GetInterfaces().Should().Contain(typeof(IObjectJsonReader<ITraktSeasonIds>));
        }
    }
}
