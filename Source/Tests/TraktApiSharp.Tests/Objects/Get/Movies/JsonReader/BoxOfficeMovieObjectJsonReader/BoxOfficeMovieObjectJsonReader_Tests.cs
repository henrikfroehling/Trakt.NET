namespace TraktApiSharp.Tests.Objects.Get.Movies.JsonReader
{
    using FluentAssertions;
    using Traits;
    using TraktApiSharp.Objects.Get.Movies;
    using TraktApiSharp.Objects.Get.Movies.JsonReader;
    using TraktApiSharp.Objects.JsonReader;
    using Xunit;

    [Category("Objects.Get.Movies.JsonReader")]
    public partial class BoxOfficeMovieObjectJsonReader_Tests
    {
        [Fact]
        public void Test_BoxOfficeMovieObjectJsonReader_Implements_IObjectJsonReader_Interface()
        {
            typeof(BoxOfficeMovieObjectJsonReader).GetInterfaces().Should().Contain(typeof(IObjectJsonReader<ITraktBoxOfficeMovie>));
        }
    }
}
