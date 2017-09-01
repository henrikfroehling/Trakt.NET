namespace TraktApiSharp.Tests.Objects.Get.Seasons.JsonReader
{
    using FluentAssertions;
    using Traits;
    using TraktApiSharp.Objects.Get.Seasons;
    using TraktApiSharp.Objects.Get.Seasons.JsonReader;
    using TraktApiSharp.Objects.JsonReader;
    using Xunit;

    [Category("Objects.Get.Seasons.JsonReader")]
    public partial class SeasonWatchedProgressObjectJsonReader_Tests
    {
        [Fact]
        public void Test_SeasonWatchedProgressObjectJsonReader_Implements_IObjectJsonReader_Interface()
        {
            typeof(SeasonWatchedProgressObjectJsonReader).GetInterfaces().Should().Contain(typeof(IObjectJsonReader<ITraktSeasonWatchedProgress>));
        }
    }
}
