namespace TraktApiSharp.Tests.Objects.Get.Movies.JsonReader
{
    using FluentAssertions;
    using Traits;
    using TraktApiSharp.Objects.Get.Movies;
    using TraktApiSharp.Objects.Get.Movies.JsonReader;
    using TraktApiSharp.Objects.JsonReader;
    using Xunit;

    [Category("Objects.Get.Movies.JsonReader")]
    public partial class MovieReleaseObjectJsonReader_Tests
    {
        [Fact]
        public void Test_MovieReleaseObjectJsonReader_Implements_IObjectJsonReader_Interface()
        {
            typeof(MovieReleaseObjectJsonReader).GetInterfaces().Should().Contain(typeof(IObjectJsonReader<ITraktMovieRelease>));
        }
    }
}
