namespace TraktApiSharp.Tests.Objects.Get.Movies.JsonReader
{
    using FluentAssertions;
    using Traits;
    using TraktApiSharp.Objects.Get.Movies;
    using TraktApiSharp.Objects.Get.Movies.JsonReader;
    using TraktApiSharp.Objects.JsonReader;
    using Xunit;

    [Category("Objects.Get.Movies.JsonReader")]
    public partial class RecentlyUpdatedMovieObjectJsonReader_Tests
    {
        [Fact]
        public void Test_RecentlyUpdatedMovieObjectJsonReader_Implements_IObjectJsonReader_Interface()
        {
            typeof(RecentlyUpdatedMovieObjectJsonReader).GetInterfaces().Should().Contain(typeof(IObjectJsonReader<ITraktRecentlyUpdatedMovie>));
        }
    }
}
