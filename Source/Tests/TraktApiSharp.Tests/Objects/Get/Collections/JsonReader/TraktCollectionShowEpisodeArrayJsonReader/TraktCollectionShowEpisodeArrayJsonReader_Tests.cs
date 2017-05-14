namespace TraktApiSharp.Tests.Objects.Get.Collections.JsonReader
{
    using FluentAssertions;
    using Traits;
    using TraktApiSharp.Objects.Get.Collections;
    using TraktApiSharp.Objects.Get.Collections.JsonReader;
    using TraktApiSharp.Objects.JsonReader;
    using Xunit;

    [Category("Objects.Get.Collections.JsonReader")]
    public partial class TraktCollectionShowEpisodeArrayJsonReader_Tests
    {
        [Fact]
        public void Test_TraktCollectionShowEpisodeArrayJsonReader_Implements_ITraktArrayJsonReader_Interface()
        {
            typeof(TraktCollectionShowEpisodeArrayJsonReader).GetInterfaces().Should().Contain(typeof(ITraktArrayJsonReader<ITraktCollectionShowEpisode>));
        }
    }
}
