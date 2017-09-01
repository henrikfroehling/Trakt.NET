namespace TraktApiSharp.Tests.Objects.Get.Movies.JsonReader
{
    using FluentAssertions;
    using Traits;
    using TraktApiSharp.Objects.Get.Movies;
    using TraktApiSharp.Objects.Get.Movies.JsonReader;
    using TraktApiSharp.Objects.JsonReader;
    using Xunit;

    [Category("Objects.Get.Movies.JsonReader")]
    public partial class MovieObjectJsonReader_Tests
    {
        [Fact]
        public void Test_MovieObjectJsonReader_Implements_IObjectJsonReader_Interface()
        {
            typeof(MovieObjectJsonReader).GetInterfaces().Should().Contain(typeof(IObjectJsonReader<ITraktMovie>));
        }
    }
}
