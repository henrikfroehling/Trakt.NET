namespace TraktApiSharp.Tests.Objects.Get.Episodes.JsonReader
{
    using FluentAssertions;
    using Traits;
    using TraktApiSharp.Objects.Get.Episodes;
    using TraktApiSharp.Objects.Get.Episodes.JsonReader;
    using TraktApiSharp.Objects.JsonReader;
    using Xunit;

    [Category("Objects.Get.Episodes.JsonReader")]
    public partial class EpisodeCollectionProgressObjectJsonReader_Tests
    {
        [Fact]
        public void Test_EpisodeCollectionProgressObjectJsonReader_Implements_IObjectJsonReader_Interface()
        {
            typeof(EpisodeCollectionProgressObjectJsonReader).GetInterfaces().Should().Contain(typeof(IObjectJsonReader<ITraktEpisodeCollectionProgress>));
        }
    }
}
