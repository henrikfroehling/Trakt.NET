namespace TraktApiSharp.Tests.Objects.Get.Watched.JsonReader
{
    using FluentAssertions;
    using Traits;
    using TraktApiSharp.Objects.Get.Watched;
    using TraktApiSharp.Objects.Get.Watched.JsonReader;
    using TraktApiSharp.Objects.JsonReader;
    using Xunit;

    [Category("Objects.Get.Watched.JsonReader")]
    public partial class WatchedShowObjectJsonReader_Tests
    {
        [Fact]
        public void Test_WatchedShowObjectJsonReader_Implements_IObjectJsonReader_Interface()
        {
            typeof(WatchedShowObjectJsonReader).GetInterfaces().Should().Contain(typeof(IObjectJsonReader<ITraktWatchedShow>));
        }
    }
}
