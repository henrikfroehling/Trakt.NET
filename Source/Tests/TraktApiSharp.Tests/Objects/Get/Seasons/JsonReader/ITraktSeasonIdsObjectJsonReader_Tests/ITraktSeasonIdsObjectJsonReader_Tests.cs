namespace TraktApiSharp.Tests.Objects.Get.Seasons.JsonReader
{
    using FluentAssertions;
    using Traits;
    using TraktApiSharp.Objects.Get.Seasons;
    using TraktApiSharp.Objects.Get.Seasons.JsonReader;
    using TraktApiSharp.Objects.JsonReader;
    using Xunit;

    [Category("Objects.Get.Seasons.JsonReader")]
    public partial class ITraktSeasonIdsObjectJsonReader_Tests
    {
        [Fact]
        public void Test_ITraktSeasonIdsObjectJsonReader_Implements_ITraktObjectJsonReader_Interface()
        {
            typeof(ITraktSeasonIdsObjectJsonReader).GetInterfaces().Should().Contain(typeof(ITraktObjectJsonReader<ITraktSeasonIds>));
        }
    }
}
