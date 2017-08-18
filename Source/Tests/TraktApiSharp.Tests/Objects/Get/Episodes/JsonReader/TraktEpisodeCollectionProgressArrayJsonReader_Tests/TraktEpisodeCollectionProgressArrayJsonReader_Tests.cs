namespace TraktApiSharp.Tests.Objects.Get.Episodes.JsonReader
{
    using FluentAssertions;
    using Traits;
    using TraktApiSharp.Objects.Get.Episodes;
    using TraktApiSharp.Objects.Get.Episodes.JsonReader;
    using TraktApiSharp.Objects.JsonReader;
    using Xunit;

    [Category("Objects.Get.Episodes.JsonReader")]
    public partial class TraktEpisodeCollectionProgressArrayJsonReader_Tests
    {
        [Fact]
        public void Test_TraktEpisodeCollectionProgressArrayJsonReader_Implements_ITraktArrayJsonReader_Interface()
        {
            typeof(TraktEpisodeCollectionProgressArrayJsonReader).GetInterfaces().Should().Contain(typeof(IArrayJsonReader<ITraktEpisodeCollectionProgress>));
        }
    }
}
