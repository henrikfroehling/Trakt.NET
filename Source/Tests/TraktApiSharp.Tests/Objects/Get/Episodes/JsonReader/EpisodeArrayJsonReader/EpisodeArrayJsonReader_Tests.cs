namespace TraktApiSharp.Tests.Objects.Get.Episodes.JsonReader
{
    using FluentAssertions;
    using Traits;
    using TraktApiSharp.Objects.Get.Episodes;
    using TraktApiSharp.Objects.Get.Episodes.JsonReader;
    using TraktApiSharp.Objects.JsonReader;
    using Xunit;

    [Category("Objects.Get.Episodes.JsonReader")]
    public partial class EpisodeArrayJsonReader_Tests
    {
        [Fact]
        public void Test_EpisodeArrayJsonReader_Implements_IArrayJsonReader_Interface()
        {
            typeof(EpisodeArrayJsonReader).GetInterfaces().Should().Contain(typeof(IArrayJsonReader<ITraktEpisode>));
        }
    }
}
