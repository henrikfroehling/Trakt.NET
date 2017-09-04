namespace TraktApiSharp.Tests.Objects.Get.Watched.JsonReader
{
    using FluentAssertions;
    using Traits;
    using TraktApiSharp.Objects.Get.Watched;
    using TraktApiSharp.Objects.Get.Watched.JsonReader;
    using TraktApiSharp.Objects.JsonReader;
    using Xunit;

    [Category("Objects.Get.Watched.JsonReader")]
    public partial class WatchedShowSeasonArrayJsonReader_Tests
    {
        [Fact]
        public void Test_WatchedShowSeasonArrayJsonReader_Implements_IArrayJsonReader_Interface()
        {
            typeof(WatchedShowSeasonArrayJsonReader).GetInterfaces().Should().Contain(typeof(IArrayJsonReader<ITraktWatchedShowSeason>));
        }
    }
}
