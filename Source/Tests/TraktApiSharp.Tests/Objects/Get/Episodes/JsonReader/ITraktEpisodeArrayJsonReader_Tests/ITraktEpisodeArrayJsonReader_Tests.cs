namespace TraktApiSharp.Tests.Objects.Get.Episodes.JsonReader
{
    using FluentAssertions;
    using Traits;
    using TraktApiSharp.Objects.Get.Episodes;
    using TraktApiSharp.Objects.Get.Episodes.JsonReader;
    using TraktApiSharp.Objects.JsonReader;
    using Xunit;

    [Category("Objects.Get.Episodes.JsonReader")]
    public partial class ITraktEpisodeArrayJsonReader_Tests
    {
        [Fact]
        public void Test_ITraktEpisodeArrayJsonReader_Implements_ITraktArrayJsonReader_Interface()
        {
            typeof(ITraktEpisodeArrayJsonReader).GetInterfaces().Should().Contain(typeof(ITraktArrayJsonReader<ITraktEpisode>));
        }
    }
}
