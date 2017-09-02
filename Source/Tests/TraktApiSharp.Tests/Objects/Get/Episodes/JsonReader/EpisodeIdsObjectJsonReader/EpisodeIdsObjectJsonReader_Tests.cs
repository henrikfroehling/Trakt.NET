namespace TraktApiSharp.Tests.Objects.Get.Episodes.JsonReader
{
    using FluentAssertions;
    using Traits;
    using TraktApiSharp.Objects.Get.Episodes;
    using TraktApiSharp.Objects.Get.Episodes.JsonReader;
    using TraktApiSharp.Objects.JsonReader;
    using Xunit;

    [Category("Objects.Get.Episodes.JsonReader")]
    public partial class EpisodeIdsObjectJsonReader_Tests
    {
        [Fact]
        public void Test_EpisodeIdsObjectJsonReader_Implements_IObjectJsonReader_Interface()
        {
            typeof(EpisodeIdsObjectJsonReader).GetInterfaces().Should().Contain(typeof(IObjectJsonReader<ITraktEpisodeIds>));
        }
    }
}
