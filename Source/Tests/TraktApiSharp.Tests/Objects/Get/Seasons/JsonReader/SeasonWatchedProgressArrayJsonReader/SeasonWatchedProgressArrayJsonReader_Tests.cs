namespace TraktApiSharp.Tests.Objects.Get.Seasons.JsonReader
{
    using FluentAssertions;
    using Traits;
    using TraktApiSharp.Objects.Get.Seasons;
    using TraktApiSharp.Objects.Get.Seasons.JsonReader;
    using TraktApiSharp.Objects.JsonReader;
    using Xunit;

    [Category("Objects.Get.Seasons.JsonReader")]
    public partial class SeasonWatchedProgressArrayJsonReader_Tests
    {
        [Fact]
        public void Test_SeasonWatchedProgressArrayJsonReader_Implements_IArrayJsonReader_Interface()
        {
            typeof(SeasonWatchedProgressArrayJsonReader).GetInterfaces().Should().Contain(typeof(IArrayJsonReader<ITraktSeasonWatchedProgress>));
        }
    }
}
