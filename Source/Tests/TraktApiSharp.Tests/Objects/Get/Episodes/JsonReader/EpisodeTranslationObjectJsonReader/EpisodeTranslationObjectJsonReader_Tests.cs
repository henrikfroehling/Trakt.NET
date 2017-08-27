namespace TraktApiSharp.Tests.Objects.Get.Episodes.JsonReader
{
    using FluentAssertions;
    using Traits;
    using TraktApiSharp.Objects.Get.Episodes;
    using TraktApiSharp.Objects.Get.Episodes.JsonReader;
    using TraktApiSharp.Objects.JsonReader;
    using Xunit;

    [Category("Objects.Get.Episodes.JsonReader")]
    public partial class EpisodeTranslationObjectJsonReader_Tests
    {
        [Fact]
        public void Test_EpisodeTranslationObjectJsonReader_Implements_IObjectJsonReader_Interface()
        {
            typeof(EpisodeTranslationObjectJsonReader).GetInterfaces().Should().Contain(typeof(IObjectJsonReader<ITraktEpisodeTranslation>));
        }
    }
}
