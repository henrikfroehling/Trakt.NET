namespace TraktApiSharp.Tests.Objects.Get.Episodes.JsonReader
{
    using FluentAssertions;
    using Traits;
    using TraktApiSharp.Objects.Get.Episodes;
    using TraktApiSharp.Objects.Get.Episodes.JsonReader;
    using TraktApiSharp.Objects.JsonReader;
    using Xunit;

    [Category("Objects.Get.Episodes.JsonReader")]
    public partial class EpisodeTranslationArrayJsonReader_Tests
    {
        [Fact]
        public void Test_EpisodeTranslationArrayJsonReader_Implements_IArrayJsonReader_Interface()
        {
            typeof(EpisodeTranslationArrayJsonReader).GetInterfaces().Should().Contain(typeof(IArrayJsonReader<ITraktEpisodeTranslation>));
        }
    }
}
