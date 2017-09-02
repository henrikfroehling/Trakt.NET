namespace TraktApiSharp.Tests.Objects.Get.Episodes.JsonReader
{
    using FluentAssertions;
    using Traits;
    using TraktApiSharp.Objects.Get.Episodes;
    using TraktApiSharp.Objects.Get.Episodes.JsonReader;
    using TraktApiSharp.Objects.JsonReader;
    using Xunit;

    [Category("Objects.Get.Episodes.JsonReader")]
    public partial class EpisodeWatchedProgressObjectJsonReader_Tests
    {
        [Fact]
        public void Test_EpisodeWatchedProgressObjectJsonReader_Implements_IObjectJsonReader_Interface()
        {
            typeof(EpisodeWatchedProgressObjectJsonReader).GetInterfaces().Should().Contain(typeof(IObjectJsonReader<ITraktEpisodeWatchedProgress>));
        }
    }
}
