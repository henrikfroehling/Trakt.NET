namespace TraktApiSharp.Tests.Objects.Get.Episodes.JsonReader
{
    using FluentAssertions;
    using Traits;
    using TraktApiSharp.Objects.Get.Episodes;
    using TraktApiSharp.Objects.Get.Episodes.JsonReader;
    using TraktApiSharp.Objects.JsonReader;
    using Xunit;

    [Category("Objects.Get.Episodes.JsonReader")]
    public partial class TraktEpisodeCollectionProgressObjectJsonReader_Tests
    {
        [Fact]
        public void Test_TraktEpisodeCollectionProgressObjectJsonReader_Implements_ITraktObjectJsonReader_Interface()
        {
            typeof(TraktEpisodeCollectionProgressObjectJsonReader).GetInterfaces().Should().Contain(typeof(ITraktObjectJsonReader<ITraktEpisodeCollectionProgress>));
        }
    }
}
