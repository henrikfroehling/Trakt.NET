namespace TraktApiSharp.Tests.Objects.Get.Episodes.JsonReader
{
    using FluentAssertions;
    using Traits;
    using TraktApiSharp.Objects.Get.Episodes;
    using TraktApiSharp.Objects.Get.Episodes.JsonReader;
    using TraktApiSharp.Objects.JsonReader;
    using Xunit;

    [Category("Objects.Get.Episodes.JsonReader")]
    public partial class TraktEpisodeWatchedProgressArrayJsonReader_Tests
    {
        [Fact]
        public void Test_TraktEpisodeWatchedProgressArrayJsonReader_Implements_ITraktArrayJsonReader_Interface()
        {
            typeof(TraktEpisodeWatchedProgressArrayJsonReader).GetInterfaces().Should().Contain(typeof(IArrayJsonReader<ITraktEpisodeWatchedProgress>));
        }
    }
}
