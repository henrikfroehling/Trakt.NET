namespace TraktApiSharp.Tests.Objects.Get.Seasons.JsonReader
{
    using FluentAssertions;
    using Traits;
    using TraktApiSharp.Objects.Get.Seasons;
    using TraktApiSharp.Objects.Get.Seasons.JsonReader;
    using TraktApiSharp.Objects.JsonReader;
    using Xunit;

    [Category("Objects.Get.Seasons.JsonReader")]
    public partial class ITraktSeasonArrayJsonReader_Tests
    {
        [Fact]
        public void Test_ITraktSeasonArrayJsonReader_Implements_ITraktArrayJsonReader_Interface()
        {
            typeof(ITraktSeasonArrayJsonReader).GetInterfaces().Should().Contain(typeof(ITraktArrayJsonReader<ITraktSeason>));
        }
    }
}
