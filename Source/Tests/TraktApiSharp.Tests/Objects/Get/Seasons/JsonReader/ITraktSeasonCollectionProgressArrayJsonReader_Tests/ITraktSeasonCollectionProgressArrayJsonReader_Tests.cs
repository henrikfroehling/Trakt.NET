namespace TraktApiSharp.Tests.Objects.Get.Seasons.JsonReader
{
    using FluentAssertions;
    using Traits;
    using TraktApiSharp.Objects.Get.Seasons;
    using TraktApiSharp.Objects.Get.Seasons.JsonReader;
    using TraktApiSharp.Objects.JsonReader;
    using Xunit;

    [Category("Objects.Get.Seasons.JsonReader")]
    public partial class ITraktSeasonCollectionProgressArrayJsonReader_Tests
    {
        [Fact]
        public void Test_ITraktSeasonCollectionProgressArrayJsonReader_Implements_ITraktArrayJsonReader_Interface()
        {
            typeof(ITraktSeasonCollectionProgressArrayJsonReader).GetInterfaces().Should().Contain(typeof(ITraktArrayJsonReader<ITraktSeasonCollectionProgress>));
        }
    }
}
