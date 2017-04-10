namespace TraktApiSharp.Tests.Objects.Get.Episodes.JsonReader
{
    using FluentAssertions;
    using Traits;
    using TraktApiSharp.Objects.Get.Episodes;
    using TraktApiSharp.Objects.Get.Episodes.JsonReader;
    using TraktApiSharp.Objects.JsonReader;
    using Xunit;

    [Category("Objects.Get.Episodes.JsonReader")]
    public partial class ITraktEpisodeTranslationArrayJsonReader_Tests
    {
        [Fact]
        public void Test_ITraktEpisodeTranslationArrayJsonReader_Implements_ITraktArrayJsonReader_Interface()
        {
            typeof(ITraktEpisodeTranslationArrayJsonReader).GetInterfaces().Should().Contain(typeof(ITraktArrayJsonReader<ITraktEpisodeTranslation>));
        }
    }
}
