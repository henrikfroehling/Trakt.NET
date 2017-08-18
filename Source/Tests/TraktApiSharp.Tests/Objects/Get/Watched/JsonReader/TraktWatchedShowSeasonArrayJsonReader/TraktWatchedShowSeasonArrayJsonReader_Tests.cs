namespace TraktApiSharp.Tests.Objects.Get.Watched.JsonReader
{
    using FluentAssertions;
    using Traits;
    using TraktApiSharp.Objects.Get.Watched;
    using TraktApiSharp.Objects.Get.Watched.JsonReader;
    using TraktApiSharp.Objects.JsonReader;
    using Xunit;

    [Category("Objects.Get.Watched.JsonReader")]
    public partial class TraktWatchedShowSeasonArrayJsonReader_Tests
    {
        [Fact]
        public void Test_TraktWatchedShowSeasonArrayJsonReader_Implements_ITraktArrayJsonReader_Interface()
        {
            typeof(TraktWatchedShowSeasonArrayJsonReader).GetInterfaces().Should().Contain(typeof(IArrayJsonReader<ITraktWatchedShowSeason>));
        }
    }
}
