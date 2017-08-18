namespace TraktApiSharp.Tests.Objects.Get.Seasons.JsonReader
{
    using FluentAssertions;
    using Traits;
    using TraktApiSharp.Objects.Get.Seasons;
    using TraktApiSharp.Objects.Get.Seasons.JsonReader;
    using TraktApiSharp.Objects.JsonReader;
    using Xunit;

    [Category("Objects.Get.Seasons.JsonReader")]
    public partial class TraktSeasonCollectionProgressArrayJsonReader_Tests
    {
        [Fact]
        public void Test_TraktSeasonCollectionProgressArrayJsonReader_Implements_ITraktArrayJsonReader_Interface()
        {
            typeof(TraktSeasonCollectionProgressArrayJsonReader).GetInterfaces().Should().Contain(typeof(IArrayJsonReader<ITraktSeasonCollectionProgress>));
        }
    }
}
