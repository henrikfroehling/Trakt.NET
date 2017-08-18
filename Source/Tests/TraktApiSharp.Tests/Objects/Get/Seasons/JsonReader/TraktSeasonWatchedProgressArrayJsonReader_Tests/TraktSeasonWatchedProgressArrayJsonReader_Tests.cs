namespace TraktApiSharp.Tests.Objects.Get.Seasons.JsonReader
{
    using FluentAssertions;
    using Traits;
    using TraktApiSharp.Objects.Get.Seasons;
    using TraktApiSharp.Objects.Get.Seasons.JsonReader;
    using TraktApiSharp.Objects.JsonReader;
    using Xunit;

    [Category("Objects.Get.Seasons.JsonReader")]
    public partial class TraktSeasonWatchedProgressArrayJsonReader_Tests
    {
        [Fact]
        public void Test_TraktSeasonWatchedProgressArrayJsonReader_Implements_ITraktArrayJsonReader_Interface()
        {
            typeof(TraktSeasonWatchedProgressArrayJsonReader).GetInterfaces().Should().Contain(typeof(IArrayJsonReader<ITraktSeasonWatchedProgress>));
        }
    }
}
