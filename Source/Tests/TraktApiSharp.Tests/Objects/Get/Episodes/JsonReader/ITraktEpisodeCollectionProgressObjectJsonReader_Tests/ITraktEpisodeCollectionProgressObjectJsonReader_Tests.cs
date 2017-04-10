namespace TraktApiSharp.Tests.Objects.Get.Episodes.JsonReader
{
    using FluentAssertions;
    using Traits;
    using TraktApiSharp.Objects.Get.Episodes;
    using TraktApiSharp.Objects.Get.Episodes.JsonReader;
    using TraktApiSharp.Objects.JsonReader;
    using Xunit;

    [Category("Objects.Get.Episodes.JsonReader")]
    public partial class ITraktEpisodeCollectionProgressObjectJsonReader_Tests
    {
        [Fact]
        public void Test_ITraktEpisodeCollectionProgressObjectJsonReader_Implements_ITraktObjectJsonReader_Interface()
        {
            typeof(ITraktEpisodeCollectionProgressObjectJsonReader).GetInterfaces().Should().Contain(typeof(ITraktObjectJsonReader<ITraktEpisodeCollectionProgress>));
        }
    }
}
