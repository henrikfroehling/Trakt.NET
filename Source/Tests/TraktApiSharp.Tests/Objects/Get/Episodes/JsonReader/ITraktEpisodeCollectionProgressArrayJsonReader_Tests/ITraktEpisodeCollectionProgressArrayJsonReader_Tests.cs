namespace TraktApiSharp.Tests.Objects.Get.Episodes.JsonReader
{
    using FluentAssertions;
    using Traits;
    using TraktApiSharp.Objects.Get.Episodes;
    using TraktApiSharp.Objects.Get.Episodes.JsonReader;
    using TraktApiSharp.Objects.JsonReader;
    using Xunit;

    [Category("Objects.Get.Episodes.JsonReader")]
    public partial class ITraktEpisodeCollectionProgressArrayJsonReader_Tests
    {
        [Fact]
        public void Test_ITraktEpisodeCollectionProgressArrayJsonReader_Implements_ITraktArrayJsonReader_Interface()
        {
            typeof(ITraktEpisodeCollectionProgressArrayJsonReader).GetInterfaces().Should().Contain(typeof(ITraktArrayJsonReader<ITraktEpisodeCollectionProgress>));
        }
    }
}
