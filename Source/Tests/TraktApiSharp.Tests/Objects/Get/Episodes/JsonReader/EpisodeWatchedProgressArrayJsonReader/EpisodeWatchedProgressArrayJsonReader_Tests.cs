namespace TraktApiSharp.Tests.Objects.Get.Episodes.JsonReader
{
    using FluentAssertions;
    using Traits;
    using TraktApiSharp.Objects.Get.Episodes;
    using TraktApiSharp.Objects.Get.Episodes.JsonReader;
    using TraktApiSharp.Objects.JsonReader;
    using Xunit;

    [Category("Objects.Get.Episodes.JsonReader")]
    public partial class EpisodeWatchedProgressArrayJsonReader_Tests
    {
        [Fact]
        public void Test_EpisodeWatchedProgressArrayJsonReader_Implements_IArrayJsonReader_Interface()
        {
            typeof(EpisodeWatchedProgressArrayJsonReader).GetInterfaces().Should().Contain(typeof(IArrayJsonReader<ITraktEpisodeWatchedProgress>));
        }
    }
}
