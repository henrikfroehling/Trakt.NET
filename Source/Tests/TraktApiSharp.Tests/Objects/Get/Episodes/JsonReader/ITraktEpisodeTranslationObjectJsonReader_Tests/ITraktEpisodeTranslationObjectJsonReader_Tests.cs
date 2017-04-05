namespace TraktApiSharp.Tests.Objects.Get.Episodes.JsonReader
{
    using FluentAssertions;
    using Traits;
    using TraktApiSharp.Objects.Get.Episodes;
    using TraktApiSharp.Objects.Get.Episodes.JsonReader;
    using TraktApiSharp.Objects.JsonReader;
    using Xunit;

    [Category("Objects.Get.Episodes.JsonReader")]
    public partial class ITraktEpisodeTranslationObjectJsonReader_Tests
    {
        [Fact]
        public void Test_ITraktEpisodeTranslationObjectJsonReader_Implements_ITraktObjectJsonReader_Interface()
        {
            typeof(ITraktEpisodeTranslationObjectJsonReader).GetInterfaces().Should().Contain(typeof(ITraktObjectJsonReader<ITraktEpisodeTranslation>));
        }
    }
}
