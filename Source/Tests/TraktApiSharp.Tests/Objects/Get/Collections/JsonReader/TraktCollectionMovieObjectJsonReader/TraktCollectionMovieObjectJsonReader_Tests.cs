namespace TraktApiSharp.Tests.Objects.Get.Collections.JsonReader
{
    using FluentAssertions;
    using Traits;
    using TraktApiSharp.Objects.Get.Collections;
    using TraktApiSharp.Objects.Get.Collections.JsonReader;
    using TraktApiSharp.Objects.JsonReader;
    using Xunit;

    [Category("Objects.Get.Collections.JsonReader")]
    public partial class TraktCollectionMovieObjectJsonReader_Tests
    {
        [Fact]
        public void Test_TraktCollectionMovieObjectJsonReader_Implements_ITraktObjectJsonReader_Interface()
        {
            typeof(TraktCollectionMovieObjectJsonReader).GetInterfaces().Should().Contain(typeof(ITraktObjectJsonReader<ITraktCollectionMovie>));
        }
    }
}
