namespace TraktApiSharp.Tests.Objects.Get.Episodes.JsonReader
{
    using FluentAssertions;
    using Traits;
    using TraktApiSharp.Objects.Get.Episodes;
    using TraktApiSharp.Objects.Get.Episodes.JsonReader;
    using TraktApiSharp.Objects.JsonReader;
    using Xunit;

    [Category("Objects.Get.Episodes.JsonReader")]
    public partial class EpisodeCollectionProgressArrayJsonReader_Tests
    {
        [Fact]
        public void Test_EpisodeCollectionProgressArrayJsonReader_Implements_IArrayJsonReader_Interface()
        {
            typeof(EpisodeCollectionProgressArrayJsonReader).GetInterfaces().Should().Contain(typeof(IArrayJsonReader<ITraktEpisodeCollectionProgress>));
        }
    }
}
