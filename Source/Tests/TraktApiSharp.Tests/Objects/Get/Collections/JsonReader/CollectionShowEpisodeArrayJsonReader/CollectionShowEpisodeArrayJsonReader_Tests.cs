namespace TraktApiSharp.Tests.Objects.Get.Collections.JsonReader
{
    using FluentAssertions;
    using Traits;
    using TraktApiSharp.Objects.Get.Collections;
    using TraktApiSharp.Objects.Get.Collections.JsonReader;
    using TraktApiSharp.Objects.JsonReader;
    using Xunit;

    [Category("Objects.Get.Collections.JsonReader")]
    public partial class CollectionShowEpisodeArrayJsonReader_Tests
    {
        [Fact]
        public void Test_CollectionShowEpisodeArrayJsonReader_Implements_IArrayJsonReader_Interface()
        {
            typeof(CollectionShowEpisodeArrayJsonReader).GetInterfaces().Should().Contain(typeof(IArrayJsonReader<ITraktCollectionShowEpisode>));
        }
    }
}
