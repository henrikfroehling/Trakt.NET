namespace TraktApiSharp.Tests.Objects.Get.Collections.JsonReader
{
    using FluentAssertions;
    using Traits;
    using TraktApiSharp.Objects.Get.Collections;
    using TraktApiSharp.Objects.Get.Collections.JsonReader;
    using TraktApiSharp.Objects.JsonReader;
    using Xunit;

    [Category("Objects.Get.Collections.JsonReader")]
    public partial class ITraktCollectionShowEpisodeObjectJsonReader_Tests
    {
        [Fact]
        public void Test_ITraktCollectionShowEpisodeObjectJsonReader_Implements_ITraktObjectJsonReader_Interface()
        {
            typeof(ITraktCollectionShowEpisodeObjectJsonReader).GetInterfaces().Should().Contain(typeof(ITraktObjectJsonReader<ITraktCollectionShowEpisode>));
        }
    }
}
