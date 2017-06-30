namespace TraktApiSharp.Tests.Objects.Get.Watched.JsonReader
{
    using FluentAssertions;
    using Traits;
    using TraktApiSharp.Objects.Get.Watched;
    using TraktApiSharp.Objects.Get.Watched.JsonReader;
    using TraktApiSharp.Objects.JsonReader;
    using Xunit;

    [Category("Objects.Get.Watched.JsonReader")]
    public partial class TraktWatchedShowEpisodeObjectJsonReader_Tests
    {
        [Fact]
        public void Test_TraktWatchedShowEpisodeObjectJsonReader_Implements_ITraktObjectJsonReader_Interface()
        {
            typeof(TraktWatchedShowEpisodeObjectJsonReader).GetInterfaces().Should().Contain(typeof(ITraktObjectJsonReader<ITraktWatchedShowEpisode>));
        }
    }
}
