namespace TraktApiSharp.Tests.Objects.Get.Collections.JsonReader
{
    using FluentAssertions;
    using Traits;
    using TraktApiSharp.Objects.Get.Collections;
    using TraktApiSharp.Objects.Get.Collections.JsonReader;
    using TraktApiSharp.Objects.JsonReader;
    using Xunit;

    [Category("Objects.Get.Collections.JsonReader")]
    public partial class CollectionMovieObjectJsonReader_Tests
    {
        [Fact]
        public void Test_CollectionMovieObjectJsonReader_Implements_IObjectJsonReader_Interface()
        {
            typeof(CollectionMovieObjectJsonReader).GetInterfaces().Should().Contain(typeof(IObjectJsonReader<ITraktCollectionMovie>));
        }
    }
}
