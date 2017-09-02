namespace TraktApiSharp.Tests.Objects.Get.Watched.JsonReader
{
    using FluentAssertions;
    using Traits;
    using TraktApiSharp.Objects.Get.Watched;
    using TraktApiSharp.Objects.Get.Watched.JsonReader;
    using TraktApiSharp.Objects.JsonReader;
    using Xunit;

    [Category("Objects.Get.Watched.JsonReader")]
    public partial class WatchedShowSeasonObjectJsonReader_Tests
    {
        [Fact]
        public void Test_WatchedShowSeasonObjectJsonReader_Implements_IObjectJsonReader_Interface()
        {
            typeof(WatchedShowSeasonObjectJsonReader).GetInterfaces().Should().Contain(typeof(IObjectJsonReader<ITraktWatchedShowSeason>));
        }
    }
}
